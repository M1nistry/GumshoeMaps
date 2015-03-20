using System;
using System.Net;
using System.Web.Script.Serialization;

namespace Gumshoe_Maps
{
    class JsonHandler
    {
        //All Ladders currently running
        public static T ParseJson<T>(String json)
        {
            string webPage = DownloadUrl(json);

            if (webPage != null)
            {
                try
                {
                    var poeLadderAll = new JavaScriptSerializer().Deserialize<T>(webPage);

                    return poeLadderAll;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    return default(T);
                }
            }
            return default(T);
        }

        //Download provided URL and return as String
        private static String DownloadUrl(String url)
        {
            var webReqeust = new WebClient();

            try
            {
                return webReqeust.DownloadString(url);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
