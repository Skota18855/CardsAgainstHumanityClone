using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
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


    //public class BlackCard
    //{
    //    // Static variable that determines what blank spaces in cards are replaced with. 
    //    private static string blankSpace = "___";

    //    // Array holding all the text present on a black card.
    //    // Blank spaces will be inserted by a method below so simply write out any text before/after a blank as tho it were there already.
    //    // E.g. "Here lies " ". I will always remember them for " "."
    //    public string[] Text { get; set; }
    //    // Determines if there is a blank before the text on the card is printed.
    //    // E.g. "___ is why I don't smoke anymore."
    //    public bool FrontBlank { get; set; }
    //    // Determines if there is a blank after the text on the card is printed.
    //    // E.g. "If I had a nickel for every time that happened, I could buy ___"
    //    public bool BackBlank { get; set; }
    //    // Represents the total amount of TotalBlankSpaces. 
    //    public int TotalBlankSpaces { get; set; }

    //    // Will automatically determine how many blank spaces are available based on data provided. 
    //    // Be sure to explicitly state if there's a front or back blank space.
    //    public BlackCard(string[] text, bool frontBlank = false, bool backBlank = false)
    //    {
    //        Text = text;
    //        FrontBlank = frontBlank;
    //        BackBlank = backBlank;
    //        TotalBlankSpaces = CalculateSpaces();
    //    }

    //    // Detremines how many blank spaces are present on a card; this value can be used to determine how many white cards to require.
    //    public int CalculateSpaces()
    //    {
    //        int result = 0;

    //        if (FrontBlank) result++;
    //        if (BackBlank) result++;

    //        result += Text.Length - 1;
    //        return result;
    //    }

    //    // Returns a string representing a template black card including blank spaces. 
    //    // E.g. "Here lies ___. I will always remember them for ___."
    //    public string DisplayText()
    //    {
    //        string result = "";
    //        StringBuilder sb = new StringBuilder();

    //        if (FrontBlank)
    //        {
    //            sb.Append(blankSpace);
    //        }

    //        foreach (string text in Text)
    //        {
    //            sb.Append(text);
    //            sb.Append(blankSpace);
    //        }

    //        if (!BackBlank)
    //        {
    //            sb.Remove(sb.Length - blankSpace.Length, blankSpace.Length);
    //        }

    //        return result;
    //    }
    //}

    //public class WhiteCard : ISerializable
    //{
    //    // Represents the text to be printed on the card.
    //    public string Text { get; set; }
    //    // Determines if the card is blank or not; if blank, when played the player is allowed to type in their own text to submit.
    //    public bool Blank { get; set; }

    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("TextString", Text, typeof(string));
    //        info.AddValue("BlankBool", Blank, typeof(bool));
    //    }

    //    public WhiteCard(SerializationInfo info, StreamingContext context)
    //    {
    //        // Reset the property value using the GetValue method.
    //        Text = (string)info.GetValue("TextString", typeof(string));
    //        Blank = (bool)info.GetValue("BlankBool", typeof(bool));
    //    }
    //}

}
