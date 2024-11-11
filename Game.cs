using System.Reflection.Metadata.Ecma335;

class Player{

    int id {get;set;}
    public List<Card> hand =[];

    public Player()
    {
        this.id=new Random().Next();
        this.hand=new List<Card>();
    }

    public void play()
    {
        Console.WriteLine($"Player {id} playing {hand.Last()}");
    }
    
}
class Game
{
    public Deck deck {get;set;}
    public List<Player> players = [];

    public Game()
    {
        this.deck=new Deck();
        this.players=new List<Player>();
    }
    public Game(List<Player> players)
    {
        this.deck=new Deck();
        this.players=players;
        
    }

    public void sim()
    {
        this.deal();
        foreach (var player in players)
        {
            player.play();
            
        }
    }
    public void deal()
    {
        var lastDealt=0;
        foreach (var player in players)
        {
            player.hand=this.deck.Cards.GetRange(lastDealt,8);
            lastDealt+=8;
            
        }

    }
 
}
public enum Suit
{
    Hearts,
    Clubs,
    Spades,
    Diamonds

}
public enum CardValues
{
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,

    Ace = 11,
    King = 12,
    Queen = 13,
    Jack = 14

}
class Card
{

    public CardValues Value { get; set; }
    public Suit Suit { get; set; }

    public int Points { get; set; }
    public Card(CardValues value, Suit suit)
    {
        this.Suit = suit;
        this.Value = value;
        this.Points = value switch
        {
            CardValues.Ace => 11,
            CardValues.Jack => 30,
            CardValues.Queen => 2,
            CardValues.King => 3,
            CardValues.Nine => 20,
            CardValues.Ten => 10,
            _ => 0
        };
    }
    public override string ToString() => $"{Value} of {Suit} - {Points} Points";

}
class Deck
{
    public List<Card> Cards = [];
    public override string ToString()
    {
        return string.Join(Environment.NewLine, Cards);
    }

    public Deck()
    {
        this.Cards = new List<Card>();
        BuildDecK();
    }
    public void BuildDecK()
    {
        foreach (var suit in Enum.GetValues<Suit>())
        {
            foreach (var cardValue in Enum.GetValues<CardValues>())
            {

                Cards.Add(new Card(cardValue, suit));
            }

        }

    }


}

