using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance
{
    public class UserTwitter : Twitter
    {
        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                userName = value;
            }
        }

        public UserTwitter(string userName)
        {
            this.UserName = userName;
        }

        protected override Uri GetUri()
        {
            return new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + this.UserName);
        }
    }
}
