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
				//Guignol.Update();
				//Guignol.Install("Test");
				Cui.CuiMain();
			}
		}
		static void Init()
		{
			if(!Directory.Exists("Plugins"))Directory.CreateDirectory("Plugins");
			if(!Directory.Exists("Settings"))Directory.CreateDirectory("Settings");
			if(!Settings.RepUrls.Contains("https://raw.github.com/a1cn/Alicium-3.x/master/Repository/"))
			{
				Settings.RepUrls.Add("https://raw.github.com/a1cn/Alicium-3.x/master/Repository/");
			}
		}
	}
}
