using System;

namespace Goriath
{
	public partial class GoriathMain : Gtk.Window
	{
		public GoriathMain () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

