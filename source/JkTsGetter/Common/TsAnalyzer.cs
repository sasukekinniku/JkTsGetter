using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JkTsGetter.Common
{
    class TsAnalyzer
    {
        private static readonly Dictionary<uint, int> ntsIdList = new Dictionary<uint, int>()
        {
            { 0x0065, 101 },
            { 0x0066, 101 },
            { 0x0067, 103 },
            { 0x0068, 103 },
            { 0x008D, 141 },
            { 0x008E, 141 },
            { 0x008F, 141 },
            { 0x0097, 151 },
            { 0x0098, 151 },
            { 0x0099, 151 },
            { 0x00A1, 161 },
            { 0x00A2, 161 },
            { 0x00A3, 161 },
            { 0x00AB, 171 },
            { 0x00AC, 171 },
            { 0x00AD, 171 },
            { 0x00B5, 181 },
            { 0x00B6, 181 },
            { 0x00B7, 181 },
            { 0x00BF, 191 },
            { 0x00C0, 192 },
            { 0x00C1, 193 },
            { 0x00C8, 200 },
            { 0x00C9, 201 },
            { 0x00CA, 202 },
            { 0x00D3, 211 },
            { 0x00DE, 222 },
            { 0x00E7, 231 },
            { 0x00E8, 231 },
            { 0x00E9, 231 },
            { 0x00EA, 234 },
            { 0x00EC, 236 },
            { 0x00EE, 238 },
            { 0x00F1, 241 },
            { 0x00F2, 242 },
            { 0x00F3, 243 },
            { 0x00F4, 244 },
            { 0x00F5, 245 },
            { 0x00FB, 251 },
            { 0x00FC, 252 },
            { 0x00FF, 255 },
            { 0x0100, 256 },
            { 0x0102, 258 },
            { 0x038E, 910 },
            { 0x0400, 1 },
            { 0x0408, 2 },
            { 0x0410, 4 },
            { 0x0418, 6 },
            { 0x0420, 8 },
            { 0x0428, 5 },
            { 0x0430, 7 },
            { 0x0440, 231 },
            { 0x0808, 2 },
            { 0x0810, 6 },
            { 0x0818, 5 },
            { 0x0820, 8 },
            { 0x0828, 4 },
            { 0x0C08, 2 },
            { 0x0C10, 8 },
            { 0x0C18, 6 },
            { 0x0C20, 5 },
            { 0x0C28, 4 },
            { 0x1010, 6 },
            { 0x1018, 4 },
            { 0x1020, 5 },
            { 0x1028, 8 },
            { 0x1030, 7 },
            { 0x1410, 4 },
            { 0x1418, 5 },
            { 0x1420, 6 },
            { 0x1428, 7 },
            { 0x1430, 8 },
            { 0x1810, 8 },
            { 0x1818, 6 },
            { 0x1820, 4 },
            { 0x2800, 1 },
            { 0x2808, 2 },
            { 0x2810, 6 },
            { 0x2818, 4 },
            { 0x2820, 5 },
            { 0x2828, 8 },
            { 0x2830, 7 },
            { 0x2C00, 1 },
            { 0x2C08, 2 },
            { 0x2C10, 6 },
            { 0x2C18, 4 },
            { 0x2C20, 5 },
            { 0x2C28, 8 },
            { 0x2C30, 7 },
            { 0x3000, 1 },
            { 0x3008, 2 },
            { 0x3010, 6 },
            { 0x3018, 4 },
            { 0x3020, 5 },
            { 0x3028, 8 },
            { 0x3030, 7 },
            { 0x3400, 1 },
            { 0x3408, 2 },
            { 0x3410, 6 },
            { 0x3418, 4 },
            { 0x3420, 5 },
            { 0x3428, 8 },
            { 0x3430, 7 },
            { 0x3800, 1 },
            { 0x3808, 2 },
            { 0x3810, 6 },
            { 0x3818, 4 },
            { 0x3820, 5 },
            { 0x3828, 8 },
            { 0x3830, 7 },
            { 0x3C00, 1 },
            { 0x3C08, 2 },
            { 0x3C10, 6 },
            { 0x3C18, 4 },
            { 0x3C20, 5 },
            { 0x3C28, 8 },
            { 0x3C30, 7 },
            { 0x4000, 1 },
            { 0x4008, 2 },
            { 0x4010, 6 },
            { 0x4018, 4 },
            { 0x4020, 5 },
            { 0x4028, 8 },
            { 0x4030, 7 },
            { 0x4400, 1 },
            { 0x4408, 2 },
            { 0x4410, 6 },
            { 0x4418, 8 },
            { 0x4420, 4 },
            { 0x4428, 5 },
            { 0x4800, 1 },
            { 0x4808, 2 },
            { 0x4810, 4 },
            { 0x4818, 8 },
            { 0x4820, 5 },
            { 0x4C00, 1 },
            { 0x4C08, 2 },
            { 0x4C10, 4 },
            { 0x4C18, 5 },
            { 0x4C20, 6 },
            { 0x4C28, 8 },
            { 0x5000, 1 },
            { 0x5008, 2 },
            { 0x5010, 6 },
            { 0x5018, 4 },
            { 0x5020, 8 },
            { 0x5028, 5 },
            { 0x5400, 1 },
            { 0x5408, 2 },
            { 0x5410, 8 },
            { 0x5418, 4 },
            { 0x5420, 5 },
            { 0x5428, 6 },
            { 0x5800, 1 },
            { 0x5808, 2 },
            { 0x5810, 4 },
            { 0x5818, 6 },
            { 0x5820, 5 },
            { 0x5C38, 9 },
            { 0x6038, 11 },
            { 0x6400, 1 },
            { 0x6800, 1 },
            { 0x6C38, 12 },
            { 0x7000, 1 },
            { 0x7438, 10 },
            { 0x7800, 1 },
            { 0x7808, 2 },
            { 0x7810, 4 },
            { 0x7818, 5 },
            { 0x7820, 6 },
            { 0x7828, 8 },
            { 0x7C00, 1 },
            { 0x7C08, 2 },
            { 0x7C10, 6 },
            { 0x7C18, 8 },
            { 0x7C20, 4 },
            { 0x7C28, 5 },
            { 0x8000, 1 },
            { 0x8008, 2 },
            { 0x8010, 4 },
            { 0x8018, 6 },
            { 0x8400, 1 },
            { 0x8430, 7 },
            { 0x8800, 1 },
            { 0x8808, 2 },
            { 0x8810, 4 },
            { 0x8818, 5 },
            { 0x8820, 6 },
            { 0x8828, 8 },
            { 0x8C00, 1 },
            { 0x8C08, 2 },
            { 0x8C10, 6 },
            { 0x8C18, 8 },
            { 0x8C20, 4 },
            { 0x8C28, 5 },
            { 0x9000, 1 },
            { 0x9008, 2 },
            { 0x9010, 4 },
            { 0x9018, 8 },
            { 0x9400, 1 },
            { 0x9408, 2 },
            { 0x9410, 4 },
            { 0x9418, 8 },
            { 0x9420, 6 },
            { 0x9800, 1 },
            { 0x9C00, 1 },
            { 0xA000, 1 },
            { 0xA030, 7 },
            { 0xA400, 1 },
            { 0xA800, 1 },
            { 0xAC00, 1 },
            { 0xB000, 1 },
            { 0xB400, 1 },
            { 0xB800, 1 },
            { 0xB808, 2 },
            { 0xB810, 6 },
            { 0xB818, 4 },
            { 0xB820, 5 },
            { 0xB828, 8 },
            { 0xBC00, 1 },
            { 0xBC08, 2 },
            { 0xC000, 1 },
            { 0xC008, 2 },
            { 0xC400, 1 },
            { 0xC408, 2 },
            { 0xC800, 1 },
            { 0xC808, 2 },
            { 0xC810, 4 },
            { 0xC818, 6 },
            { 0xC820, 5 },
            { 0xCC00, 1 },
            { 0xCC08, 2 },
            { 0xCC10, 4 },
            { 0xCC18, 5 },
            { 0xCC20, 6 },
            { 0xCC28, 8 },
            { 0xD000, 1 },
            { 0xD008, 2 },
            { 0xD400, 1 },
            { 0xD408, 2 },
            { 0xD410, 4 },
            { 0xD800, 1 },
            { 0xD808, 2 },
            { 0xD810, 4 },
            { 0xD818, 6 },
            { 0xD820, 8 },
            { 0xDC00, 1 },
            { 0xDC08, 2 },
            { 0xDC10, 5 },
            { 0xDC18, 6 },
            { 0xDC20, 4 },
            { 0xDC28, 7 },
            { 0xDC30, 8 },
            { 0xDE00, 1 },
            { 0xDE08, 2 },
            { 0xE000, 1 },
            { 0xE008, 2 },
            { 0xE010, 6 },
            { 0xE018, 8 },
            { 0xE020, 4 },
            { 0xE028, 5 },
            { 0xE400, 1 },
            { 0xE408, 2 },
            { 0xE410, 6 },
            { 0xE418, 8 },
            { 0xE420, 5 },
            { 0xE428, 4 },
            { 0xE800, 1 },
            { 0xE808, 2 },
            { 0xE810, 6 },
            { 0xE818, 8 },
            { 0xE820, 5 },
            { 0xE828, 4 },
            { 0xEC00, 1 },
            { 0xEC08, 2 },
            { 0xEC10, 6 },
            { 0xEC18, 8 },
            { 0xF000, 1 },
            { 0xF008, 2 },
            { 0xF010, 6 },
            { 0xF018, 4 },
            { 0xF020, 5 },
            { 0xF400, 1 },
            { 0xF408, 2 },
            { 0xF410, 8 },
            { 0xF800, 1 },
            { 0xF808, 2 },
            { 0xF810, 6 },
            { 0xF820, 5 },
            { 0xF838, 8 },
         };


        class FileReader
        {
            FileStream fs;

            public void Open(string fileName)
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }

            public long Length { get { return fs.Length; } }

            public byte Get(long offset)
            {
                byte[] data = new byte[1];
                data = Get(offset, 1);
                return data[0];
            }

            public byte[] Get(long offset, int size)
            {
                byte[] data = new byte[size];
                fs.Seek(offset, SeekOrigin.Begin);
                fs.Read(data, 0, size);
                return data;
            }
        }

        public static void AnalyzeTsFile(string fileName, out int jk, out DateTime? startTime)
        {
            startTime = null;
            var fr = new FileReader();
            fr.Open(fileName);
            var size = fr.Length;

            var pos = 0;
            var pids = new Dictionary<int, int>();
            jk = 0;

            while (pos < size && (startTime == null || jk == 0))
            {
                // いくらなんでも探しすぎ
                if (pos > 0x1000000)
                {
                    break;
                }

                // sync
                if (fr.Get(pos) != 0x47 || fr.Get(pos + 188) != 0x47)
                {
                    ++pos;
                    continue;
                }

                // PID
                var pid = (fr.Get(pos + 1) * 256 + fr.Get(pos + 2)) & 0x1FFF;
                var payloadStart = fr.Get(pos + 1) & 0x40;
                if (!pids.ContainsKey(pid))
                {
                    pids[pid] = 0;
                }
                pids[pid] = (pids[pid]) + 1;

                // PAT
                if (pid == 0x00)
                {
                    byte[] p = fr.Get(pos, 188);
                    byte adaptSize = p[4];

                    long length = (p[adaptSize + 6] * 256 + p[adaptSize + 7]) & 0x0FFF;

                    for (var i = 13 + adaptSize; i < 5 + length - 4 - adaptSize; i += 4)
                    {
                        uint sid = (uint)(p[i] * 256 + p[i + 1]);
                        if (sid > 0)
                        {
                            if (ntsIdList.ContainsKey(sid))
                            {
                                jk = ntsIdList[sid];
                            }
                        }
                    }
                }

                // TDT/TOT
                if (pid == 0x14)
                {
                    byte[] p = fr.Get(pos, 188);
                    var adaptSize = p[4];
                    if (p[adaptSize + 5] == 0x70 || p[adaptSize + 5] == 0x73)
                    {
                        var ymd = p[adaptSize + 8] * 256 + p[adaptSize + 9];
                        var ydash = (ymd * 20 - 301564) / 7305;
                        var mdash = (ymd * 10000 - 149561000 - ydash * 1461 / 4 * 10000) / 306001;
                        var d = (mdash == 14 || mdash == 15) ? 1 : 0;
                        var day = ymd - 14956 - (ydash * 1461 / 4) - (mdash * 306001 / 10000);
                        var year = (ydash + d) + 1900;
                        var month = (int)Math.Floor(mdash - 1 - d * 12.0);
                        var date = new DateTime(year, month, day, int.Parse($"{p[adaptSize + 10]:x2}"), int.Parse($"{p[adaptSize + 11]:x2}"), int.Parse($"{p[adaptSize + 12]:x2}"));
                        if (startTime == null)
                        {
                            // if (date.Second > 10)
                            // {
                            // 録画マージンを考慮して調整する（50秒まで）
                            // date = date.AddMinutes(1);
                            // }
                            startTime = date;
                        }
                    }
                }

                pos += 188;
            }
        }

        public static void GetTsFileInfo(string fileName, out int jk, out DateTime? startTime, out DateTime? endTime)
        {
            AnalyzeTsFile(fileName, out jk, out startTime);
            endTime = File.GetLastWriteTime(fileName);
        }
    }
}
