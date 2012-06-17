namespace DesignPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
        
    public class DecisionTable<C1, R1>
    {
        List<Decision<Func<C1, bool>, R1>> decisions = new List<Decision<Func<C1, bool>, R1>>();
 
        public DecisionTable<C1, R1> WithDecision(Func<C1, bool> condition1, R1 result1)
        {
            decisions.Add(Decision.Create(condition1, result1));
            return this;
        }

        public DecisionTable<C1, R1> WithDecision(C1 condition1, R1 result1)
        {
            decisions.Add(Decision.Create((Func<C1, bool>)(x => x.Equals(condition1)), result1));
            return this;
        }

        public IEnumerable<Decision<Func<C1, bool>, R1>> GetDecisions(C1 condition1)
        {
            foreach (var decision in decisions)
            {
                if (condition1 == null || decision.Condition1(condition1))
                {
                    yield return decision;
                }
            }
        }

        public Decision<Func<C1, bool>, R1> GetDecision(C1 condition1)
        {
            return GetDecisions(condition1).Single();            
        }
    }
}
