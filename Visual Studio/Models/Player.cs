using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
    public class Player
    {

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private List<WhiteCard> hand;
		public List<WhiteCard> Hand
		{
			get { return hand; }
			set { hand = value; }
		}

		private int score;
		public int Score
		{
			get { return score; }
			set { score = value; }
		}

		private bool isCzar;

		public Player(string name)
		{
			Name = name;
			Hand = new List<WhiteCard>();
			Score = 0;
			IsCzar = false;
		}

		public bool IsCzar
		{
			get { return isCzar; }
			set { isCzar = value; }
		}

		public void PlayCard(WhiteCard playedCard)
		{
			Hand.Remove(playedCard);
		}
	}
}
