using System.Collections.Generic;
using System.Linq;
using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Hearthstone.Entities;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;
using Card = Hearthstone_Deck_Tracker.Hearthstone.Card;
using Hearthstone_Deck_Tracker.Utility.Logging;
using System.Windows;

namespace ResurrectHelper
{
	internal class ResurrectHelper
	{
		private ResurrectList _list = null;

        public ResurrectHelper(ResurrectList list)
		{
			_list = list;
			// Hide in menu, if necessary
			if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
				_list.Hide();
		}

		// Reset on when a new game starts
		internal void GameStart()
		{
			_list.Update(new List<Card>());
		}

		// Need to handle hiding the element when in the game menu
		internal void InMenu()
		{
			if (Config.Instance.HideInMenu)
			{
				_list.Hide();
			}
		}

        internal void Update()
        {
        }

        internal void OnMouseOver(Card card)
        {
            IEnumerable<Entity> graveyard = Core.Game.Player.Graveyard ?? Enumerable.Empty<Entity>();

            if (card.IsNzoth())
            {
                List<Card> deadDeathrattleMinions = new List<Card>();
                foreach (Entity ce in graveyard)
                {
                    if (ce.Card == null) continue;
                    if (ce.Card.Mechanics.Contains("Deathrattle") && !ce.Info.Discarded)
                    {
                        deadDeathrattleMinions.Add(ce.Card);
                    }
                }

                _list.Update(deadDeathrattleMinions);
                _list.Show();
            }
            else if (card.IsResurrect() || card.IsOnyxBishop())
            {
                List<Card> deadMinions = new List<Card>();
                foreach (Entity ce in graveyard)
                {
                    if (ce.Card == null) continue;
                    if (ce.Card.Type == "Minion" && !ce.Info.Discarded)
                    {
                        deadMinions.Add(ce.Card);
                    }
                }

                _list.Update(deadMinions);
                _list.Show();
            }
        }

        internal void OnMouseOff()
        {
            _list.Hide();
        }

		
	}
}