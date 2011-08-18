using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using TweetSharp;
using TweetSharp.Model;

namespace Beepoy.SocialMedia.Twitter
{
    public class Authentication
    {
        TwitterService twitterService;
        OAuthRequestToken requestToken;

        public string AuthorizeApp()
        {
            TwitterClientInfo twitterClientInfo = new TwitterClientInfo();
            twitterClientInfo.ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"]; //Read ConsumerKey out of the app.config
            twitterClientInfo.ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"]; //Read the ConsumerSecret out the app.config
            
            string accessToken = ConfigurationManager.AppSettings["AccessToken"];
            //string accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];

            twitterService = new TwitterService(twitterClientInfo);

            //Now we need the Token and TokenSecret
            //Firstly we need the RequestToken and the AuthorisationUrl
            requestToken = twitterService.GetRequestToken();
            string authUrl = twitterService.GetAuthorizationUri(requestToken).AbsoluteUri;

            return authUrl;
        }

        public bool Authenticate(string pin)
        {
            OAuthAccessToken accessToken = twitterService.GetAccessToken(requestToken, pin);

            twitterService.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);

            if (twitterService.Response.InnerException != null)
                return false;
            return true;
        }

        public TwitterStatus Tweet(string message)
        {
            return twitterService.SendTweet(message);
        }
    }
}