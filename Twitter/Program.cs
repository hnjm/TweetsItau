﻿using System;
using System.Collections.Generic;
using System.Net;
using TweetSharp;

namespace Twitter
{
    class Program
    {
        public static string _consumerKey = "WX3A7OxRQZCMYzvnBng1ejVIs"; // Your key
        public static string _consumerSecret = "HER5wpZdVrz83Z93lS4pRR23tkc7DsUQlDFCIuxYGq3VbfFDqO"; // Your key  
        public static string _accessToken = "66551992-GpqT2wk0tt6skrKnwTRzsifOqKyx64piTf2FKFmV9"; // Your key  
        public static string _accessTokenSecret = "Fo6jK9KNMgBqSY52GU65dDP0tUnv7ZHdbpVtYgbeUEml3"; // Your key  
       
        //public static TwitterService service = new TwitterService(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);

        static void Main(string[] args)
        {
            //
            TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
            twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);

            int tweetcount = 1;
            var tweets_search = twitterService.Search(new SearchOptions { Q = "#openbanking", Resulttype = TwitterSearchResultType.Recent, Count = 100 });
            //Resulttype can be TwitterSearchResultType.Popular or TwitterSearchResultType.Mixed or TwitterSearchResultType.Recent  
            List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
            foreach (var tweet in tweets_search.Statuses)
            {
                try
                {
                    string screenName  = tweet.User.ScreenName;  
                    string userName  = tweet.User.Name;   
                    string text  = tweet.Text; // Tweet text  
                    int retweetCount  = tweet.RetweetCount; //No of retweet on twitter  
                    int favouritesCount  = tweet.User.FavouritesCount; //No of Fav mark on twitter  
                    string profileImage  = tweet.User.ProfileImageUrl; //Profile Image of Tweet  
                    DateTime createdDate = tweet.CreatedDate; //For Tweet posted time  
                    //"https://twitter.com/intent/retweet?tweet_id=" + tweet.Id;  //For Retweet  
                    //"https://twitter.com/intent/tweet?in_reply_to=" + tweet.Id; //For Reply  
                    //"https://twitter.com/intent/favorite?tweet_id=" + tweet.Id; //For Favorite  

                    //Above are the things we can also get using TweetSharp.  
                    Console.WriteLine(screenName + "\n" + userName + "\n" + text + "\n" + retweetCount + "\n" + retweetCount + "\n" + favouritesCount + "\n" + profileImage + "\n" + createdDate);
                    tweetcount++;
                }
                catch { }
            }
            Console.ReadLine();
        }

    }
}
