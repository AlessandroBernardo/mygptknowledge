using Consinco.Common.Windows.Components;
using Consinco.Common.Windows.Helpers;
using Kike.Data.Oracle.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizacao
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            C5FrmBaseLoginSistema formLogin;
            bool necessitaAutenticacao = true;

            //informacoes da aplicação
            //não mudar
                ContextApp.Sistema = "ESPECCLIENTE";
                ContextApp.SistemaDescricao = "Customização";
                ContextApp.SistemaSigla = "ESPECCLIENTE";
                ContextApp.Modulo = "ESPECCLIENTE";
                ContextApp.ModuloDescricao = "Customização";
                ContextApp.ModuloSigla = "ESPECCLIENTE";

            ContextApp.SeqAplicacao = 0;
            ContextApp.CodAplicacao = "ESP0000001";
            ContextApp.NomeAplicacao = "[nome da aplicacao]";


            var assembly = Assembly.GetExecutingAssembly();
            ContextApp.Objeto = assembly.ManifestModule.Name;
            ContextApp.Versao = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (necessitaAutenticacao == true)
            {
                if (args.Length > 0)
                {
                    //chamou pelo centura
                    if (args.Where(p => p.ToLower().Equals("appmenu")).Count() > 0)
                    {
                        //args[0] = appmenu
                        //args[1] = usuário
                        //args[2] = senha
                        //args[3] = empresa
                        //args[4] = banco
                        //args[5] = usuário banco
                        //args[6] = senha banco

                        //Segue abaixo exemplo de utilização via command line arguments. Ou seja, a partir do 413 já são os argumentos passados via aplicação
                        //appmenu CONSINCO consinco 1 ORA11G TOZZO TOZZO 413

                        formLogin = new C5FrmBaseLoginSistema(args[1], args[2], args[4], args[3], args[5], args[6], true);
                        formLogin.VersionControl = false;
                        formLogin.UseFadeEffects = true;

                        formLogin.frmOpen = new frmFormularioPrincipal();//caso necessita pegar outros parametros, pegar a partir do 7 args[7]
                        formLogin.frmOpen.Text = $"{ContextApp.NomeAplicacao}";
                        Application.Run(formLogin);
                    }
                    else {
                        //chamou pelo menu
                        if (args.Length >= 3)
                        {
                            //args[0] = usuário
                            //args[1] = senha
                            //args[2] = empresa
                            //args[3] = banco
                            
                            formLogin = new C5FrmBaseLoginSistema(args[0], args[1], args[3], args[2],false);
                         
                            formLogin.VersionControl = false;
                            formLogin.UseFadeEffects = true;

                            formLogin.frmOpen = new frmFormularioPrincipal();
                            formLogin.frmOpen.Text = $"{ContextApp.NomeAplicacao}";
                            Application.Run(formLogin);
                        }
                        else {
                            //Parâmetros obrigatórios
                            //[usuario] [senha] [empresa] [baseOracle] ***NESSA ORDEM....e com o ESPAÇO entre as tags***
                            C5CustomMessageBox.Show("Para abertura através do menu deve ser passado ao menos os 4 parâmetros obrigatórios.","Operação inválida", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    formLogin = new C5FrmBaseLoginSistema();
                    formLogin.frmOpen = new frmFormularioPrincipal();
                    formLogin.VersionControl = false;
                    formLogin.UseFadeEffects = true;
                    formLogin.Text = "Customização";
                    formLogin.frmOpen.Text = $"{ContextApp.NomeAplicacao}";

                    Application.Run(formLogin);
                }
            }
            else {

                formLogin = new C5FrmBaseLoginSistema(true);
                var formMain = new frmFormularioPrincipal();
                formLogin.frmOpen.Text = $"{ContextApp.NomeAplicacao}";
                Application.Run(formMain);
            }
        }
    }
}
