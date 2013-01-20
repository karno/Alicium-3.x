using System;
using Grimoire;

namespace Test
{
	public class Hoge : PluginBase
	{
		public override void Initalize ()
		{
			Console.WriteLine("hoge init!");
			Plugin.AddToEvent("test",hoge);
		}
		public override void Call (object o)
		{
			Console.WriteLine("hoge");
		}
		public override void Dying ()
		{
			Console.WriteLine("hoge died.");
			Plugin.RemoveFromEvent("test",hoge);
		}
		public void hoge(object o,AliciumEventArgs e)
		{
			Console.WriteLine("hoge event");
		}
	}
	public class Piyo : PluginBase
	{
		public override void Initalize ()
		{
			Console.WriteLine("piyo init!");
			Plugin.AddToEvent("test",piyo);
		}
		public override void Call (object o)
		{
			Console.WriteLine("piyo");
		}
		public override void Dying ()
		{
			Console.WriteLine("piyo died.");
			Plugin.RemoveFromEvent("test",piyo);
		}
		public void piyo(object o,AliciumEventArgs e)
		{
			Console.WriteLine("piyo event");
		}
	}
}

