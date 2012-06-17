//-----------------------------------------------------------------------
// <copyright file="Twitter.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CreateObjects
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    /// <summary>
    /// TODO: Provide summary section in the documentation header.
    /// </summary>
    public class Twitter
    {
        public Message[] GetMessages(string userName)
        {
            WebClient client = new WebClient();
            string xml = client.DownloadString(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + userName));
            XElement xmlTweets = XElement.Parse(xml);

            var messages = from tweet in xmlTweets.Descendants("status")
                           select new Message
                           {
                               ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                               Text = tweet.Element("text").Value,
                               UserName = tweet.Element("user").Element("screen_name").Value
                           };

            return messages.ToArray();
        }
    }
}
