using System;
using Grimoire;

namespace Goriath
{
	public class Init : PluginBase
	{
		public override void Initalize ()
		{
			
		}
		public override void Call (object o)
		{
			new GoriathMain().Show();
		}
		public override void Dying ()
		{
			
		}
	}
}

