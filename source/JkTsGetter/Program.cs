using MikLib.Util;
using System;
using System.Globalization;

namespace JkTsGetter
{
    class Program
    {
        const int DaysLimit = 62;

        public static DateTime ParseDateTime(string dateTimeStr)
        {
            DateTime result;
            if (dateTimeStr.Length == 14)
            {
                DateTime.TryParseExact(dateTimeStr, "yyyyMMddHHmmss", null, DateTimeStyles.AssumeLocal, out result);
                return result;
            }
            else
            {
                return Util.UnixTimeStampToDateTime(long.Parse(dateTimeStr));
            }
        }

        public static DateTime ParseDate(string dateStr)
        {
            DateTime result;
            DateTime.TryParseExact(dateStr, "yyyyMMdd", null, DateTimeStyles.AssumeLocal, out result);
            return result;
        }

        public static int ParseJkChannel(string jkStr)
        {
            if (jkStr.IndexOf("jk", StringComparison.OrdinalIgnoreCase) == 0)
            {
                jkStr = jkStr.Substring(2);
            }

            int.TryParse(jkStr, out int jk);
            return jk;
        }

        static int Main(string[] args)
        {
#if CATCH_EXCEPTION
            try
            {
#endif
                var getter = new JkTsGetter();
                // getter.GetTimeShiftComment(getter.GetChannel(1), 2020, 12, 17);
                // getter.Execute();
                // getter.ExecuteGetterTimeRange(getter.GetChannel(1), new DateTime(2020, 12, 17, 19, 00, 00), new DateTime(2020, 12, 17, 20, 00, 00));

                var argMap = new ArgumentMap();
                argMap.Init(args);

                if (args.Length == 0 || argMap.HasSwitch("-h") || argMap.HasSwitch("--help") || argMap.HasSwitch("-?"))
                {
                    System.Diagnostics.FileVersionInfo ver =
                        System.Diagnostics.FileVersionInfo.GetVersionInfo(
                        System.Reflection.Assembly.GetExecutingAssembly().Location);

                    Console.WriteLine($"{ver.ProductName} {ver.ProductVersion}");
                    Console.WriteLine("ニコニコ実況のニコ生、ニコニコ実況過去ログAPI から過去ログを取得するコマンドラインツール");
                    Console.WriteLine("https://github.com/sasukekinniku/JkTsGetter");
                    Console.WriteLine("");
                    Console.WriteLine("Usage:");
                    Console.WriteLine("  JkTsGetter チャンネル 取得開始日時 取得終了日時 [オプション...]");
                    Console.WriteLine("    指定チャンネルの過去ログを取得します。日時はUnix時間か、yyyymmddhhmmss の14桁で指定します");
                    Console.WriteLine("    チャンネルは jk1(NHK), jk2(Eテレ) などのように指定します。jkをつけずに 1, 2 などとしてもOKです");
                    Console.WriteLine("");
                    Console.WriteLine("  JkTsGetter チャンネル 取得年月日 -ts [オプション...]");
                    Console.WriteLine("    指定チャンネル、指定日1日分(午前4時区切り)のニコ生タイムシフトコメントを取得します。年月日は yyyymmdd の8桁で指定します");
                    Console.WriteLine("");
                    Console.WriteLine("  JkTsGetter -all [オプション...]");
                    Console.WriteLine("    取得可能なすべての実況公式ニコ生タイムシフトを取得します");
                    Console.WriteLine("");
                    Console.WriteLine("  JkTsGetter -all -cache [オプション...]");
                    Console.WriteLine("    取得可能なすべての実況公式ニコ生タイムシフトを取得します (ini で指定したキャッシュフォルダに保存、上書きしない)");
                    Console.WriteLine("");
                    Console.WriteLine("  JkTsGetter tsファイル [オプション...]");
                    Console.WriteLine("    tsファイルからチャンネル、開始時間、終了時間を取得して過去ログを取得します");
                    Console.WriteLine("");
                    Console.WriteLine("  JkTsGetter xmlファイル1 xmlファイル2 -merge [オプション...]");
                    Console.WriteLine("    2つのコメントxmlファイルを、1つのファイルにマージします");
                    Console.WriteLine("");
                    Console.WriteLine("  ※タイムシフトの取得には、ニコ生新配信録画ツールが必要です");
                    Console.WriteLine("  ※タイムシフト、追っかけ再生を取得するには、ニコニコプレミアムや事前のタイムシフト予約が必要です");
                    Console.WriteLine("");
                    Console.WriteLine("Option:");
                    Console.WriteLine("  -ts       指定チャンネルの特定日のコメントをすべて取得する");
                    Console.WriteLine("  -all      取得可能なすべての実況ニコ生コメントを取得する");
                    Console.WriteLine("  -m 秒     取得日時の前後を指定秒だけ広げる");
                    Console.WriteLine("  -s 秒     取得開始日時の前後を指定秒だけ広げる");
                    Console.WriteLine("  -e 秒     取得終了日時の前後を指定秒だけ広げる");
                    Console.WriteLine("  -f フォルダ/ファイルパス");
                    Console.WriteLine("            出力する場所やファイル名を指定する");
                    Console.WriteLine("  -d        チャンネル名と同じ名前のサブフォルダを作成し、その中に保存する");
                    Console.WriteLine("  -v        保存したいファイルと同名のファイルがある場合に上書きしない");
                    Console.WriteLine("  -old      日時にかかわらず、つねにニコニコ実況過去ログAPIから取りに行く");
                    Console.WriteLine("");
                    Console.WriteLine("チャンネルリスト:");
                    foreach (var ch in Channel.Channels)
                    {
                        if (ch.ch > 0)
                        {
                            Console.WriteLine($"  * jk{ch.jk} : {ch.name} (ch{ch.ch})");
                        }
                    }

                    return 0;
                }

                getter.Param.OutputFileName = argMap.GetOption("-f")?.Trim('\"');
                getter.Param.CreateDirectory = argMap.HasSwitch("-d");
                getter.Param.OverWrite = !argMap.HasSwitch("-v");
                getter.Param.AlwaysOldApi = argMap.HasSwitch("-old");

                if (argMap.HasSwitch("-all"))
                {
                    getter.ExecuteAllTsGet(argMap.HasSwitch("-cache"));
                }
            else if (argMap.HasSwitch("-ts"))
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("パラメーター指定が正しくありません");
                    return -1;
                }

                var jk = ParseJkChannel(args[0]);
                var date = ParseDate(args[1]);

                if (jk <= 0 || jk > 10000)
                {
                    Console.WriteLine("チャンネル指定が正しくありません");
                    return -1;
                }

                if (date < JkTsGetter.NewJkStartDateTime || date.Year > 2099)
                {
                    Console.WriteLine("日時が正しくありません (-ts モードでは取得する日付を yyyymmdd 形式の8桁で指定してください)");
                    return -1;
                }

                getter.GetTimeShiftComment(jk, date.Year, date.Month, date.Day);
            }
            else if (argMap.HasSwitch("-merge"))
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("パラメーター指定が正しくありません");
                    return -1;
                }

