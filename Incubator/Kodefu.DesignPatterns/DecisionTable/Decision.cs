namespace DesignPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public static class Decision
    {
        public static Decision<C1, R1> Create<C1, R1>(C1 condition1, R1 result1)
        {
            return new Decision<C1, R1>(condition1, result1);
        }
    }
}
