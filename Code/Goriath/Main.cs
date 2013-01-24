using System;
using Gtk;
using Grimoire;

namespace Goriath
{
	public class Init : PluginBase
	{
		MainWindow win;
		public override void Initalize ()
		{
			Console.WriteLine("* Initalize Goriath Gtk# UI");
		}
		public override void Call (object o)
		{
			Application.Init ();
			win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
		public override void Dying ()
		{
			Console.WriteLine("* Killing Goriath Gtk# UI");
			win.Destroy();
		}
	}
}
