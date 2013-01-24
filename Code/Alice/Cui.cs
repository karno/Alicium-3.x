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
			Console.Write(
@"Alicium 3.x kernel v3.0
build 20.130.123

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
					Console.WriteLine(
@"exit ... exit from Alicium kernel.

load [File] ... Load a plugin file.

rm [Word] ... Unload plugins whose name contains the Word.

rm -a ... Unload all plugins.

ls ... Show the list of loaded plugins.

guignol [command] ... Execute Guignol plugin install/uninstall system.

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
				else if(command.Contains("guignol"))
				{
					try
					{
						gexec(command.Replace("guignol ",""));
					}
					catch(Exception e)
					{
						Console.WriteLine(e.ToString());
					}
				}
				else if(command.Contains("rm "))
				{
					if(Magic.CutString("rm ",command)[0] == "-a" 
					   || Grimoire.Magic.CutString("rm ",command)[0] == "--all")
					{
						Plugin.Unload(Plugin.Plugins);
						Console.WriteLine("All Plugins was unloaded.");
			       	Console.WriteLine(Plugin.Plugins.Count + " Plugins loaded now.");
					}
					else
					{
						var del=Plugin.Plugins.FindAll((x) => 
						 x.GetType().ToString().Contains(Magic.CutString("rm ",command)[0]));
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
				else if(command == null || command == ""){}
				else
				{
					Console.WriteLine(command + " is not vaild command.");
				}
				Console.Write("Alice:> ");
			}
		}
		static void gexec(string com)
		{
			var exec = Magic.CutString(" ",com);
			Action ghelp = () => 
			{
				Console.WriteLine(
@"Guignol plugin install/uninstall system

Usage : guignol install|remove pkg
        guignol command

Commands:
	update ... update repository datas.

	help ... show this.

	list ... show packages in repository datas.
	     -i ... only installed packages.
	     -n ... only not installed packages.
	     -t type ... only show packages whose type is it.
						types ... {Ui,Tool,Game,Develop}

	find word ... show packages whose name contains the word.
	     -i word ... only installed packages.
	     -n word ... only not installed packages.
	     -t type ... only show packages whose type is it.
						types ... {Ui,Tool,Game,Develop}
");
			};
			if(exec.Length==0)
			{
				ghelp();
			}
			switch(exec[0])
			{
			case "update":
				try
				{
					Guignol.Update();
				}
				catch(GuignolException e)
				{
					Console.WriteLine(e.Message);
				}
				break;
			
			case "install":
				if(exec.Length < 2) {ghelp();break;}
				try
				{
					Guignol.Install(exec[1]);
				}
				catch(GuignolException e)
				{
					Console.WriteLine(e.Message);
				}
				break;
				
			case "remove":
				if(exec.Length < 2) {ghelp();break;}
				try
				{
					Guignol.Remove(exec[1]);
				}
				catch(GuignolException e)
				{
					Console.WriteLine(e.Message);
				}
				break;
				
			case "list":
				if(exec.Length < 2)
				{
					new List<Package>(Settings.PackList)
						.ForEach(a=>Console.WriteLine(a.Name));
				}
				else
				{
					/*Action<Package> pred = (x) => {};
					for(int i=0;i<exec.Length-1;i++)
					{
						var s = exec[i+1];
						switch(s)
						{
						case "-i":
							pred += (x) => new List<Package>(Settings.Installed).Contains(x);
							break;
						case "-n":
							pred += (x) => !(new List<Package>(Settings.Installed).Contains(x));
							break;
						case "-t":
							pred += (x) => x.Type == (PluginType)Enum.Parse(typeof(PluginType),exec[i+2]);
							break;
						default:
							break;
						}
					}*/
				}
				break;
				
			case "find":
				if(exec.Length < 3)
				{
					new List<Package>(Settings.PackList)
						.FindAll(x=>x.Name.Contains(exec[1]))
							.ForEach(x=>Console.WriteLine(x.Name));
				}
				else
				{
					/*Action<Package> pred = (x) => {};
					for(int i=0;i<exec.Length-2;i++)
					{
						var s = exec[i+2];
						switch(s)
						{
						case "-i":
							pred += (x) => new List<Package>(Settings.Installed).Contains(x);
							break;
						case "-n":
							pred += (x) => !new List<Package>(Settings.Installed).Contains(x);
							break;
						case "-t":
							pred += (x) => x.Type == (PluginType)Enum.Parse(typeof(PluginType),exec[i+3]);
							break;
						default:
							break;
						}
					}*/
				}
				break;
				
			case "help":
				ghelp();
				break;
				
			default:
				ghelp();
				break;
			}
		}
	}
}

