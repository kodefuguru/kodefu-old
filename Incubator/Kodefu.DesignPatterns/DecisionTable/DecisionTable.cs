namespace DesignPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
    public static class DecisionTable
    {
        public static DecisionTable<C1, R1> Create<C1, R1>(Tuple<C1> conditions, Tuple<R1> results)
        {
            return new DecisionTable<C1, R1>();
        }
    }
}
