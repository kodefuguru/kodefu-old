//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Encapsulation
{
    using System;
    using System.Linq;

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
            Twitter twitter = new Twitter(userName);
            var messages = twitter.GetMessages();

            foreach (var msg in messages)
                Console.WriteLine(msg.Text);
        }
    }
}
