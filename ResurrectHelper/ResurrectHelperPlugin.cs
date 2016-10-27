using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace ResurrectHelper
{
	public class ResurrectHelperPlugin : IPlugin
	{
		private ResurrectList _list;

		public string Author
		{
			get { return "Alryco"; }
		}

		public string ButtonText
		{
			get { return "Settings"; }
		}

		public string Description
		{
			get { return "A plugin showing possible resurrect targets for relevent cards (e.g. Resurrect, Onyx Bishop, N'Zoth). When cursor is hovering over one of the aforementioned cards, a list of all friendly minions that have died this game will be shown (or a list of all friendly deathrattle minions that have died in the case of N'Zoth)"; }
		}

		public MenuItem MenuItem
		{
			get { return null; }
		}

		public string Name
		{
			get { return "Resurrect Helper"; }
		}

		public void OnButtonPress()
		{
		}

		public void OnLoad()
		{
			_list = new ResurrectList();
			Core.OverlayCanvas.Children.Add(_list);
			ResurrectHelper resHelper = new ResurrectHelper(_list);

            GameEvents.OnInMenu.Add(resHelper.InMenu);

            GameEvents.OnPlayerHandMouseOver.Add(resHelper.OnMouseOver);
            GameEvents.OnMouseOverOff.Add(resHelper.OnMouseOff);
		}

		public void OnUnload()
		{
			Core.OverlayCanvas.Children.Remove(_list);
		}

		public void OnUpdate()
		{

		}

		public Version Version
		{
			get { return new Version(0, 1, 1); }
		}
	}
}