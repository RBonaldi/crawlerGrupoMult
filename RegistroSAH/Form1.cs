using Microsoft.Win32;
using mshtml;
using RegistroSAH.Atividades;
using SHDocVw;
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
using testeLogin;

namespace RegistroSAH
{
    public partial class Form1 : Form
    {
        public static InternetExplorer ie;
        private IWebBrowser2 _browser;
        private const string UrlLogin = "http://sah.grupomult.com.br/Seguranca/Login.aspx?logoof=yes";
        public static Action _before, _actionToRun, _after;
        public static string descricao;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            descricao = descricaoHJ.Text;

            ie = new InternetExplorer() { Visible = true, };
            ie.Navigate2(UrlLogin);

            _before = AbrirNavegador.Entrada;
            _actionToRun = AbrirNavegador.Acao;
            _after = AbrirNavegador.Saida;

            ie.DocumentComplete += Ie_DocumentComplete;
        }

        private void Ie_DocumentComplete(object pDisp, ref object URL)
        {
            new JobRun().Run(_before, _actionToRun, _after);
        }

        public void FecharSistema()
        {
            this.Close();
        }
    }
}
