
// This file has been generated by the GUI designer. Do not modify.
namespace Goriath
{
	public partial class GoriathMain
	{
		private global::Gtk.Fixed fixed1;
		private global::Gtk.Label label1;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Goriath.GoriathMain
			this.Name = "Goriath.GoriathMain";
			this.Title = global::Mono.Unix.Catalog.GetString ("GoriathMain");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Goriath.GoriathMain.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Hello,Gtk!");
			this.fixed1.Add (this.label1);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label1]));
			w1.X = 149;
			w1.Y = 93;
			this.Add (this.fixed1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}