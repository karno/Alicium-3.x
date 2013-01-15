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
			return Found;
		}
		
	}
}

