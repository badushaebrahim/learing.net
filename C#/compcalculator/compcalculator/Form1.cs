using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compcalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addvaltodisplay(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
        }

        private void docalculation(object sender,EventArgs e)
        {
            String eq = textBox1.Text;
            var result = new DataTable().Compute(eq, null);
            textBox1.Text = result.ToString();
        }
        private void clear(object sender,EventArgs e)
        {
            textBox1.Text = "0";
        }
    }
}
