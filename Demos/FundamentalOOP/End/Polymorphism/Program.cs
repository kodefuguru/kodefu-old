using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Email.Build()
                                .From("kodefuguru@live.com")
                                .To("attendees@sqlsaturday.com")
                                .Subject("Hello World!")
                                .Body("It sure is hot outside")
                                .Compose();

            Console.WriteLine(email);
                
        }

        static void WriteStrings(IEnumerable<string> strings)
        {
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class Email : IEmailBody, IEmailCompose, IEmailFrom, IEmailSubject, IEmailTo
    {
        private Email()
        {
        }

        private string from;
        private string to;
        private string subject;
        private string body;

        public static IEmailFrom Build()
        {
            return new Email();
        }

        public IEmailTo From(string from)
        {
            this.from = from;
            return this;
        }

        public IEmailSubject To(string to)
        {
            this.to = to;
            return this;
        }

        public IEmailBody Subject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public IEmailCompose Body(string body)
        {
            this.body = body;
            return this;
        }

        public string Compose()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("from: " + this.from);
            sb.AppendLine("to: " + this.to);
            sb.AppendLine("subject: " + this.subject);
            sb.AppendLine("body: " + this.body);
            return sb.ToString();
        }
    }

    public interface IEmailFrom
    {
        IEmailTo From(string from);
    }

    public interface IEmailTo
    {
        IEmailSubject To(string to);
    }

    public interface IEmailSubject
    {
        IEmailBody Subject(string subject);
    }

    public interface IEmailBody
    {
        IEmailCompose Body(string body);
    }

    public interface IEmailCompose
    {
        string Compose();
    }
}
