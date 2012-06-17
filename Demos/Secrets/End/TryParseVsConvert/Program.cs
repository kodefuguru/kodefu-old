namespace TryParseVsConvert
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    class Program
    {
        const string index = null;

        static void Main(string[] args)
        {
            var index = Maybe.ToInt32(Request.QueryString["index"]) ?? 1;

            Console.WriteLine(index);
        }

        #region Request code to fake web app.

        static dynamic request;

        static dynamic Request
        {
            get
            {
                if (request == null)
                {
                    request = new ExpandoObject();
                    request.QueryString = new Dictionary<string, string> { { "index", index } };
                }

                return request;
            }
        }

        #endregion
    }
}
