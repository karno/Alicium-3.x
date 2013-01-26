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
        public override void Initalize()
        {
            Console.WriteLine("* Initalize Shanghai Classic UI");
        }
        public override void Call(object o)
        {
            new Main().ShowDialog();
        }
        public override void Dying()
        {
            
        }
    }
}
