using System;
using Grimoire;
using System.Deployment;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace Alice
{
	public static class Margatroid
	{
		public static void Main(string[] args)
		{
			Test ();
		}
		static void Test()
		{
			Console.Write(@"Alicium 3.x kernel v3.0
build 20.130.116

Alice:> ");
			var e = new Grimoire.Events();
			e["test"] = (x,y)=>{};
			var Found = new List<Grimoire.PluginBase>();
			while(true)
			{
				string command=Console.ReadLine();
				if(command=="exit")
				{
					Console.WriteLine("halt.");
					break;
				}
				else if(command=="help")
				{
					Console.WriteLine(@"exit ... exit from Alicium kernel.
load [File] ... Load a plugin file.
rm [Word] ... Unload plugins whose name contains the Word.
rm -a ... Unload all plugins.
ls ... Show the list of loaded plugins.
[Name] ... Execute the plugin.
help ... Show this.");
				}
				else if(command.Contains("load "))
				{
					try
					{
						var Get = Grimoire.Plugin.Load((Grimoire.Magic.CutString("load ",command)[0]));
						Get.ForEach(x => {x.EventSet(e);});
						Found.AddRange(Get);
						Console.WriteLine("Success.");
					}
					catch(FileNotFoundException)
					{
						Console.WriteLine("Not found.");
					}
			       Console.WriteLine(Found.Count + " Plugins loaded now.");
				}
				else if(command.Contains("rm "))
				{
					if(Grimoire.Magic.CutString("rm ",command)[0] == "-a" || Grimoire.Magic.CutString("rm ",command)[0] == "--all")
					{
						Found.ForEach(x => {x.Dying();});
						Found.Clear();
						Console.WriteLine("All Plugins was unloaded.");
			       	Console.WriteLine(Found.Count + " Plugins loaded now.");
					}
					else
					{
						var del=Found.FindAll((x) => x.GetType().ToString().Contains(Grimoire.Magic.CutString("rm ",command)[0]));
						del.ForEach(x => {x.Dying();});
						Found.RemoveAll((x) => del.Contains(x));
						Console.WriteLine(del.Count + " Plugins was unloaded.");
			       	Console.WriteLine(Found.Count + " Plugins loaded now.");
					}
				}
				else if(command=="ls")
				{
					foreach(var p in Found)
					{
						Console.WriteLine(" - " + p.GetType().ToString());
					}
				}
				else if(command=="event")
				{
					e["test"](null,null);
				}
				else if(Found.Exists((x) => x.GetType().ToString() == command))
				{
					Found.Find((x) => x.GetType().ToString() == command).Initalize("");
					
				}
				else
				{
					Console.WriteLine(command + " is not vaild command.");
				}
				Console.Write("Alice:> ");
			}
		}
	}
}

