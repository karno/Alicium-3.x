using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grimoire;
using System.Windows.Forms;

namespace Shanghai
{
    public class Init : PluginBase
    {
		Main m;
        public override void Initalize()
        {
            Console.WriteLine("* Initalize Shanghai Classic UI");
        }
        public override void Call(object o)
        {
            m = new Main();
			m.ShowDialog();
        }
        public override void Dying()
        {
            Console.WriteLine("* Killing Shanghai Classic UI");
			try{m.Close();}catch{}
        }
    }
}
