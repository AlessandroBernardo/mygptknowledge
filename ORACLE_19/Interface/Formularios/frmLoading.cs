using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizacao.Desktop.Formularios
{
    public partial class frmLoading : Form
    {
        public Action Worker { get; set; }
        private string _mensagem;
        public frmLoading(Action worker, string mensagem)
        {
            InitializeComponent();
            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            Worker = worker;
            _mensagem = mensagem;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_mensagem != "")
            {
                lblMensagem.Text = _mensagem;
            }
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
