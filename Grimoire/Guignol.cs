using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;

namespace Grimoire
{
	/// <summary>
	/// Guignol the package management system.
	/// </summary>
	/// <exception cref='GuignolException'>
	/// Is thrown when the exception happens in Guignol.
	/// </exception>
	public static class Guignol
	{
		/// <summary>
		/// Update guignol's package datas.
		/// </summary>
		/// <exception cref='GuignolException'>
		/// Is thrown when Guignol failed to update package datas.
		/// </exception>
		public static void Update()
		{
			var Dl=new List<Package>();
			try
			{
				ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 
				foreach(string s in Settings.RepUrls)
				{
					using(var wc = new WebClient())
					{
						wc.DownloadFile(s + ".repinfo","Settings/tmp");
						Dl.AddRange(Magic.XmlFRead<Package[]>("Settings/tmp"));
						Console.WriteLine("Hit: "+s);
					}
				}
				File.Delete("Settings/tmp");
				Settings.PackList.Clear();
				Settings.PackList = Dl;
			}
			catch(Exception e)
			{
				throw new GuignolException(e.Message);			
			}
		}
		/// <summary>
		/// Install a package in Alicium system.
		/// </summary>
		/// <param name='name'>
		/// Name of package you want to install.
		/// </param>
		/// <exception cref='GuignolException'>
		/// Is thrown when some exception happens in the installetion.
		/// </exception>
		public static void Install(string name)
		{
			var hoge = Settings.PackList.Find(x=>x.Name==name);
			var install = SolveDepend(hoge);
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 
			foreach(Package p in install)
			{
				if(p==null)
				{
					throw new GuignolException("There isn't a package such as "+p.Name + ".");
				}
				using(var wc = new WebClient())
				{
					try
					{
						Console.WriteLine("Downloading From : "+p.DlUrl);
						Directory.CreateDirectory("Plugins/"+p.Name);
						wc.DownloadFile(p.DlUrl,"Plugins/tmp");
						Console.WriteLine("Extracting...");
						using(ZipFile z=new ZipFile("Plugins/tmp"))
						{
							z.ExtractAll("Plugins/"+p.Name+"/",ExtractExistingFileAction.OverwriteSilently);
						}
						File.Delete("tmp");
						Console.WriteLine(p.Name + "is installed.");
					}
					catch(Exception e)
					{
						throw new GuignolException(e.Message);
					}
				}
			}
		}
		/// <summary>
		/// Solve the dependence of package.
		/// </summary>
		/// <returns>
		/// Packages that is needed to install.
		/// </returns>
		/// <param name='r'>
		/// A package that you want to solve its dependence. 
		/// </param>
		/// <exception cref='GuignolException'>
		/// Is thrown when some exception happens in solving dependence.
		/// </exception>
		public static Package[] SolveDepend(Package r)
		{
			var ret = new List<Package>();
			ret.Add(r);
			Solve(r,ref ret);
			return ret.ToArray();
		}
		private static void Solve(Package e,ref List<Package> l)
		{
			foreach(string s in e.Depend)
			{
				if(!Settings.PackList.Exists(x=>x.Name==s))
				{
					throw new GuignolException("Some of Dependences isn't found from database.\nPlease update repository datas and retry later.");
				}
				var ad=Settings.PackList.Find(y=>y.Name==s);
				if(!l.Contains(ad))
				{
					l.Add(ad);
				}
				Solve(ad,ref l);
			}
		}
	}
}

