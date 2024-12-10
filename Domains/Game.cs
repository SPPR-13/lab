using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Game
    {
        public List<Player>? Players { get; set; }
        public bool GameStarted { get; set; } = false;
        public Deck? Deck { get; set; }

        public Player? GetPlayer(Player findPlayer)
        {
            if (Players != null)
            {
                foreach (var player in Players)
                {
                    if (player.Username == findPlayer.Username) { return player; }
                }
            }
            return null;
        }

        public void UpdatePlayer(Player playerState)
        {
            if (Players != null)
            {
                foreach (var player in Players)
                {
                    if (player.Username == playerState.Username)
                    {
                        player.Cards = playerState.Cards;
                        player.ValueOfCards = playerState.ValueOfCards;
                        player.LastAction = playerState.LastAction;
                        player.Points = playerState.Points;
                    }
                }
            }

        }
    }
}