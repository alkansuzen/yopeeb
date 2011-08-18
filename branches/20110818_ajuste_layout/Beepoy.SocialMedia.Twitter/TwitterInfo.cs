using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetSharp;

namespace Beepoy.SocialMedia.Twitter
{
    public class TwitterInfo
    {
        private readonly string ConsumerKey;
        private readonly string ConsumerSecret;
        private readonly string AccessToken;
        private readonly string AccessTokenSecret;

        public TwitterInfo()
        {
            ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
        }
    }
}
