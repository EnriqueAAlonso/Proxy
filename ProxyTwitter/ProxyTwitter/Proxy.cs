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
        private string CKey= "pVgmQsf74J7G8QjNSez3VIkZL";
        private string CSecret= "Fc9Blt7gXaD3S5kfoHW8JY1j1LzQFkRlVagGwQmzbAGSFVCA6X";
        private string AToken= "2849067843-LybO7M8fBmrIQTbBrsd4lxVUqde2zqFUHGm9OTa";
        private string ATokenSecret= "R6A5irvmLAJdNfiiTWliEjzlMeIOA0BXHpfckzUTDNltm";

        public Proxy()
        {

            Auth.SetUserCredentials(this.CKey, this.CSecret, this.AToken, this.ATokenSecret);


        }

        public  List<string> SearchTweets(string param, LanguageFilter lang, int quantity)
        {
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
