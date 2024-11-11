// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var deck=new Deck();
var player1=new Player();
var player2=new Player();
var player3=new Player();
var player4=new Player();
var players= new List<Player>{player1,player2,player3,player4};
var game=new Game(players);

game.sim();