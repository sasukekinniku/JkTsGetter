using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Net;
using System.IO;
using System.Text.Json;

namespace JkTsGetter
{
    static public class Util
    {
        /// <summary>
        /// Unix時間をDateTimeに変換
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        /// <summary>
        /// DateTimeをUnix時間に変換
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static int DateTimeToUnixTimeStamp(DateTime timeStamp)
        {
            // https://qiita.com/syantien/items/a9b90cdd382d93d7520d
            var unixTimestamp = (int)(timeStamp.AddHours(-9).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }

        /// <summary>
        /// httpからStringで取得
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHttpGet(string url)
        {
            int errorCount = 0;
            string resText = "";

            try
            {
                var request = HttpWebRequest.Create(url);
                request.Timeout = 15000;
                var response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                if (stream != null)
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    resText = reader.ReadToEnd();
                    stream.Close();
                }
                response.Close();
            }
            catch (System.Net.WebException WebException)
            {
                Console.WriteLine($"通信エラーが発生しました ({WebException.Message})。リトライします({errorCount + 1}/3)。");
                if (++errorCount > 3)
                {
                    throw (WebException);
                }
                System.Threading.Thread.Sleep(3000);
            }

            return resText;
        }

        /// <summary>
        /// 指定日時の生放送情報を取得する
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static ChannelLiveInfo.Item GetTimeShiftItem(Channel channel, int year, int month, int day)
        {
            var info = GetChannelLiveInfo(channel);
            var item = (from x in info.data.items
                        where x.openedAt.Year == year && x.openedAt.Month == month && x.openedAt.Day == day
                        select x).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// チャンネルの生放送情報を取得
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static ChannelLiveInfo GetChannelLiveInfo(Channel channel)
        {
            var resText = Util.GetHttpGet($"https://public.api.nicovideo.jp/v1/channel/channelapp/content/lives.json?page=1&channelId={channel.ch}");
            return JsonSerializer.Deserialize<ChannelLiveInfo>(resText);
        }
    }

    /// <summary>
    /// ニコニコのAPIから取得するチャンネル生放送情報
    /// </summary>
    public class ChannelLiveInfo
    {
        public class Meta
        {
            public int status { get; set; }
        }

        public class Data
        {
            public string link { get; set; }
            public string guid { get; set; }
            public DateTimeOffset lastPublishedAt { get; set; }
            public Item[] items { get; set; }
        }

        public class Item
        {
            public int id { get; set; }
            public string title { get; set; }
            public string link { get; set; }
            public string description { get; set; }
            public string thumbnailUrl { get; set; }
            public bool isPpv { get; set; }
            public bool isMemberOnly { get; set; }
            public string category { get; set; }
            public DateTimeOffset publishedAt { get; set; }
            public DateTimeOffset openedAt { get; set; }
            public DateTimeOffset beginAt { get; set; }
            public DateTimeOffset endAt { get; set; }

            [JsonIgnore]
            public int liveId
            {
                get
                {
                    var pos = link.IndexOf("/watch/");
                    if (pos < 0) { return -1; }
                    string idString = link.Substring(pos + "/watch/lv".Length);
                    return int.TryParse(idString, out int result) ? result : 0;
                }
            }
        }

        public Meta meta { get; set; }
        public Data data { get; set; }
    }

