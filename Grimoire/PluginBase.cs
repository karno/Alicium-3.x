using System;

namespace Grimoire
{
	/// <summary>
	/// Base of the plugin.
	/// To make a plugin, please make your class inherited from this class.
	/// </summary>
	public abstract class PluginBase
	{
		public abstract void Initalize();
		public abstract void Call(object o);
		public abstract void Dying();
	}
}

