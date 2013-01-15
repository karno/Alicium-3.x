using System;
using System.Collections.Generic;
using Twitterizer;

namespace Grimoire
{
	public delegate void AliceEventHandler(object sender,string e);
	public delegate void StatusEventHandler(object sender, TwitterStatus e);
	public delegate void UserEventHandler(object sender, TwitterUser u);
	public enum EventType
	{
		Favorited,Followed,Unfavorited
	}
	public class Events
	{
		private Dictionary<string,EventHandler> dat = new Dictionary<string, EventHandler>();
		public EventHandler this[string index]
		{
			get
			{
				return dat[index];
			}
			set
			{
				dat[index] = value;
			}
		}
	}
	
}

