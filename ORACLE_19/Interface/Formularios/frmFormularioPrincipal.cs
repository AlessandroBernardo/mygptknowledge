
using Consinco.Common.Windows.Components;
using Customizacao.Desktop.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizacao
{
    public partial class frmFormularioPrincipal : C5FrmBaseMain
    {
        private Customizacao.Desktop.Customizacao.Servico.ServicoCustomizacao servicoCustomizacao;
        public frmFormularioPrincipal()
        {
            InitializeComponent();
            servicoCustomizacao = new Desktop.Customizacao.Servico.ServicoCustomizacao(C5FrmBaseLoginSistema.connectionString);
        }

        private void frmFormularioPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnLimpar.PerformClick();
                    break;
                case Keys.F3:
                    btnIncluir.PerformClick();
                    break;
                case Keys.F4:
                    btnAtualizar.PerformClick();
                    break;
                case Keys.F5:
                    btnExcluir.PerformClick();
                    break;
                case Keys.F7:
                    btnTabela.PerformClick();
                    break;
                case Keys.F8:
                    btnPesquisar.PerformClick();
                    break;
                case Keys.F9:
                    btnImprimir.PerformClick();
                    break;
                case Keys.F10:
                    btnSair.PerformClick();
                    break;
                case Keys.F11:
                    btnInicio.PerformClick();
                    break;
                case Keys.PageUp:
                    btnAnterior.PerformClick();
                    break;
                case Keys.PageDown:
                    btnProximo.PerformClick();
                    break;
                case Keys.F12:
                    btnFinal.PerformClick();
                    break;
            }
        }

        private void frmFormularioPrincipal_Shown(object sender, EventArgs e)
        {
            C5FrmWaiting.CloseForm();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            using (frmLoading frm = new frmLoading(Buscar, "Efetuando Busca...."))
            {
                frm.ShowDialog(this);
            }
        }
        void Buscar()
        {
            //pausa por 5 segundos
            Thread.Sleep(5000);
        }
    }
}
