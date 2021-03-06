using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Linq;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

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
				throw new GuignolException("Failed to update." + e.Message);			
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
			var install = SolveDepend(hoge,SolveType.Obverse);
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
						wc.DownloadFile(new Uri(p.DlUrl.Replace("\"","")),"Plugins/tmp.zip");
						Console.WriteLine("Extracting...");
						var z = new FastZip();
						z.ExtractZip("Plugins/tmp.zip","Plugins/"+p.Name,"");
						File.Delete("Plugins/tmp.zip");
						Console.WriteLine("Registering...");
						var n = new List<Package>(Settings.Installed);
						n.FindAll(x=>x.Name==p.Name).ForEach(x=>n.Remove(x));
						n.Add(p);
						Settings.Installed = n.ToArray();
						Console.WriteLine(p.Name + " is installed.");
					}
					catch(Exception e)
					{
						throw new GuignolException("install failed. "+e.Message);
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
			var uninstall = SolveDepend(hoge,SolveType.Reverse);
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
						Directory.Delete("Plugins/"+p.Name,true);
						Console.WriteLine("Unregistering...");
						var n = new List<Package>(Settings.Installed);
						n.RemoveAll(x=>x.Name==p.Name);
						Settings.Installed = n.ToArray();
						Console.WriteLine(p.Name + " is removed.");
					}
					catch(Exception e)
					{
						throw new GuignolException("install failed. "+e.Message);
					}
			}
			Console.WriteLine(name + " is completely removed.");
		}
		/// <summary>
		/// Adds the repository.
		/// </summary>
		/// <param name='uri'>
		/// URI of the repository.
		/// </param>
		public static void AddRepository(Uri uri)
		{
			var l = Settings.RepUrls.ToList();
			l.Add(uri.ToString());
			Settings.RepUrls = l.ToArray();
		}
		/// <summary>
		/// Removes the repository.
		/// </summary>
		/// <param name='uri'>
		/// URI of the repository.
		/// </param>
		public static void RemoveRepository(Uri uri)
		{
			var l = Settings.RepUrls.ToList();
			l.Remove(uri.ToString());
			Settings.RepUrls = l.ToArray();
		}
		public enum SolveType
		{
			Obverse,Reverse
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
		public static Package[] SolveDepend(Package r,SolveType t)
		{
			try
			{
				var ret = new List<Package>();
				ret.Add(r);
				if(t == SolveType.Obverse)Solve(r,ref ret);
				else SolveR(r,ref ret);
				return ret.ToArray();
			}
			catch (Exception)
			{
				throw new GuignolException(
					"Some of Dependences isn't found from database." +
					"Please update repository datas and retry later.");
			}
		}
		private static void Solve(Package e,ref List<Package> l)
		{
			foreach(string s in e.Depend)
			{
					var ad=new List<Package>(Settings.PackList).Find(y=>y.Name==s);
					if(!l.Contains(ad))
					{
						l.Add(ad);
					}
					Solve(ad,ref l);
			}
		}
		private static void SolveR(Package e,ref List<Package> l)
		{
			var v = from p in Settings.Installed
				from q in p.Depend
				where q == e.Name
				select p;
			foreach(Package s in v)
			{
					if(!l.Contains(s))
					{
						l.Add(s);
					}
					SolveR(s,ref l);
			}
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
		public UpdateType UpdateInfo;
		public string[] IncludingDlls;
		public string[] Depend;
		public PluginType Type;
		public string DlUrl;
	}
	
}

