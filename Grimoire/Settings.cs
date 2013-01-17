using System;
using System.Collections.Generic;
using System.IO;

namespace Grimoire
{
	public static class Settings
	{
		public static List<string> RepUrls
		{
			get
			{
				if(!File.Exists("Settings/RepoUrls.xml"))
				{
					Magic.XmlFWrite<List<string>>(new List<string>(),"Settings/RepoUrls.xml");
				}
				return Magic.XmlFRead<List<string>>("Settings/RepoUrls.xml");
			}
			set
			{
				
				Magic.XmlFWrite<List<string>>(value,"Settings/RepoUrls.xml");
			}
		}
		public static List<Repository> RepList
		{
			get
			{
				if(!File.Exists("Settings/RepoData.xml"))
				{
					Magic.XmlFWrite<List<Repository>>(new List<Repository>(),"Settings/RepoData.xml");
				}
				return Magic.XmlFRead<List<Repository>>("Settings/RepoData.xml");
			}
			set
			{
				
				Magic.XmlFWrite<List<Repository>>(value,"Settings/RepoData.xml");
			}
		}
		
	}
}

