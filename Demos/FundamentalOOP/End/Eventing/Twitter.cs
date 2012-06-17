//-----------------------------------------------------------------------
// <copyright file="Twitter.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Eventing
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using System.Collections.Generic;

    public abstract class Twitter
    {
        protected abstract Uri GetUri();

        public event Action<IEnumerable<Message>> MessagesReceived;
         
        public void GetMessages()
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (s, e) =>
                {
                    XElement xmlTweets = XElement.Parse(e.Result);

                    var messages = from tweet in xmlTweets.Descendants("status")
                                   select new Message
                                   {
                                       ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                       Text = tweet.Element("text").Value,
                                       UserName = tweet.Element("user").Element("screen_name").Value
                                   };

                    if (MessagesReceived != null)
                    {
                        MessagesReceived(messages);
                    }
                };
            client.DownloadStringAsync(GetUri());

        }
    }
}