    /// <summary>
    /// チャンネル情報
    /// </summary>
    public struct Channel
    {
        /// <summary>
        /// 新ニコニコ実況のチャンネル定義
        /// </summary>
        public static readonly Channel[] Channels = new Channel[]
        {
            new Channel { name = "NHK総合", ch = 2646436, jk = 1 },
            new Channel { name = "NHK Eテレ", ch = 2646437, jk = 2 },
            new Channel { name = "日本テレビ", ch = 2646438, jk = 4 },
            new Channel { name = "テレビ朝日", ch = 2646439, jk = 5 },
            new Channel { name = "TBSテレビ", ch = 2646440, jk = 6 },
            new Channel { name = "テレビ東京", ch = 2646441, jk = 7 },
            new Channel { name = "フジテレビ", ch = 2646442, jk = 8 },
            new Channel { name = "TOKYO MX", ch = 2646485, jk = 9 },
            new Channel { name = "BS11", ch = 2646846, jk = 211 },
            new Channel { name = "テレ玉", ch = 0, jk = 10 },
            new Channel { name = "tvk", ch = 0, jk = 11 },
            new Channel { name = "チバテレビ", ch = 0, jk = 12 },
            new Channel { name = "NHKBS-1", ch = 0, jk = 101 },
            new Channel { name = "NHK BSプレミアム", ch = 0, jk = 103 },
            new Channel { name = "BS 日テレ", ch = 0, jk = 141 },
            new Channel { name = "BS 朝日", ch = 0, jk = 151 },
            new Channel { name = "BS-TBS", ch = 0, jk = 161 },
            new Channel { name = "BSジャパン", ch = 0, jk = 171 },
            new Channel { name = "BSフジ", ch = 0, jk = 181 },
            new Channel { name = "WOWOWプライム", ch = 0, jk = 191 },
            new Channel { name = "WOWOWライブ", ch = 0, jk = 192 },
            new Channel { name = "WOWOWシネマ", ch = 0, jk = 193 },
            new Channel { name = "スターチャンネル1", ch = 0, jk = 200 },
            new Channel { name = "スターチャンネル2", ch = 0, jk = 201 },
            new Channel { name = "スターチャンネル3", ch = 0, jk = 202 },
            new Channel { name = "TwellV", ch = 0, jk = 222 },
            new Channel { name = "放送大学", ch = 0, jk = 231 },
            new Channel { name = "BSグリーンチャンネル", ch = 0, jk = 234 },
            new Channel { name = "BSアニマックス", ch = 0, jk = 236 },
            new Channel { name = "FOX bs 238", ch = 0, jk = 238 },
            new Channel { name = "BSスカパー!", ch = 0, jk = 241 },
            new Channel { name = "J Sports 1", ch = 0, jk = 242 },
            new Channel { name = "J Sports 2", ch = 0, jk = 243 },
            new Channel { name = "J Sports 3", ch = 0, jk = 244 },
            new Channel { name = "J Sports 4", ch = 0, jk = 245 },
            new Channel { name = "BS釣りビジョン", ch = 0, jk = 251 },
            new Channel { name = "IMAGICA BS", ch = 0, jk = 252 },
            new Channel { name = "BS日本映画専門チャンネル", ch = 0, jk = 255 },
            new Channel { name = "ディズニー・チャンネル", ch = 0, jk = 256 },
            new Channel { name = "Dlife", ch = 0, jk = 258 },
            new Channel { name = "SOLiVE24", ch = 0, jk = 910 },
            new Channel { name = "NHKラジオ第1", ch = 0, jk = 594 },
            new Channel { name = "NHKラジオ第2", ch = 0, jk = 693 },
            new Channel { name = "NHK-FM", ch = 0, jk = 825 },
            new Channel { name = "AIR-G'", ch = 0, jk = 792 },
            new Channel { name = "HBCラジオ", ch = 0, jk = 1287 },
            new Channel { name = "STVラジオ", ch = 0, jk = 1440 },
            new Channel { name = "ラジオNIKKEI第1放送", ch = 0, jk = 3925 },
            new Channel { name = "Inter FM", ch = 0, jk = 761 },
            new Channel { name = "TOKYO FM", ch = 0, jk = 800 },
            new Channel { name = "J-WAVE", ch = 0, jk = 813 },
            new Channel { name = "TBSラジオ", ch = 0, jk = 954 },
            new Channel { name = "文化放送", ch = 0, jk = 1134 },
            new Channel { name = "茨城放送", ch = 0, jk = 1197 },
            new Channel { name = "ニッポン放送", ch = 0, jk = 1242 },
            new Channel { name = "RADIO BERRY", ch = 0, jk = 764 },
            new Channel { name = "FMぐんま", ch = 0, jk = 863 },
            new Channel { name = "bayfm", ch = 0, jk = 780 },
            new Channel { name = "NACK5", ch = 0, jk = 795 },
            new Channel { name = "FMヨコハマ", ch = 0, jk = 847 },
            new Channel { name = "ラジオ日本", ch = 0, jk = 1422 },
            new Channel { name = "ZIP-FM", ch = 0, jk = 778 },
            new Channel { name = "FM AICHI", ch = 0, jk = 807 },
            new Channel { name = "CBCラジオ", ch = 0, jk = 1053 },
            new Channel { name = "東海ラジオ", ch = 0, jk = 1332 },
            new Channel { name = "ぎふチャン", ch = 0, jk = 1431 },
            new Channel { name = "radio CUBE FM三重", ch = 0, jk = 789 },
            new Channel { name = "FM COCOLO", ch = 0, jk = 765 },
            new Channel { name = "FM802", ch = 0, jk = 802 },
            new Channel { name = "FM OSAKA", ch = 0, jk = 851 },
            new Channel { name = "Kiss FM KOBE", ch = 0, jk = 899 },
            new Channel { name = "朝日放送", ch = 0, jk = 1008 },
            new Channel { name = "毎日放送", ch = 0, jk = 1179 },
            new Channel { name = "ラジオ大阪", ch = 0, jk = 1314 },
            new Channel { name = "KBS京都", ch = 0, jk = 1143 },
            new Channel { name = "ラジオ関西", ch = 0, jk = 558 },
            new Channel { name = "和歌山放送", ch = 0, jk = 1557 },
            new Channel { name = "FM FUKUOKA", ch = 0, jk = 808 },
            new Channel { name = "Love FM", ch = 0, jk = 827 },
            new Channel { name = "RKBラジオ", ch = 0, jk = 1278 },
            new Channel { name = "九州朝日放送", ch = 0, jk = 1413 },
        };
        
        public string name { get; set; }
        public int ch { get; set; }
        public int jk { get; set; }

        /// <summary>
        /// jkチャンネル番号から Channel を取得
        /// </summary>
        /// <param name="jk"></param>
        /// <returns></returns>
        public static Channel GetChannel(int jk)
        {
            var channel = (from x in Channels
                           where x.jk == jk
                           select x).FirstOrDefault();

            return channel;
        }

        public static int GetIndex(int jk)
        {
            return Array.IndexOf(Channels, GetChannel(jk));
        }
    };
}
