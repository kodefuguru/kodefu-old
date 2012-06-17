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
            int index;
            if (!int.TryParse(Request.QueryString["index"], out index))
            {
                index = 1;
            }

            // Convert
            // var index = Convert.ToInt32(Request.QueryString["index"]);

            Console.WriteLine(index);
        }

        static int GetIndexByConvert()
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(Request.QueryString["index"]);
            }
            catch { }

            return index;
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
                    request.QueryString = new Dictionary<string, string>
                                                              {{"index", index}};
                }

                return request;
            }
        }

        #endregion
    }
}
