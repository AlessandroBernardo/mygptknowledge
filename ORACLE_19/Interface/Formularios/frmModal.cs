using Consinco.Common.Windows.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizacao
{
    public partial class frmModal : C5FrmBaseDialog
    {
        public frmModal()
        {
            InitializeComponent();
        }

        private void frmModal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnLimpar.PerformClick();
                    break;
                case Keys.F8:
                    btnPesquisar.PerformClick();
                    break;
                case Keys.F10:
                    btnSair.PerformClick();
                    break;
            }
        }
    }
}
