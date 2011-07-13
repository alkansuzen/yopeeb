using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using TweetSharp;

namespace Beepoy.SocialMedia.Twitter
{
    public class Authentication
    {
        public static void AuthorizeApp()
        {
            // OAuth Access Token Exchange
            TwitterService service = new TwitterService("xDGISMTarPrTJj7AzYDSqA", "p1F9oVPP2RNYGMN0siZVgd4MaJ9KmfOQZeeommsv6Ng", "19319611-Qse2lpCEqmbbE534RADJssSZ34F7KMgGKgXRUeAqY", "hmSV3SrY9cZbGp8PmF1Czi24WM13GOEovRUZpndbM5w");
            OAuthRequestToken unauthorizedToken = service.GetRequestToken();
            string url = service.GetAuthorizationUri(unauthorizedToken).AbsolutePath;
        }

        public static void Login()
        {
            // OAuth Access Token Exchange
            TwitterService service = new TwitterService("xDGISMTarPrTJj7AzYDSqA", "p1F9oVPP2RNYGMN0siZVgd4MaJ9KmfOQZeeommsv6Ng", "19319611-Qse2lpCEqmbbE534RADJssSZ34F7KMgGKgXRUeAqY", "hmSV3SrY9cZbGp8PmF1Czi24WM13GOEovRUZpndbM5w");
            OAuthRequestToken unauthorizedToken = service.GetRequestToken();
            string url = service.GetAuthorizationUri(unauthorizedToken).AbsolutePath;

            string pin = "7990245";
            OAuthAccessToken authToken = service.GetAccessToken(unauthorizedToken, pin);

            service.AuthenticateWith("xDGISMTarPrTJj7AzYDSqA", "p1F9oVPP2RNYGMN0siZVgd4MaJ9KmfOQZeeommsv6Ng", "19319611-Qse2lpCEqmbbE534RADJssSZ34F7KMgGKgXRUeAqY", "hmSV3SrY9cZbGp8PmF1Czi24WM13GOEovRUZpndbM5w");
            if (service.Response.InnerException == null)
            {
                TwitterStatus status = service.SendTweet("Bach");
            }
            
            
//using TweetSharp.Model;
//using TweetSharp.Twitter.Extensions;
//using TweetSharp.Twitter.Fluent;
//using TweetSharp.Twitter.Model;
//using TweetSharp.Twitter.Service;
 
////generate the token and url that will we need
//OAuthToken unauthorizedToken = service.GetRequestToken(twitterConsumerKey, twitterConsumerSecret);
//string url = service.GetAuthorizationUrl(unauthorizedToken);
 
////TODO: get the pin from the user
 
////once you have the pin from the user, build your authorized token
//OAuthToken authToken = service.GetAccessToken(twitterConsumerKey, twitterConsumerSecret, unauthToken, pin);
 
////store the authToken.Token, and the authToken.TokenSecret
 
////make an authenticated call
//var service = new TwitterService();
//service.AuthenticateWith(twitterConsumerKey, twitterConsumerSecret, syndicationService.OAuthToken, syndicationService.OAuthTokenSecret);
//if (service.Error == null)
//{
//TwitterStatus status = service.SendTweet(value);
//}

        }
    }
}