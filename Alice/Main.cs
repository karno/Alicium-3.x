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
			Init();
			if(args.Length != 0 && args[0] == "-c")
			{
				Cui.CuiMain();
			}
		}
		static void Init()
		{
			if(!Directory.Exists("Plugins"))Directory.CreateDirectory("Plugins");
			if(!Directory.Exists("Settings"))Directory.CreateDirectory("Settings");
			if(!new List<string>(Settings.RepUrls).Contains(
				"https://raw.github.com/a1cn/Alicium-3.x/master/Repository/"))
			{
				var a = new List<string>(Settings.RepUrls);
				a.Add("https://raw.github.com/a1cn/Alicium-3.x/master/Repository/");
				//Add official repository
				Settings.RepUrls=a.ToArray();
			}
		}
	}
}
