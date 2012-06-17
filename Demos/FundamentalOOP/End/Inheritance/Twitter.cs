//-----------------------------------------------------------------------
// <copyright file="Twitter.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Inheritance
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    
    public abstract class Twitter
    {


        protected abstract Uri GetUri();

        public Message[] GetMessages()
        {
            WebClient client = new WebClient();
            string xml = client.DownloadString(GetUri());
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