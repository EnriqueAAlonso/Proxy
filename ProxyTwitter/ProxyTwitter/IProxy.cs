using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
namespace ProxyTwitter
{
    
    interface IProxy
    {
         List<string> SearchTweets(string param, LanguageFilter lang, int quantity);
    }
}
