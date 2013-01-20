using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;

namespace Grimoire
{
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
		public string[] Depend;
		public PluginType Type;
		public string DlUrl;
	}
}
