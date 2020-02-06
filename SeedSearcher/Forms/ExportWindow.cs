using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedSearcherGui
{
    public partial class ExportWindow : Form
    {
        public ExportWindow(string msg)
        {
            InitializeComponent();
            ExportText.Text = msg;
        }
    }
}
