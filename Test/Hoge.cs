using System;
using Grimoire;

namespace Test
{
	public class Hoge : PluginBase
	{
		public override void Initalize ()
		{
			Console.WriteLine("Hogehoge~~");
		}
		public override void Dying ()
		{
			Console.WriteLine("dustboxxxx");
		}
	}
	public class Piyo : PluginBase
	{
		public override void Initalize ()
		{
			Console.WriteLine("Pretty Bird");
		}
		public override void Dying ()
		{
			Console.WriteLine("piyo!");
		}
	}
}

