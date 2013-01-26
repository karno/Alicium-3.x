using System;
using System.Collections.Generic;
using System.IO;

namespace Grimoire
{
	public static class Settings
	{
		/// <summary>
		/// Gets or sets the repository urls.
		/// </summary>
		/// <value>
		/// The repository urls.
		/// </value>
		static string[] _u=new string[0];
		public static string[] RepUrls
		{
			get
			{
				if(!File.Exists("Settings/RepoUrls.xml"))
				{
					Magic.XmlFWrite<string[]>(new string[0],"Settings/RepoUrls.xml");
				}
				_u = Magic.XmlFRead<string[]>("Settings/RepoUrls.xml");
				return _u;
			}
			set
			{
				_u = value;
				File.Delete("Settings/RepoUrls.xml");
				Magic.XmlFWrite<string[]>(_u,"Settings/RepoUrls.xml");
			}
		}
		/// <summary>
		/// Gets or sets the package list.
		/// </summary>
		/// <value>
		/// The package list.
		/// </value>
		static Package[] _p=new Package[0];
		public static Package[] PackList
		{
			get
			{
				if(!File.Exists("Settings/RepoData.xml"))
				{
					Magic.XmlFWrite<Package[]>(new Package[0],"Settings/RepoData.xml");
				}
				_p = Magic.XmlFRead<Package[]>("Settings/RepoData.xml");
				return _p;
			}
			set
			{
				_p = value;
				File.Delete("Settings/RepoData.xml");
				Magic.XmlFWrite<Package[]>(_p,"Settings/RepoData.xml");
			}
		}
		/// <summary>
		/// Gets or sets the installed package list.
		/// </summary>
		/// <value>
		/// The installed package list.
		/// </value>
		static Package[] _i=new Package[0];
		public static Package[] Installed
		{
			get
			{
				if(!File.Exists("Settings/Installed.xml"))
				{
					Magic.XmlFWrite<Package[]>(new Package[0],"Settings/Installed.xml");
				}
				_i = Magic.XmlFRead<Package[]>("Settings/Installed.xml");
				return _i;
			}
			set
			{
				_i = value;
				File.Delete("Settings/Installed.xml");
				Magic.XmlFWrite<Package[]>(_i,"Settings/Installed.xml");
			}
		}
		static string[] _a=new string[0];
		public static string[] AutoExec
		{
			get
			{
				if(!File.Exists("Settings/AutoExec.xml"))
				{
					Magic.XmlFWrite(new string[0],"Settings/AutoExec.xml");
				}
				_a = Magic.XmlFRead<string[]>("Settings/AutoExec.xml");
				return _a;
			}
			set
			{
				_a = value;
                File.Delete("Settings/AutoExec.xml");
				Magic.XmlFWrite(_a,"Settings/AutoExec.xml");
			}
		}
	}
}
 
