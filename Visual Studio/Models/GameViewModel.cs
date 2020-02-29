using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
    public class GameViewModel
    {
        public Profile ProfileModel { get; set; } = null;
        public Game GameModel { get; set; } = null;

        public GameViewModel() { }
        public GameViewModel(Profile p) { ProfileModel = p; GameModel = new Game(); }
        public GameViewModel(Profile p, Game g) { ProfileModel = p; GameModel = g; }
    }
}