                var mergeFile1 = args[0]?.Trim('\"');
                var mergeFile2 = args[1]?.Trim('\"');

                return getter.MergeCommentFile(mergeFile1, mergeFile2) ? 0 : -1;
            }
            else if (System.IO.File.Exists(args[0]) && args[0].ToLower().EndsWith(".ts"))
                {
                    var fileName = args[0]?.Trim('\"');
                    Console.WriteLine("tsファイルから番組情報を読み取ります");
                    Common.TsAnalyzer.GetTsFileInfo(fileName, out int jk, out DateTime? startTime, out DateTime? endTime);
                    if (jk == 0)
                    {
                        Console.WriteLine("チャンネルを特定できませんでした");
                        return -1;
                    }
                    if (startTime == null)
                    {
                        Console.WriteLine("開始日時を特定できませんでした");
                        return -1;
                    }

                    TimeSpan span = endTime.Value - startTime.Value;
                    Console.WriteLine($"チャンネル:{jk}, {startTime.Value.ToString()} - {endTime.Value.ToString()}");

                    if (jk <= 0 || jk > 10000)
                    {
                        Console.WriteLine("チャンネル指定が正しくありません");
                        return -1;
                    }
                    if (endTime < startTime)
                    {
                        Console.WriteLine("日時がうまく特定できず、終了日時が開始日時よりも先になってしまいました");
                        return -1;
                    }
                    if (span.TotalDays > DaysLimit)
                    {
                        Console.WriteLine($"日時がうまく特定できず、{DaysLimit}日以上の長期間指定になってしまいました");
                        return -1;
                    }
                    if (string.IsNullOrEmpty(getter.Param.OutputFileName))
                    {
                        getter.Param.OutputFileName = System.IO.Path.ChangeExtension(fileName, "xml");
                    }

                    getter.ExecuteGetterTimeRange(jk, startTime.Value, endTime.Value);
                }
                else
                {
                    if (args.Length < 3)
                    {
                        Console.WriteLine("パラメーター指定が正しくありません");
                        return -1;
                    }

                    var jk = ParseJkChannel(args[0]);
                    var startTime = ParseDateTime(args[1]);
                    var endTime = ParseDateTime(args[2]);

                    int startMargin = argMap.GetOptionInt("-m", 0);
                    int endMargin = argMap.GetOptionInt("-m", 0);
                    startMargin = argMap.GetOptionInt("-s", startMargin);
                    endMargin = argMap.GetOptionInt("-e", endMargin);
                    startTime.AddSeconds(-startMargin);
                    endTime.AddSeconds(endMargin);

                    TimeSpan span = endTime - startTime;

                    if (jk <= 0 || jk > 10000)
                    {
                        Console.WriteLine("チャンネル指定が正しくありません");
                        return -1;
                    }
                    if (endTime < startTime)
                    {
                        Console.WriteLine("終了日時が開始日時よりも先になっています");
                        return -1;
                    }
                    if (span.TotalDays > DaysLimit)
                    {
                        Console.WriteLine($"{DaysLimit}日以上の長期間指定はできません。62日以内にしてください");
                        return -1;
                    }

                    getter.ExecuteGetterTimeRange(jk, startTime, endTime);
                }
                return 0;
#if CATCH_EXCEPTION
            }
            catch (Exception e)
            {
                Console.WriteLine($"エラー {e.GetType().FullName} が {e.TargetSite} で発生しました。");
                Console.WriteLine(e.Message);
                Console.WriteLine("スタックトレース :");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("");
                Console.WriteLine("処理を中断します");

                return -1;
            }
#endif
        }
    }
}
