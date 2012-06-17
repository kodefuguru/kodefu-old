namespace DesignPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Decision<C1, R1>
    {
        public C1 Condition1 { get; set; }
        public R1 Result1 { get; set; }


        public Decision(C1 condition1, R1 result1)
        {
            this.Condition1 = condition1;
            this.Result1 = result1;
        }
    }
}
