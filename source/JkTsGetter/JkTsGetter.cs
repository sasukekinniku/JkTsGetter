using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;

namespace JkTsGetter
{
    public class JkTsGetter
    {
        /// <summary>
        /// この時間を新ニコニコ実況開始の境目とする
        /// </summary>
        private static DateTime? Now = null;
        public static DateTime NewJkStartDateTime
        {
            get
            {
                if (!Now.HasValue) { Now = DateTime.Now; };
                // Now = new DateTime(2021, 1, 9, 0, 0, 0);
                // 新ニコニコ実況の開始日
                var startDate = new DateTime(2020, 12, 16, 11, 00, 00);
                // キャッシュを使う場合は新ニコニコ実況の開始日を区切りとする
                if (Settings.Get().Config.UseLoadFromCache)
                {
                    return startDate;
                }
                // 本日タイムシフトの期限が切れる日
                // 2021/1/9 0:00 に 2020/12/18 4:00 より前のタイムシフトが切れる
                var lastTimeShift = new DateTime(Now.Value.Year, Now.Value.Month, Now.Value.Day, 4, 0, 0);
                lastTimeShift = lastTimeShift.AddDays(-(3 * 7 + 1));
                // 新ニコニコ実況開始よりも前になった
                if (lastTimeShift < startDate) { return startDate; }
                return lastTimeShift;
            }
        }

        /// <summary>
        /// iniファイル設定
        /// </summary>
        public class Settings
        {
            private static Settings Instance { get; set; }

            public class ConfigSettings
            {
                // 録画ツールへのファイルパス
                public string GetterToolPath { get; set; } = @".\ニコ生新配信録画ツール（仮.exe";
                // 録画ツールのコマンドラインオプション
                public string GetterToolParam { get; set; } = "-Isminimized=true -IscloseExit=true -IsgetComment=true -EngineMode=3 -fileNameType=10 -ts-start=0h0m0s -IscreateSubfolder=false -IsdefaultRecordDir=true";
                // 録画ツールのコマンドラインオプション (追っかけ再生時の追加)
                public string GetterToolParamChase { get; set; } = "-IsArgChaseRecFromFirst=true IsChaseRecord=true -chase";
                // 旧過去ログ取得APIのURL
                public string GetterOldLogApiUrl { get; set; } = "https://jikkyo.tsukumijima.net/api/kakolog/jk{0}?starttime={1}&endtime={2}&format=xml";
                // 旧過去ログ取得APIの取得間隔時間
                public int GetterOldLogApiMaxHour { get; set; } = 72;
                public string LogCachePath { get; set; } = "";
                public bool UseSaveToCache { get; set; } = false;
                public bool UseLoadFromCache { get; set; } = false;
            }

            public ConfigSettings Config { get; set; } = new ConfigSettings();

            /// <summary>
            /// 録画ツールへのフルパスを取得
            /// </summary>
            /// <returns></returns>
            public string GetGetterToolPath()
            {
                var path = Config.GetterToolPath;
                if (!path.Contains(":") && !path.StartsWith(@"\\"))
                {
                    path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\" + path;
                }
                if (!File.Exists(path))
                {
                    Console.WriteLine($"録画ツール {path} がみつかりません");
                }
                return path;
            }

            /// <summary>
            /// iniファイルから設定読み込み
            /// </summary>
            /// <param name="iniPath"></param>
            private void Load(string iniPath)
            {
                try
                {
                    var ini = new IniFile(iniPath); // root

                    Config.GetterToolPath = ini.GetValue("Config", "GetterToolPath", Config.GetterToolPath);
                    Config.GetterToolParam = ini.GetValue("Config", "GetterToolParam", Config.GetterToolParam);
                    Config.GetterToolParamChase = ini.GetValue("Config", "GetterToolParamChase", Config.GetterToolParamChase);
                    Config.GetterOldLogApiUrl = ini.GetValue("Config", "GetterOldLogApiUrl", Config.GetterOldLogApiUrl);
                    Config.GetterOldLogApiMaxHour = ini.GetValueInt("Config", "GetterOldLogApiMaxHour", Config.GetterOldLogApiMaxHour);
                    Config.LogCachePath = ini.GetValue("Config", "LogCachePath", Config.LogCachePath);
                    Config.UseSaveToCache = ini.GetValueBool("Config", "UseSaveToCache", Config.UseSaveToCache);
                    Config.UseLoadFromCache = ini.GetValueBool("Config", "UseLoadFromCache", Config.UseLoadFromCache);
                }
                catch (Exception)
                {

                }
            }

