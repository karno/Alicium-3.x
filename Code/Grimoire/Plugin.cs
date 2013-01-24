using System;
using Grimoire;
using System.Deployment;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grimoire
{
	public static class Plugin
	{
		public static Events events = new Events();
		public static List<PluginBase> Plugins = new List<PluginBase>();
		/// <summary>
		/// Load the plugin to Alicium system.
		/// </summary>
		/// <param name='path'>
		/// Path of the plugin.
		/// </param>
		/// <exception cref='FileNotFoundException'>
		/// Is thrown when a file path argument specifies a file that does not exist.
		/// </exception>
		public static List<PluginBase> Load(string path)
		{
			if(!File.Exists(path))
			{
				throw new FileNotFoundException("Couldn't find a plugin such as " + path);
			}
			var asm = Assembly.LoadFrom(path);
			var Types = asm.GetTypes();
			var Found = new List<Grimoire.PluginBase>();
			for(int i=0;i<Types.Length;i++)
			{
				if(Types[i].IsSubclassOf(typeof(Grimoire.PluginBase)))
				{
					var v=(Grimoire.PluginBase)Activator.CreateInstance(Types[i]);
					Found.Add(v);
				}
			}
			Found.ForEach(x=>{x.Initalize();});
			Plugins.AddRange(Found);
			return Found;
		}
		/// <summary>
		/// Unload the plugin from Alicium system.
		/// </summary>
		/// <param name='e'>
		/// List of plugins you want to unload.
		/// </param>
		public static void Unload(List<PluginBase> e)
		{
				e.ForEach(x=>{x.Dying();});
				Plugins.RemoveAll(x=>e.Contains(x));
		}
		/// <summary>
		/// From a code of plugin,Make a function handled by the event
		/// </summary>
		/// <param name='name'>
		/// Name of the event.
		/// </param>
		/// <param name='e'>
		/// The function.
		/// </param>
		public static void AddToEvent(string name,EventHandler<AliciumEventArgs> e)
		{
			events[name] += e;
		}
		/// <summary>
		/// From a code of plugin,Make a function not handled by the event
		/// </summary>
		/// <param name='name'>
		/// Name of the event.
		/// </param>
		/// <param name='e'>
		/// The function.
		/// </param>
		public static void RemoveFromEvent(string name,EventHandler<AliciumEventArgs> e)
		{
			events[name] -= e;
		}
		/// <summary>
		/// Call the event.
		/// </summary>
		/// <param name='name'>
		/// Name of the event.
		/// </param>
		/// <param name='value'>
		/// Value you want to send.
		/// </param>
		public static void CallEvent(string name,object value)
		{
			events[name](null,new AliciumEventArgs(){Data = value});
		}
		/// <summary>
		/// Call the plugin.
		/// To handle this event,In your code of plugin,
		/// Write "your_method(object sender,AliciumEventArgs e){}"
		/// then Write "Plugin.AddEvent(name,your_method);"
		/// and you can read the value from "e.Data".
		/// </summary>
		/// <param name='name'>
		/// Name of the plugin.
		/// </param>
		/// <param name='value'>
		/// Value you want to send.
		/// </param>
		public static void CallPlugin(string name,object value)
		{
			new Task(() => Plugins.Find((x) => x.GetType().ToString() == name).Call(value)).Start();
		}
		/// <summary>
		/// Check the plugin exists.
		/// </summary>
		/// <returns>
		/// If the plugin exists.
		/// </returns>
		/// <param name='name'>
		/// The name of plugin you want to check.
		/// </param>
		public static bool PluginExists(string name)
		{
			return Plugins.Exists(x=>name.Contains(x.GetType().ToString()));
		}
	}
}

