using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twitterizer;
using Twitterizer.Streaming;

namespace Shanghai
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
