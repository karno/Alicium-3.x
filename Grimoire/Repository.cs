using System;

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
		public string[] Depend;
		public PluginType Type;
		public string DlUrl;
	}
}

