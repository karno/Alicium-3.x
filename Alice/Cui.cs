using System;
using Grimoire;
using System.Net;
using System.Web;
using Twitterizer;
using Twitterizer.Streaming;
using System.Deployment;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace Alice
{
	public static class Cui
	{
		public static void CuiMain()
		{
			Console.Write(@"Alicium 3.x kernel v3.0
build 20.130.117

Alice:> ");
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
eventtest ... Call the test event.
help ... Show this.");
				}
				else if(command.Contains("load "))
				{
					try
					{
						Plugin.Load((Magic.CutString("load ",command)[0]));
						Console.WriteLine("Success.");
					}
					catch
					{
						Console.WriteLine("Not found.");
					}
			       Console.WriteLine(Plugin.Plugins.Count + " Plugins loaded now.");
				}
				else if(command.Contains("rm "))
				{
					if(Magic.CutString("rm ",command)[0] == "-a" || Grimoire.Magic.CutString("rm ",command)[0] == "--all")
					{
						Plugin.Unload(Plugin.Plugins);
						Console.WriteLine("All Plugins was unloaded.");
			       	Console.WriteLine(Plugin.Plugins.Count + " Plugins loaded now.");
					}
					else
					{
						var del=Plugin.Plugins.FindAll((x) => x.GetType().ToString().Contains(Magic.CutString("rm ",command)[0]));
						Plugin.Unload(del);
						Console.WriteLine(del.Count + " Plugins was unloaded.");
			       	Console.WriteLine(Plugin.Plugins.Count + " Plugins loaded now.");
					}
				}
				else if(command=="ls")
				{
					foreach(var p in Plugin.Plugins)
					{
						Console.WriteLine(" - " + p.GetType().ToString());
					}
				}
				else if(command=="eventtest")
				{
					Plugin.CallEvent("test",null);
				}
				else if(Plugin.PluginExists(command))
				{
					Plugin.CallPlugin(command,"");
				}
				else
				{
					Console.WriteLine(command + " is not vaild command.");
				}
				Console.Write("Alice:> ");
			}
		}
		public static void UpdateCui()
		{
			Console.WriteLine("Updating...");
			try
			{
				Guignol.Update();
			}
			catch
			{
				Console.WriteLine("Failed to update repository datas.Please retry later.");
			}
		}
		public static void InstallCui(string name)
		{
			Console.WriteLine("Solving dependences...");
				Guignol.Install(name);
				Console.WriteLine(name + " is completely installed.");
		}
	}
}

