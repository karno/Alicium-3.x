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
			Console.WriteLine("Updating...");
			var Dl=new List<Package>();
			try
			{
				ServicePointManager.ServerCertificateValidationCallback = (a,b,c,d) => true; 
				foreach(string s in Settings.RepUrls)
				{
					using(var wc = new WebClient())
					{
						wc.DownloadFile(s + ".repinfo","Settings/tmp");
						Console.WriteLine("Hit: "+s);
						Dl.AddRange(Magic.XmlFRead<Package[]>("Settings/tmp"));
					}
				}
				File.Delete("Settings/tmp");
				Settings.PackList = Dl.ToArray();
				Console.WriteLine("Repository datas is updated successfully.");
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
		public static void Install(string name)
		{
			Console.WriteLine("Solving dependences...");
			var hoge = new List<Package>(Settings.PackList).Find(x=>x.Name==name);
			var install = SolveDepend(hoge);
			Console.WriteLine("Solved successfully.");
			ServicePointManager.ServerCertificateValidationCallback = (a,b,c,d) => true; 
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
						//Directory.CreateDirectory("Plugins/"+p.Name);
						wc.DownloadFile(new Uri(p.DlUrl.Replace("\"","")),"Plugins/tmp.zip");
						Console.WriteLine("Extracting...");
						using(ZipFile z=new ZipFile("Plugins/tmp.zip"))
						{
							Console.WriteLine("To : Plugins/"+p.Name);
							z.ExtractAll(@"Plugins\"+p.Name+@"\", 
							             ExtractExistingFileAction.OverwriteSilently);
						}
						File.Delete("tmp");
						Console.WriteLine("Registering...");
						var n = new List<Package>(Settings.Installed);
						n.Add(p);
						Settings.Installed = n.ToArray();
						Console.WriteLine(p.Name + " is installed.");
					}
					catch(Exception e)
					{
						throw e;
					}
				}
			}
			Console.WriteLine(name + " is completely installed.");
		}
		/// <summary>
		/// Remove the package from Alicium System.
		/// </summary>
		/// <param name='name'>
		/// Name of the plugin.
		/// </param>
		/// <exception cref='GuignolException'>
		/// Is thrown when the uninstalletion failed.
		/// </exception>
		public static void Remove(string name)
		{
			Console.WriteLine("Solving dependences...");
			var hoge = new List<Package>(Settings.Installed).Find(x=>x.Name==name);
			var uninstall = SolveDepend(hoge);
			Console.WriteLine("Solved successfully.");
			foreach(Package p in uninstall)
			{
				if(p==null)
				{
					throw new GuignolException("There isn't a package such as "+p.Name + ".");
				}
					try
					{
						Console.WriteLine("Deleting "+p.Name + " now...");
						Directory.Delete("Plugins"+p.Name,true);
						Console.WriteLine("Unregistering...");
						var n = new List<Package>(Settings.Installed);
						n.Remove(p);
						Settings.Installed = n.ToArray();
						Console.WriteLine(p.Name + " is removed.");
					}
					catch(Exception e)
					{
						throw e;
					}
			}
			Console.WriteLine(name + " is completely removed.");
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
				if(!new List<Package>(Settings.PackList).Exists(x=>x.Name==s))
				{
					throw new GuignolException(
						"Some of Dependences isn't found from database.\n" +
						"Please update repository datas and retry later.");
				}
				var ad=new List<Package>(Settings.PackList).Find(y=>y.Name==s);
				if(!l.Contains(ad))
				{
					l.Add(ad);
				}
				Solve(ad,ref l);
			}
		}
	}
}

