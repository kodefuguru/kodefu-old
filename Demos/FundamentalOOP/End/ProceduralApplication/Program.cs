//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ConsoleApplication10
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    /// <summary>
    /// Contains the program entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the program entry point. 
        /// </summary>
        /// <param name="args">An array of <see cref="T:System.String"/> containing command line parameters.</param>
        private static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            string userName = args[0];
            WebClient client = new WebClient();
            string xml = client.DownloadString(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + userName));
            XElement xmlTweets = XElement.Parse(xml);

            var messages = from tweet in xmlTweets.Descendants("status")
                           select tweet.Element("text").Value;

            foreach (var msg in messages)
                Console.WriteLine(msg);
        }
    }
}
