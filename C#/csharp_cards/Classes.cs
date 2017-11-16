using System;
using System.Collections.Generic;
namespace csharp_cards
{
public class Card
{
    public string StringVal;
    public string Suit;
    public int Val;

    public Card()
    {}
    public Card(string stringVal = "", string suit = "", int val = 0)
    {
        StringVal = stringVal;
        Suit = suit;
        Val = val;
    }
}


public class Deck
{
    public List<Card> theDeck = new List<Card>();

    // public Deck()
    // {}
    public Deck()
    {
        string[] strVals = new string[] {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string[] suits = new string[] {"Clubs", "Diamonds", "Hearts", "Spades"};
        int[] vals = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        for(int i = 0; i < strVals.Length; i++) 
        {
            for(int j = 0; j < suits.Length; j++) 
            {
                Card myCard = new Card(strVals[i], suits[j], vals[i]);
                theDeck.Add(myCard);
                Console.WriteLine("--Place in Deck--: "+ theDeck.Count+ " Card: " + myCard.StringVal + " of " + myCard.Suit);
            }
        } 
    }

    // "Place in deck: ", theDeck.Count, 
    // "Card: ", 

    public Card deal()
    {
        Card firstCard = theDeck[0];
        theDeck.RemoveAt(0);
        return firstCard;
    }

    public void Shuffle()
    {
        Random rand = new Random();
        for(int i = 0; i < theDeck.Count; i++) 
        {
            int randIndex = rand.Next(i, theDeck.Count);
            Card temp = theDeck[i];
            theDeck[i] = theDeck[randIndex];
            theDeck[randIndex] = temp;
        }
    }

    public void reset()
    {
        theDeck.Clear();
        string[] strVals = new string[] {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string[] suits = new string[] {"Clubs", "Diamonds", "Hearts", "Spades"};
        int[] vals = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        for(int i = 0; i < strVals.Length; i++) 
        {
            for(int j = 0; j < suits.Length; j++) 
            {
                Card myCard = new Card(strVals[i], suits[j], vals[i]);
                theDeck.Add(myCard);
            }
        } 
    }

}

public class Player
{
    public string Name;

    public List<Card> Hand;

    public Player(string name = "")
    {
        Name = name;
    }

    public void Draw(Deck someDeck) 
    {
        Hand.Add(someDeck.deal());
    }

    public Card Discard(int index)
    {
        if (Hand[index] != null)
        {
            Card someCard = Hand[index];
            Hand.RemoveAt(index);
            return someCard;                 
        }
        else
        {
            return null;
        }
    }
}
}
