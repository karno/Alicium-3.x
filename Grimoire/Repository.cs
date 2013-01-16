using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;

namespace Grimoire
{
	public static class Guignol
	{
		public static List<Repository> Repos=new List<Repository>();
		public static void Update()
		{
			Console.WriteLine("Updating...");
			Repos.Clear();
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 
			foreach(string s in Settings.Repositories)
			{
				using(var wc = new WebClient())
				{
					wc.DownloadFile(s + ".repinfo","Settings/tmp");
					Repos.AddRange(Magic.XmlFRead<Repository[]>("Settings/tmp"));
					Console.WriteLine("Get: "+s);
				}
			}
			Console.WriteLine("Everything are updated.");
		}
		public static void Install(string name)
		{
			var p = Repos.Find(x=>x.Data.Name==name);
			Console.WriteLine("Downloading...");
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 
			if(p==null)throw new Exception("There isn't a package such as "+name + ".");
			using(var wc = new WebClient())
			{
				Directory.CreateDirectory("Plugins/"+name);
				wc.DownloadFile(p.Data.DlUrl,"Plugins/"+name+"tmp.zip");
				Console.WriteLine("Extracting...");
				using(ZipFile z=new ZipFile("Plugins/"+name+"tmp.zip"))
				{
					z.ExtractAll("Plugins/"+name+"/",ExtractExistingFileAction.OverwriteSilently);
				}
			}
			Console.WriteLine(name + "is installed.");
		}
	}
	public enum UpdateType
	{
		IMPORTANT,RECOMMENDED,DEVELOPPING
	}
	public enum PluginType
	{
		Ui,Tool,Game,Develop
	}
	public class Package
	{
		public string Name;
		public string Version;
		public string[] Depend;
		public PluginType Type;
		public string DlUrl;
	}
	public class Repository
	{
		public Package Data;
		public UpdateType UpdateInfo;
	}
}

