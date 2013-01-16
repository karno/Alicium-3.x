using System;
using Grimoire;
using System.Deployment;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace Grimoire
{
	public static class Plugin
	{
		public static Events events = new Events();
		public static List<PluginBase> Plugins = new List<PluginBase>();
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
		public static void Unload(List<PluginBase> e)
		{
				e.ForEach(x=>{x.Dying();});
				Plugins.RemoveAll(x=>e.Contains(x));
		}
		public static void AddEvent(string name,EventHandler<AliciumEventArgs> e)
		{
			events[name] += e;
		}
		public static void RemoveEvent(string name,EventHandler<AliciumEventArgs> e)
		{
			events[name] -= e;
		}
		public static void CallEvent(string name,object value)
		{
			events[name](null,new AliciumEventArgs(){Data = value});
		}
		public static void CallPlugin(string name,object value)
		{
			Plugins.Find((x) => x.GetType().ToString() == name).Call(value);
		}
		public static bool PluginExists(string name)
		{
			return Plugins.Exists(x=>name.Contains(x.GetType().ToString()));
		}
	}
}

