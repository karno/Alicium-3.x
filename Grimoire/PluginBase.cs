using System;

namespace Grimoire
{
	/// <summary>
	/// Base of the plugin.
	/// To make a plugin, make your class inherited from this class.
	/// </summary>
	public abstract class PluginBase
	{
		/// <summary>
		/// Is called when this plugin is loaded.
		/// </summary>
		public abstract void Initalize();
		/// <summary>
		/// Is called when this plugin is called.
		/// </summary>
		/// <param name='o'>
		/// Object sent from Alicium kernel or other plugin.
		/// </param>
		public abstract void Call(object o);
		/// <summary>
		/// Is called when this plugin is unloaded.
		/// </summary>
		public abstract void Dying();
	}
}

