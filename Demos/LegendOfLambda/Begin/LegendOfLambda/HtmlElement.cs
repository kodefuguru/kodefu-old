namespace LegendOfLambda
{
    using System;
    using System.Linq;

    public class HtmlElement
    {
        public string Name { get; private set; }

        public static HtmlElement Input()
        {
            return new HtmlElement("input");
        }

        private HtmlElement(string name)
        {
            this.Name = name;
        }

        public string Attributes(params Func<object, object>[] attributes)
        {
            if (attributes == null)
            {
                return "<" + Name + "/>";
            }
            else
            {
                return "<{0} {1}/>".FormatWith(Name,
                    attributes.Select(f => f.Method.GetParameters()[0].Name + "=\"" + f(null) + "\"")
                              .Delimit(" "));
            }
        }
    }
}