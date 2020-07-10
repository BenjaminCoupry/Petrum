using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petrum
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void buttJoindre_Click(object sender, EventArgs e)
        {
            Petrum newGame = new Petrum(false, Convert.ToInt32(tbPort.Text), tbIP.Text);
            Visible = false;
            if(!newGame.IsDisposed)
            {
                newGame.ShowDialog();
            }
            Visible = true;
        }

        private void buttHeberger_Click(object sender, EventArgs e)
        {
            Petrum newGame = new Petrum(true, Convert.ToInt32(tbPort.Text));
            Visible = false;
            if(!newGame.IsDisposed)
            {
                newGame.ShowDialog();
            }
            Visible = true;
        }
    }
}
