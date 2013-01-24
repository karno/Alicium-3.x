using System;
using System.Collections.Generic;
using System.IO;

namespace Grimoire
{
	public class Log
	{
		public static List<Log> Logs;
		public DateTime When;
		public string Text;
		public static Log Add(string text)
		{
			if(!File.Exists("log.dat"))
			{
				File.Create("log.dat");
				Magic.XmlFWrite(new List<Log>(),"log.dat");
			}
			Logs = Magic.XmlFRead<List<Log>>("log.dat");
			var l= new Log(){When = DateTime.UtcNow,Text = text};
			Logs.Add(l);
			Magic.XmlFWrite(Logs,"log.dat");
			return l;
		}
		public static Log[] Flush()
		{
			Magic.XmlFWrite(new List<Log>(),"log.dat");
			var r = new List<Log>(Logs);
			Logs.Clear();
			return r.ToArray();
		}
		public static void SendToDeveloper()
		{
			//TODO:Think how to send.
		}
	}
}

