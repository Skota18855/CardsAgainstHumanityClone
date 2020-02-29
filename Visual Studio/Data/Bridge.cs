using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Data
{
    public static class Bridge
    {
        public static IProfileDAL context { get; set; }
    }
}
