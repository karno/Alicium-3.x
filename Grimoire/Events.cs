using System;
using System.Collections.Generic;
using Twitterizer;

namespace Grimoire
{
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

