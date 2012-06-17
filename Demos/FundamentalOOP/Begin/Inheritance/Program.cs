using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
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
