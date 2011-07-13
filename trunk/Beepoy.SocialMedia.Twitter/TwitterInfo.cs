using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetSharp;

namespace Beepoy.SocialMedia.Twitter
{
    public class TwitterInfo
    {
        private readonly string _hero;
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public TwitterInfo()
        {
            //_hero = ConfigurationManager.AppSettings["Hero"];
            //_consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            //_consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            //_accessToken = ConfigurationManager.AppSettings["AccessToken"];
            //_accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
        }

        public static void Hello()
        {
            TwitterService service = new TwitterService();
            IEnumerable<TwitterStatus> tweets = service.ListTweetsOnPublicTimeline();
            foreach (var tweet in tweets)
            {
                Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
            }
        }
    }
}
