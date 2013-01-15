using System;
using Grimoire;

namespace Test
{
	public class Hoge : PluginBase
	{
		Events e;
		public override void Initalize (object o)
		{
			Console.WriteLine("Hogehoge~~" + o.ToString());
		}
		public override void Dying ()
		{
			Console.WriteLine("dustboxxxx");
			e["test"] -= foo;
		}
		public override void EventSet (Events _e)
		{
			e = _e;
			e["test"] += foo;
		}
		public void foo(object sender,EventArgs e)
		{
			Console.WriteLine("foooooooooooo!!");
		}
	}
	public class Piyo : PluginBase
	{
		Events e;
		public override void Initalize (object o)
		{
			Console.WriteLine("Pretty Bird "+o.ToString());
		}
		public override void Dying ()
		{
			Console.WriteLine("piyo!");
			e["test"] -= piyopiyo;
		}
		public override void EventSet (Events _e)
		{
			e = _e;
			e["test"] += piyopiyo;
		}
		public void piyopiyo(object sender,EventArgs e)
		{
			Console.WriteLine("piyopiyo");
		}
	}
}

