using System;
using System.Collections.Generic;
using Twitterizer;

namespace Grimoire
{
	public class Events
	{
		private Dictionary<string,Action<object>> dat = new Dictionary<string, Action<object>>();
		public Action<object> this[string index]
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

