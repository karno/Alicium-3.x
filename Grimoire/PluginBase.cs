using System;

namespace Grimoire
{
	public abstract class PluginBase
	{
		public abstract void Initalize();
		public abstract void Call(object o);
		public abstract void Dying();
	}
}

