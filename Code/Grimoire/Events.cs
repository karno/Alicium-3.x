using System;
using System.Collections.Generic;
using Twitterizer;

namespace Grimoire
{
	public class Events
	{
		private Dictionary<string,EventHandler<AliciumEventArgs>> dat = new Dictionary<string, EventHandler<AliciumEventArgs>>();
		public EventHandler<AliciumEventArgs> this[string index]
		{
			get
			{
				if(!dat.ContainsKey(index))
				{
					dat[index]=(x,y)=>{};
				}
				return dat[index];
			}
			set
			{
				if(!dat.ContainsKey(index))
				{
					dat[index]=(x,y)=>{};
				}
				dat[index] = value;
			}
		}
	}
	public class AliciumEventArgs : EventArgs
	{
		public object data;
		public Type type;
		public static AliciumEventArgs Create<T>(T arg)
		{
			return new AliciumEventArgs(){data = arg,type = typeof(T)};
		}
	}
	
}

