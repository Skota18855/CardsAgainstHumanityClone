using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
    public class HouseRule
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public HouseRule(string title, string description, bool isEnabled)
        {
            Title = title;
            Description = description;
            IsEnabled = isEnabled;
        }
    }
}