            /// <summary>
            /// 設定を取得
            /// </summary>
            /// <returns></returns>
            public static Settings Get()
            {
                if (Instance != null)
                {
                    return Instance;
                }

                string iniPath = Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "ini");
                Instance = new Settings();
                Instance.Load(iniPath);

                return Instance;
            }
        }

        /// <summary>
        /// パラメータからの設定
        /// </summary>
        public class ParameterSettings
        {
            // チャンネル名のサブフォルダを作成するか
            public bool CreateDirectory { get; set; } = false;
            // 出力ファイル名、フォルダパス
            public string OutputFileName { get; set; } = "";
            // 同名ファイルを上書きするか
            public bool OverWrite { get; set; } = false;
            // 日時にかかわらず旧APIにつなぐ
            public bool AlwaysOldApi { get; set; } = false;

            // 出力ファイル名を取得
            public string GetOutputPath(int jk, string defaultName = "")
            {
                string outputPath = OutputFileName == null ? "" : OutputFileName.EndsWith(@"\") ? OutputFileName : Path.GetDirectoryName(OutputFileName);
                string outputName = Path.GetFileName(OutputFileName);

                if (Directory.Exists(OutputFileName))
                {
                    outputPath = OutputFileName;
                    outputName = "";
                }

                if (string.IsNullOrEmpty(outputName))
                {
                    outputName = defaultName;
                }
                if (string.IsNullOrEmpty(outputPath))
                {
                    outputPath = "";
                }
                else if (!outputPath.EndsWith(@"\"))
                {
                    outputPath += @"\";
                }
                if (CreateDirectory)
                {
                    outputPath += $"jk{jk}" + @"\";
                }
                return outputPath + outputName;
            }
        }
        public ParameterSettings Param { set; get; } = new ParameterSettings();

        public string GetCacheFilePath(int jk, DateTime date)
        {
            return JkTsGetter.Settings.Get().Config.LogCachePath + $@"\jk{jk}\jk{jk}_{date.ToString("yyyyMMdd")}.xml";
        }

        /// <summary>
        /// ファイルの上書きチェック
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool OverWriteCheck(string filePath)
        {
            if (File.Exists(filePath))
            {
                if (!Param.OverWrite)
                {
                    Console.WriteLine(filePath + " がもうあったので処理を行いません");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ファイル書き込み前のチェック
        /// 同名ファイルがある場合は削除する
        /// </summary>
        /// <param name="filePath"></param>
        public void CheckTargetPath(string filePath)
        {
            if (filePath.Contains(@"\"))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }

            if (File.Exists(filePath))
            {
                if (Param.OverWrite)
                {
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// 今とれるすべての実況タイムシフトを取得
        /// </summary>
        /// <param name="toCache"></param>
        public void ExecuteAllTsGet(bool toCache = false)
        {
            if (toCache)
            {
                Param.CreateDirectory = true;
                Param.OverWrite = false;
                Param.OutputFileName = Settings.Get().Config.LogCachePath;
            }

            foreach (var channel in Channel.Channels)
            {
                if (channel.ch <= 0) { continue; }

                var info = Util.GetChannelLiveInfo(channel);

                foreach (var item in info.data.items)
                {
                    switch (item.category)
                    {
                        case "past":
                            GetChannelLiveComment(channel, item);
                            break;
 
                        case "current":
                            // ExecuteGetterChase(channel, item);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// XMLファイルから指定範囲時間のコメントを切り取る
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destFile"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void TrimChatXmlFileTimeRange(string sourceFile, string destFile, DateTime start, DateTime end)
        {
            var xdoc = XDocument.Load(sourceFile);
            xdoc = TrimChatXmlFileTimeRange(xdoc, start, end);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "";
            using (XmlWriter writer = XmlTextWriter.Create(destFile, settings))
            {
                xdoc.Save(writer);
            }
        }

        /// <summary>
        /// XMLドキュメントから指定範囲時間のコメントを切り取る
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destFile"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public XDocument TrimChatXmlFileTimeRange(XDocument xdoc, DateTime start, DateTime end)
        {
            Console.WriteLine($"{Util.DateTimeToUnixTimeStamp(start)} から {Util.DateTimeToUnixTimeStamp(end)} まで切り取り");

            xdoc.Descendants("chat").Where(
                (e) =>
                {
                    var date = int.Parse(e.Attribute("date").Value);
                    return date < Util.DateTimeToUnixTimeStamp(start) || date >= Util.DateTimeToUnixTimeStamp(end);
                }).Remove();

            return xdoc;
        }

        /// <summary>
        /// 指定チャンネル、指定生放送のタイムシフトコメントを全取得
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool GetChannelLiveComment(Channel channel, ChannelLiveInfo.Item item)
        {
            string dateString = item.openedAt.ToString("yyyyMMdd");
            string defaultFileName = $"jk{channel.jk}_{dateString}.xml";
            string targetPath = Param.GetOutputPath(channel.jk, defaultFileName);

            if (!OverWriteCheck(targetPath))
            {
                return false;
            }

            if (!ExecuteGetter(out string tempFilePath, channel, item))
            {
                return false;
            }

            if (!OverWriteCheck(targetPath))
            {
                return false;
            }

            CheckTargetPath(targetPath);
            File.Move(tempFilePath, targetPath);

            Console.WriteLine(targetPath + " に出力しました");
            return true;
        }

        /// <summary>
        /// 時間範囲から一度にコメントを取れる範囲に分割する
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<DateTime> GetDateTimeList(DateTime start, DateTime end)
        {
            var List = new List<DateTime>();

            DateTime current = start;
            if (start < NewJkStartDateTime || Param.AlwaysOldApi)
            {
                List.Add(start);

                TimeSpan span = NewJkStartDateTime - current;
                if (span.TotalHours >= Settings.Get().Config.GetterOldLogApiMaxHour || Param.AlwaysOldApi)
                {
                    do
                    {
                        current = current.AddHours(Settings.Get().Config.GetterOldLogApiMaxHour);
                        if (current >= end)
                        {
                            List.Add(end);
                            return List;
                        }
                        List.Add(current);
                        span = NewJkStartDateTime - current;
                    } while (span.TotalHours >= Settings.Get().Config.GetterOldLogApiMaxHour || Param.AlwaysOldApi);
                }

                current = NewJkStartDateTime;
            }

            while (current < end)
            {
                List.Add(current);

                // その日の4時区切り
                DateTime Time4ji = new DateTime(current.Year, current.Month, current.Day, 4, 0, 0);
                if (current.Hour >= 4)
                {
                    Time4ji = Time4ji.AddDays(1);
                }
                if (end > Time4ji)
                {
                    current = Time4ji;
                }
                else
                {
                    break;
                }
            }

            List.Add(end);

            return List;
        }

        /// <summary>
        /// 指定時間内の過去ログを取得する 4時またぎ・時間分割非対応
        /// </summary>
        /// <param name="jk"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool ExecuteGetterTimeRangeSimple(int jk, DateTime start, DateTime end)
        {
            string dateString = start.ToString("yyyyMMddHHmmss") + "_" + end.ToString("yyyyMMddHHmmss");
            string defaultFileName = $"jk{jk}_{dateString}.xml";
            string targetPath = Param.GetOutputPath(jk, defaultFileName);

            if (!OverWriteCheck(targetPath))
            {
                return false;
            }

            string xmlText = GetLogXmlString(jk, start, end);
            if (string.IsNullOrEmpty(xmlText))
            {
                return false;
            }

            CheckTargetPath(targetPath);

            var sw = new System.IO.StreamWriter(targetPath, false, Encoding.UTF8);
            sw.Write(xmlText);
            sw.Close();

            Console.WriteLine(targetPath + " に出力しました");

            return true;
        }

        /// <summary>
        /// 指定チャンネル、指定時間のログをstringで取得する 4時またぎ・時間分割非対応
        /// </summary>
        /// <param name="jk"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string GetLogXmlString(int jk, DateTime start, DateTime end)
        {
            var channel = Channel.GetChannel(jk);

            string dateString = start.ToString("yyyyMMddHHmmss") + "_" + end.ToString("yyyyMMddHHmmss");
            string defaultFileName = $"jk{channel.jk}_{dateString}.xml";

            string xmlText = "";

            if (start < NewJkStartDateTime || Param.AlwaysOldApi)
            {
                xmlText = GetOldNicoJKLog(jk, start, end);
                return xmlText;
            }

            DateTime getDate = start;
            if (getDate.Hour < 4)
            {
                getDate = getDate.AddDays(-1);
            }

            if (JkTsGetter.Settings.Get().Config.UseLoadFromCache)
            {
                string cachePath = GetCacheFilePath(channel.jk, new DateTime(getDate.Year, getDate.Month, getDate.Day));
                if (File.Exists(cachePath))
                {
                    Console.WriteLine($"キャッシュファイル {cachePath} から読み込みます");
                    StreamReader sre = new StreamReader(cachePath, Encoding.UTF8);
                    xmlText = sre.ReadToEnd();
                    sre.Close();
                    return xmlText;
                }
            }

            var item = Util.GetTimeShiftItem(channel, getDate.Year, getDate.Month, getDate.Day);

            if (item == null)
            {
                Console.WriteLine("この日のタイムシフトは見つかりませんでした");
                Console.WriteLine("かわりに過去ログAPIから取得してみます");

                xmlText = GetOldNicoJKLog(jk, start, end);
            }

            bool done = false;
            string tempFilePath = "";

            switch (item.category)
            {
                case "past":
                    done = ExecuteGetter(out tempFilePath, channel, item, isChase: false);
                    break;

                case "current":
                    done = ExecuteGetter(out tempFilePath, channel, item, isChase: true);
                    break;
            }

            if (!done)
            {
                return "";
            }

            StreamReader sr = new StreamReader(tempFilePath, Encoding.UTF8);
            xmlText = sr.ReadToEnd();
            sr.Close();

            DateTime getStart = new DateTime(getDate.Year, getDate.Month, getDate.Day, 4, 0, 0);
            DateTime getEnd = getStart.AddDays(1);
            if (getStart < start || getEnd > end)
            {
                var xdoc = XDocument.Parse(xmlText);
                xdoc = TrimChatXmlFileTimeRange(xdoc, start, end);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "";

                StringBuilder builder = new StringBuilder();
                using (XmlWriter writer = XmlTextWriter.Create(builder, settings))
                {
                    xdoc.Save(writer);
                }
                xmlText = builder.ToString();
            }

            File.Delete(tempFilePath);

            return xmlText;
        }

        /// <summary>
        /// 指定時間内の過去ログを取得する 4時またぎに対応する
        /// </summary>
        /// <param name="jk"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool ExecuteGetterTimeRange(int jk, DateTime start, DateTime end)
        {
            string dateString = start.ToString("yyyyMMddHHmmss") + "_" + end.ToString("yyyyMMddHHmmss");
            string defaultFileName = $"jk{jk}_{dateString}.xml";
            string channelFolder = $"\\jk{jk}";
            string targetPath = Param.GetOutputPath(jk, defaultFileName);

            if (!OverWriteCheck(targetPath))
            {
                return false;
            }

            var timeList = GetDateTimeList(start, end);
            XDocument currentXdoc = null;

            while (timeList.Count >= 2)
            {
                string xmlText = GetLogXmlString(jk, timeList[0], timeList[1]);
                if (string.IsNullOrEmpty(xmlText))
                {
                    timeList.RemoveAt(0);
                    continue;
                }

                XDocument xdoc = XDocument.Parse(xmlText);
                if (currentXdoc == null)
                {
                    currentXdoc = xdoc;
                }
                else
                {
                    currentXdoc.Root.Add(xdoc.Root.Elements());
                }
                timeList.RemoveAt(0);
            }

            CheckTargetPath(targetPath);

            if (currentXdoc == null)
            {
                Console.WriteLine("何も取得できませんでした");
                return false;
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "";
                
            using (XmlWriter writer = XmlTextWriter.Create(targetPath, settings))
            {
                currentXdoc.Save(writer);
            }

            Console.WriteLine(targetPath + " に出力しました");

            return true;
        }

        /// <summary>
        /// 指定チャンネルのニコ生タイムシフトを追っかけ録画で取得する
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool GetChannelLiveCommentChase(Channel channel, ChannelLiveInfo.Item item)
        {
            DateTime now = DateTime.Now;
            string dateString = $"{item.openedAt.ToString("yyyyMMdd")}_{now.ToString("HHmmss")}";
            string defaultFileName = $"jk{channel.jk}_{dateString}.xml";
            string channelFolder = $"\\jk{channel.jk}";
            string targetPath = Param.GetOutputPath(channel.jk, defaultFileName);

            if (!OverWriteCheck(targetPath))
            {
                return false;
            }

            if (!ExecuteGetter(out string tempFilePath, channel, item, isChase: true))
            {
                return false;
            }

            CheckTargetPath(targetPath);
            File.Move(tempFilePath, targetPath);

            Console.WriteLine(targetPath + " に出力しました");
            return true;
        }

        /// <summary>
        /// 指定チャンネルのニコ生コメントをタイムシフトで取得する
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool ExecuteGetter(out string tempFilePath, Channel channel, ChannelLiveInfo.Item item, bool isChase = false)
        {
            string getterExePath = JkTsGetter.Settings.Get().GetGetterToolPath();
            string tempFolder = System.IO.Path.GetDirectoryName(getterExePath) + @"\rec";
            string tempFileName = $"temp_lv{item.liveId}_0";
            tempFilePath = tempFolder + @"\" + tempFileName + ".xml";
            string cachePath = GetCacheFilePath(channel.jk, new DateTime(item.openedAt.Year, item.openedAt.Month, item.openedAt.Day));

            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
            string getterParam = item.link + " -filenameformat=temp_{0} " + JkTsGetter.Settings.Get().Config.GetterToolParam;
            if (isChase)
            {
                getterParam += " " + JkTsGetter.Settings.Get().Config.GetterToolParamChase;
                Console.WriteLine($"{item.title} の追っかけ再生コメントを取得しています");
            }
            else
            {
                Console.WriteLine($"{item.title} のタイムシフトコメントを取得しています");
            }
            var process = System.Diagnostics.Process.Start(@getterExePath, getterParam);
            process.WaitForExit();

            if (JkTsGetter.Settings.Get().Config.UseSaveToCache && !isChase)
            {
                if (cachePath.Contains(@"\"))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(cachePath));
                }

                if (!File.Exists(cachePath))
                {
                    Console.WriteLine($"キャッシュファイル {cachePath} を保存します");
                    File.Copy(tempFilePath, cachePath);
                }
            }

            return File.Exists(tempFilePath);
        }

        /// <summary>
        /// 指定チャンネル、指定日時のタイムシフトコメントを取得する
        /// </summary>
        /// <param name="jk"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public void GetTimeShiftComment(int jk, int year, int month, int day)
        {
            var channel = Channel.GetChannel(jk);

            var item = Util.GetTimeShiftItem(channel, year, month, day);

            if (item == null)
            {
                Console.WriteLine("この日のタイムシフトは見つかりませんでした");
                return;
            }

            switch (item.category)
            {
                case "past":
                    GetChannelLiveComment(channel, item);
                    break;

                case "current":
                    GetChannelLiveCommentChase(channel, item);
                    break;

                case "future":
                    Console.WriteLine("未来の生放送番組が指定されています");
                    break;
            }
        }

        /// <summary>
        /// ニコニコ実況過去ログAPIからコメントを取得する
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string GetOldNicoJKLog(Channel channel, DateTime start, DateTime end)
        {
            return GetOldNicoJKLog(channel.jk, start, end);
        }

        /// <summary>
        /// ニコニコ実況過去ログAPIからコメントを取得する
        /// </summary>
        /// <param name="jk"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string GetOldNicoJKLog(int jk, DateTime start, DateTime end)
        {
            Console.WriteLine($"ニコニコ実況過去ログAPIから取得します {start.ToString()} - {end.ToString()}");
            string url = String.Format(JkTsGetter.Settings.Get().Config.GetterOldLogApiUrl, jk, Util.DateTimeToUnixTimeStamp(start), Util.DateTimeToUnixTimeStamp(end));
            Console.WriteLine(url);
            var resText = Util.GetHttpGet(url);
            System.Threading.Thread.Sleep(500);
            var xdoc = XDocument.Parse(resText);
            if (xdoc.Root.Name == "error")
            {
                Console.WriteLine(xdoc.Root.Value);
                return "";
            }
            return resText;
        }

        public bool MergeCommentFile(string file1, string file2)
        {
            string outputFileName = Param.OutputFileName;
            if (string.IsNullOrEmpty(outputFileName))
            {
                outputFileName = Path.GetDirectoryName(file1) + @"\" + Path.GetFileNameWithoutExtension(file1) + "_merged.xml";
            }

            if (Directory.Exists(outputFileName))
            {
                Console.WriteLine($"{outputFileName} はフォルダとして存在しています。出力ファイル名にフォルダは指定できません");
                return false;
            }

            Console.WriteLine($"{file1} と {file2} をマージします");

            var doc1 = XDocument.Load(file1);
            var doc2 = XDocument.Load(file2);

            doc1.Root.Add(doc2.Root.Elements());

            long GetElementDate(XElement node)
            {
                long r = (long.Parse(node.Attribute("date")?.Value) * 1000000 + long.Parse(node.Attribute("date_usec")?.Value));
                return r;
            };
         
            var output = new XDocument(
                new XElement("Packet",
                    from node in doc1.Root.Elements("chat")
                    orderby (GetElementDate(node))
                    select node));

            if (outputFileName.Contains(@"\"))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputFileName));
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "";
            using (XmlWriter writer = XmlTextWriter.Create(outputFileName, settings))
            {
                output.Save(writer);
            }

            Console.WriteLine($"{outputFileName} に出力しました");

            return true;
        }
    }
}
