using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Telegram_Bot_Test
{
    class AnekdotParsing
    {
        /**
         * Load webpage
         * 
         */
        public static string LoadPage(string url) 
        {
            try
            {
                var result = string.Empty;
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    if (receiveStream != null)
                    {
                        StreamReader readStream;
                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        result = readStream.ReadToEnd();
                        readStream.Close();
                    }

                    response.Close();
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string[] ParseData(string page)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(page);
            //var moviesItemsLinq = document.All.Where(m => m.LocalName == "div" && m.Id != "anekdot-content");
            var moviesItemsLinq = document.QuerySelectorAll("div.anekdot-content");

            List<string> words = new List<string>();

            foreach (var emp in moviesItemsLinq)
            {
                string d = emp.InnerHtml;
                d = d.Replace("&nbsp;", string.Empty);
                d = d.Replace("<br>", "\n");

                d = Regex.Replace(d, @"\<.*?\>", "");
                d = Regex.Replace(d, @"\s{2,}", " ");
                /*string[] w = d.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string s = string.Empty;
                for (int i = 1; i < w.Count(); i++)
                {
                    s += w[i] + " ";
                }
                
                words.Add(s);*/
                words.Add(d);
            }

            return words.ToArray();
        }

    }
}
