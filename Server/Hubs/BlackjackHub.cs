using Domains;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public class BlackjackHub : Hub
    {
        // when new player joins
        public async Task Join(Player player, Game game)
        {
            player.LastAction = "Joined";

            await Clients.All.SendAsync("ReceivePlayer", player, game);
        }

        // when new player joins
        public async Task Ready(Game game)
        {
            await Clients.All.SendAsync("PlayerReady", game);
        }

        // begins game
        public async Task BeginGame(Game game)
        {
            game.GameStarted = true;

            // makes the deck for the game
            Deck deck = new();
            deck.Shuffle();
            game.Deck = deck;

            // adds all the players and adds two cards
            foreach (var participant in game.Players)
            {
                participant.Cards = new();
                participant.Cards.Add(game.Deck.TakeCard());
                participant.Cards.Add(game.Deck.TakeCard());
                participant.ValueOfCards = participant.Cards.CountPoints();
            }

            await Clients.All.SendAsync("BeginGame", game);
        }

        public async Task UpdateGame(Game game)
        {
            await Clients.All.SendAsync("UpdateGame", game);
        }

        // palauttaa yhden kortin
        public async Task Hit(Player player, Game game)
        {
            player.LastAction = "Hit";
            var card = game.Deck.TakeCard(); // takes card from deck
            player.Cards.Add(card);
            player.ValueOfCards = player.Cards.CountPoints();
            if (player.ValueOfCards > 21)
            {
                player.LastAction = "Staying";
                game.UpdatePlayer(player);

                if (game.Players.All(p => p.LastAction == "Staying"))
                {
                    CountPoints(game);
                    game.GameStarted = false;
                };
            }

            game.UpdatePlayer(player);

            await Clients.All.SendAsync("ReceiveCard", player, game);
        }

        // ei enää kortteja
        public async Task Stay(Player player, Game game)
        {
            player.LastAction = "Staying";

            game.UpdatePlayer(player);

            if (game.Players.All(p => p.LastAction == "Staying"))
            {
                CountPoints(game);
                game.GameStarted = false;
            };

            await Clients.All.SendAsync("ReceiveStatus", player, game);
        }

        public async Task PlayAgain(Game game)
        {
            // makes the deck for the game
            Deck deck = new();
            deck.Shuffle();
            game.Deck = deck;

            foreach (Player player in game.Players)
            {
                player.Cards = new();
                player.Cards.Add(game.Deck.TakeCard());
                player.Cards.Add(game.Deck.TakeCard());
                game.Players.Add(player);
            }

            await Clients.All.SendAsync("PlayAgain", game);
        }

        public Game CountPoints(Game game)
        {
            if (game.Players.Count > 1)
            {
                var highest = game.Players[0];

                for (int i = 1; i < game.Players.Count; i++)
                {
                    if (highest.ValueOfCards < game.Players[i].ValueOfCards && game.Players[i].ValueOfCards < 22)
                    {
                        highest = game.Players[i];
                    }
                    else if (highest.ValueOfCards > 21)
                    {
                        highest = game.Players[i];
                    }
                }

                highest.Points += 1;

                foreach (var player in game.Players)
                {
                    if ((player.ValueOfCards == highest.ValueOfCards) && (player.Username != highest.Username))
                    {
                        player.Points += 1;
                        game.UpdatePlayer(highest);
                    }
                }
            }
            else
            {
                game.Players[0].Points += 1;
            }

            return game;
        }
    }
}