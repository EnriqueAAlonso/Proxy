using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace ProxyTwitter
{
    public class Proxy:IProxy
    {
        private string CKey= "";
        private string CSecret= "";
        private string AToken= "";
        private string ATokenSecret= "";

        public Proxy()
        {
            


        }

        public  List<string> SearchTweets(string param, LanguageFilter lang, int quantity)
        {
            Auth.SetUserCredentials(this.CKey, this.CSecret, this.AToken, this.ATokenSecret);
            List<string> tweets=new List<string>();

            var searchParameter = new SearchTweetsParameters(param)
            {
                
                Lang = lang,
                SearchType = SearchResultType.Recent,
                MaximumNumberOfResults = quantity

            };

            var results = Search.SearchTweets(searchParameter);
            foreach (var line in results)
            {
                tweets.Add("\n"+"START OF TWEET " + "\n" + line.Text + "\n" + " END OF TWEET" +"\n");

            }

            return tweets;


        }


    }
}
