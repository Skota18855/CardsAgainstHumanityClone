using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
    public class ExpansionManager
    {
        public static Dictionary<string, Expansion> Expansions { get; set; }
        
        public void AddExpansion(Expansion expansion)
        {
            Expansions.Add(expansion.PackName, expansion);
        }
    }

    public class Expansion
    {
        public string PackName { get; set; }
        public string PackDescription { get; set; }

        public BlackCard[] BlackCards { get; set; }
        public WhiteCard[] WhiteCards { get; set; }
    }
}
