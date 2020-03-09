using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CardsAgainstHumanityClone.Models
{
    // Game Cards
    public class GameCard
    {
        public string cardType;
        public string cardContent;
        public string cardLocation;
        public string owner;

        public static string ToJson(GameCard card)
        {
            return JsonConvert.SerializeObject(card);
        }

        public static GameCard FromJson(string cardData)
        {
            return JsonConvert.DeserializeObject<GameCard>(cardData);
        }

        public static GameCard ToGameCard(Card card)
        {
            GameCard result = new GameCard();

            result.cardType = (card.GetType() == typeof(WhiteCard)) ? "whiteCard" : "blackCard";
            result.cardContent = card.Text;

            return result;
        }
    }

    // Simple Cards

    public class Card : ISerializable
    {
        public string Text { get; set; }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TextString", Text, typeof(string));
        }
    }

    public class BlackCard : Card
    {
        public int BlankSpaces { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TextString", Text, typeof(string));
            info.AddValue("BlankSpacesInt", BlankSpaces, typeof(int));
        }
    }

    public class WhiteCard : Card
    {
        public bool BlankCard { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TextString", Text, typeof(string));
            info.AddValue("BlankCardBool", BlankCard, typeof(bool));
        }
    }
}
