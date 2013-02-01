using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grimoire
{
	public static class AutoExec
	{
		public static void Add(Package p)
		{
			var l = new List<string>(Settings.AutoExec);
					l.Add(p.Name);
					Settings.AutoExec = l.ToArray();
		}
		public static void Remove(Package p)
		{
			var l = new List<string>(Settings.AutoExec);
					l.Remove(p.Name);
					Settings.AutoExec = l.ToArray();
		}
	}
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
				Magic.XmlFWrite(new List<Log>().ToArray(),"log.dat");
			}
			Logs = Magic.XmlFRead<Log[]>("log.dat").ToList();
			File.Delete("log.dat");
			var l= new Log(){When = DateTime.UtcNow,Text = text};
			Logs.Add(l);
			Magic.XmlFWrite(Logs.ToArray(),"log.dat");
			return l;
		}
		public static Log[] Flush()
		{
			File.Delete("log.dat");
			Magic.XmlFWrite(new List<Log>().ToArray(),"log.dat");
			var r = new List<Log>(Logs);
			Logs.Clear();
			return r.ToArray();
		}
		public static void SendToDeveloper()
		{
			
		}
	}
}

