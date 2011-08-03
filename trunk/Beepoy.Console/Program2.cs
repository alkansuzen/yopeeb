using System;
using System.Configuration;
using System.Diagnostics;
using TweetSharp;
using TweetSharp.Model;

namespace Beepoy.ConsoleApp
{

    class Program2
    {
        static void Main(string[] args)
        {
            TwitterClientInfo twitterClientInfo = new TwitterClientInfo();
            twitterClientInfo.ConsumerKey = ConsumerKey; //Read ConsumerKey out of the app.config
            twitterClientInfo.ConsumerSecret = ConsumerSecret; //Read the ConsumerSecret out the app.config

            string token = AccessToken;
            string tokenSecret = AccessTokenSecret;

            TwitterService twitterService = new TwitterService(twitterClientInfo);

            if (string.IsNullOrEmpty(AccessToken) || string.IsNullOrEmpty(AccessTokenSecret))
            {
                //Now we need the Token and TokenSecret
                //Firstly we need the RequestToken and the AuthorisationUrl
                OAuthRequestToken requestToken = twitterService.GetRequestToken();
                string authUrl = twitterService.GetAuthorizationUri(requestToken).AbsoluteUri;

                //authUrl is just a URL we can open IE and paste it in if we want
                Console.WriteLine("Please Allow This App to send Tweets on your behalf");
                Process.Start(authUrl); //Launches a browser that'll go to the AuthUrl.

                //Allow the App
                Console.WriteLine("Enter the PIN from the Browser:");

                string pin = Console.ReadLine();

                OAuthAccessToken accessToken = twitterService.GetAccessToken(requestToken, pin);

                token = accessToken.Token;
                tokenSecret = accessToken.TokenSecret;

                Console.WriteLine("AccessToken: " + token);
                Console.WriteLine("AccessTokenSecret: " + tokenSecret);
            }

            //twitterService.AuthenticateWith(AccessToken, AccessTokenSecret);
            twitterService.AuthenticateWith(token, tokenSecret);

            twitterService.SendTweet("tweet or beep ?");
            twitterService.SendTweet("beep or tweet ?");

            Console.WriteLine("Enter a Tweet");

            string tweetMessage;

            while (true)
            {
                tweetMessage = Console.ReadLine();

                if (tweetMessage.ToLower() == "exit")
                    break;

                twitterService.SendTweet(tweetMessage);
            }
        }


        #region ConsumerKey & ConsumerSecret

        private static string ConsumerSecret
        {
            get { return ConfigurationManager.AppSettings["ConsumerSecret"]; }
        }

        private static string ConsumerKey
        {
            get { return ConfigurationManager.AppSettings["ConsumerKey"]; }
        }

        private static string AccessToken
        {
            get { return ConfigurationManager.AppSettings["AccessToken"]; }
        }

        private static string AccessTokenSecret
        {
            get { return ConfigurationManager.AppSettings["AccessTokenSecret"]; }
        }

        #endregion

    }
}