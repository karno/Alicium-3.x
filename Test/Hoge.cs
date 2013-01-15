using System;
using Grimoire;

namespace Test
{
	public class Hoge : PluginBase
	{
		public override void Initalize ()
		{
			Console.WriteLine("Initalized");
		}
		public override void Dying ()
		{
			Console.WriteLine("Died");
		}
	}
}

