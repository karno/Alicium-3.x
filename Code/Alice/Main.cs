using System;
using Grimoire;
using System.Deployment;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Alice
{
	public static class Margatroid
	{
		public static void Main(string[] args)
		{
			//buildtestrepo();
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
            var auto =
            from p in Settings.AutoExec
            from s in Settings.Installed
            where s.Name == p
            from n in s.IncludingDlls
            select "Plugins/" + s.Name + "/" + n;
            foreach (string l in auto)
            {
                var a = Plugin.Load(l);
                a.ForEach(x => Plugin.CallPlugin(x.GetType().ToString(), ""));
            }
			var load = 
				from p in Settings.Installed
				from s in p.IncludingDlls
                where !auto.Contains("Plugins/" + p.Name + "/" + s)
				select "Plugins/" + p.Name + "/" + s;
            foreach (string l in load)
            {
                Plugin.Load(l);
            }
		}
		static void buildtestrepo()
		{
			Magic.XmlFWrite(new Package[]{new Package()
			               {
				Name="Test",
				Version="1.0.0",
				UpdateInfo=UpdateType.IMPORTANT,
				Depend=new string[0],
				Type=PluginType.Develop,
				IncludingDlls=new string[]{"Test.dll"},
				DlUrl="\"https://raw.github.com/a1cn/Alicium-3.x/master/Repository/Test/v1.0.0/test.zip\""
			}},"a.xml");
		}
	}
}
