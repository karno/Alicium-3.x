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
			Console.Write("Alice: > ");
			var Found = new List<Grimoire.PluginBase>();
			while(true)
			{
				var command=Console.ReadLine();
				if(command=="exit")
				{
					Console.WriteLine("halt.");
					break;
				}
				else if(command.Contains("load "))
				{
					try
					{
						Found.AddRange(Grimoire.Plugin.Load(Grimoire.Magic.CutString("load ",command)[0]));
						Console.WriteLine("Success.");
					}
					catch(FileNotFoundException)
					{
						Console.WriteLine("Not found.");
					}
			       Console.Write(Found.Count + " Plugins loaded now.\nAlice> ");
				}
				else if(command=="ls")
				{
					foreach(var p in Found)
					{
						Console.WriteLine(" - " + p.GetType().ToString());
					}
				}
				else if(Found.Exists((x) => x.GetType().ToString() == command))
				{
					Found.Find((x) => x.GetType().ToString() == command).Initalize();
				}
				else
				{
					Console.WriteLine(command + " is not vaild command.");
				}
				Console.Write("Alice: > ");
			}
		}
	}
}

