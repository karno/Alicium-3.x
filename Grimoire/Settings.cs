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
		/// <summary>
		/// Gets or sets the package list.
		/// </summary>
		/// <value>
		/// The package list.
		/// </value>
		public static List<Package> PackList
		{
			get
			{
				if(!File.Exists("Settings/RepoData.xml"))
				{
					Magic.XmlFWrite<List<Package>>(new List<Package>(),"Settings/RepoData.xml");
				}
				return Magic.XmlFRead<List<Package>>("Settings/RepoData.xml");
			}
			set
			{
				
				Magic.XmlFWrite<List<Package>>(value,"Settings/RepoData.xml");
			}
		}
		
	}
}

