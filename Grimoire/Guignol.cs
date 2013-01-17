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
		public static void Update()
		{
			var Dl=new List<Repository>();
			try
			{
				ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 
				foreach(string s in Settings.RepUrls)
				{
					using(var wc = new WebClient())
					{
						wc.DownloadFile(s + ".repinfo","Settings/tmp");
						Dl.AddRange(Magic.XmlFRead<Repository[]>("Settings/tmp"));
						Console.WriteLine("Hit: "+s);
					}
				}
				File.Delete("Settings/tmp");
				Settings.RepList.Clear();
				Settings.RepList = Dl;
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		public static void Install(string name)
		{
			var hoge = Settings.RepList.Find(x=>x.Data.Name==name);
			var install = SolveDepend(hoge);
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 
			foreach(Repository p in install)
			{
				if(p==null)
				{
					throw new GuignolException("There isn't a package such as "+p.Data.Name + ".");
				}
				using(var wc = new WebClient())
				{
					try
					{
						Console.WriteLine("Downloading From : "+p.Data.DlUrl);
						Directory.CreateDirectory("Plugins/"+p.Data.Name);
						wc.DownloadFile(p.Data.DlUrl,"Plugins/tmp");
						Console.WriteLine("Extracting...");
						using(ZipFile z=new ZipFile("Plugins/tmp"))
						{
							z.ExtractAll("Plugins/"+p.Data.Name+"/",ExtractExistingFileAction.OverwriteSilently);
						}
						File.Delete("tmp");
						Console.WriteLine(p.Data.Name + "is installed.");
					}
					catch(Exception e)
					{
						throw e;
					}
				}
			}
		}
		public static Repository[] SolveDepend(Repository r)
		{
			var ret = new List<Repository>();
			ret.Add(r);
			Solve(r,ref ret);
			return ret.ToArray();
		}
		private static void Solve(Repository e,ref List<Repository> l)
		{
			foreach(string s in e.Data.Depend)
			{
				if(!Settings.RepList.Exists(x=>x.Data.Name==s))
				{
					throw new GuignolException("Some of Dependences isn't found from database.\nPlease update repository datas and retry later.");
				}
				var ad=Settings.RepList.Find(y=>y.Data.Name==s);
				if(!l.Contains(ad))
				{
					l.Add(ad);
				}
				Solve(ad,ref l);
			}
		}
	}
}

