using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// こちらからお借りしました
// https://note.dokeep.jp/post/csharp-inifile-read/
public class IniFile
{
    private const StringComparison Comparison = StringComparison.Ordinal;
    private static readonly StringComparer Comparer = StringComparer.OrdinalIgnoreCase;

    private readonly Dictionary<string, Dictionary<string, string>> _ini = new Dictionary<string, Dictionary<string, string>>(Comparer);
 
    public Dictionary<string, Dictionary<string, string>> Keys { get => _ini; }
    public bool HasCategory(string category) => _ini.ContainsKey(category);
    public Dictionary<string, string> GetCategory(string category) => _ini[category];

    public IniFile(string file, Encoding encoding = null)
    {
        var lines = File.ReadLines(file, encoding ?? Encoding.UTF8)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .Where(x => !x.StartsWith(";", Comparison));

        var currentSection = new Dictionary<string, string>(Comparer);
        var key = "";
        var isNextLine = false;

        _ini[""] = currentSection;

        foreach (var line in lines)
        {
            if (isNextLine)
            {
                isNextLine = IsNextLine(line);
                currentSection[key] += GetValue(line, 0, isNextLine).TrimEnd();
                continue;
            }

            if (line[0] == '[' && line[line.Length - 1] == ']')
            {
                currentSection = new Dictionary<string, string>(Comparer);
                var section = line.Substring(1, line.Length - 2).Trim();
                _ini[section] = currentSection;
                continue;
            }

            var index = line.IndexOf("=", Comparison);
            if (index == -1) continue;

            key = line.Substring(0, index).Trim();
            isNextLine = IsNextLine(line);
            currentSection[key] = GetValue(line, index + 1, isNextLine).Trim();
        }

        const char nextLineChar = '+';
        const char escapeChar = '\\';

        bool IsNextLine(string line) => line[line.Length - 1] == nextLineChar && line.Length >= 2 &&
                                        line[line.Length - 2] != escapeChar;

        string GetValue(string line, int startIndex, bool isNextLineChar)
        {
            var length = line.Length - startIndex - (isNextLineChar ? 1 : 0);

            var sb = new StringBuilder();
            var escape = false;
            var ignoreSpace = false;

            // "\Ima+ ge\+123.png"のようになっていたら、"\Image+123.png"と見なす
            foreach (var c in line.Skip(startIndex).Take(length))
            {
                if (escape)
                {
                    if (c != nextLineChar)
                        sb.Append(escapeChar);
                }
                else
                {
                    switch (c)
                    {
                        case escapeChar:
                            escape = true;
                            ignoreSpace = false;
                            continue;
                        case nextLineChar:
                            ignoreSpace = true;
                            continue;
                        case ' ' when ignoreSpace:
                            continue;
                    }
                }

                escape = false;
                ignoreSpace = false;
                sb.Append(c);
            }

            return sb.ToString();
        }
    }

    public string GetValueRoot(string key, string @default = null) => GetValue("", key, @default);

    public string GetValue(string section, string key = "", string @default = null)
    {
        var ret = _ini.TryGetValue(section, out var iniSection) &&
                iniSection.TryGetValue(key, out var value)
            ? value
            : @default;

        if (ret.StartsWith("\"") && ret.EndsWith("\""))
        {
            ret = ret.Substring(1, ret.Length - 2);
        }

        return ret;
    }

    public int GetValueInt(string section, string key = "", int @default = 0)
    {
        return int.TryParse(GetValue(section, key, ""), out int result) ? result : @default;
    }

    public bool GetValueBool(string section, string key = "", bool @default = false)
    {
        return bool.TryParse(GetValue(section, key, ""), out bool result) ? result : @default;
    }

    public IEnumerable<string> GetKeys(string section)
    {
        return _ini.TryGetValue(section, out var iniSection) ? iniSection.Keys : Enumerable.Empty<string>();
    }

    public IEnumerable<string> GetSections() => _ini.Keys.Where(x => x != "");
}
