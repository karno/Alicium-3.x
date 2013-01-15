using System;

namespace Grimoire
{
	public abstract class PluginBase
	{
		public abstract void Initalize(object o);
		public abstract void EventSet(Events e);
		public abstract void Dying();
	}
}

