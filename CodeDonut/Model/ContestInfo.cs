using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CodeDonut
{
    public class ContestInfo
    {
        public string OJ { get; }
        public string Name { get; }
        public string StartTime { get; }
        public string Week { get; }
        public string Access { get; }
        public string Link { get; }

        public ContestInfo(string oj, string name, string startTime, string week, string access, string link)
        {
            OJ = oj;
            Name = name;
            StartTime = startTime;
            Week = week;
            Access = access;
            Link = link;
        }
        public class Fetcher
        {
            WebClient wc;
            public Fetcher()
            {
                wc = new WebClient();
                wc.Proxy = null;
                wc.Encoding = Encoding.UTF8;
            }

            ~Fetcher()
            {
                wc.Dispose();
            }

            public ContestInfo[] GetContestInfos()
            {
                try
                {
                    
                    string contestsJSON = GetContestsJSON();
                    JToken jToken = JToken.Parse(contestsJSON);

                    List<ContestInfo> contestInfoList = new List<ContestInfo>();
                    foreach (var item in jToken)
                    {
                        ContestInfo contestInfo = new ContestInfo(
                            item["oj"].ToString().Replace("\\/", "/"),
                            item["name"].ToString(),
                            item["start_time"].ToString(),
                            item["week"].ToString(),
                            item["access"].ToString(),
                            item["link"].ToString()) ;
                        contestInfoList.Add(contestInfo);
                    }

                    return contestInfoList.ToArray();

                }
                catch
                {
                    return new ContestInfo[] { new ContestInfo("", "Can not fetch contests info", "", "", "", "") };
                }
            }

            //源站太慢，因此做了反代加速
            private string GetContestsJSON()
            {
                return wc.DownloadString("http://contests.acmicpc.rainng.com/contests.json");
            }
        }

    }
}
