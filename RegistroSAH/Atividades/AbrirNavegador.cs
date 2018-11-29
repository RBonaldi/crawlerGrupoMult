using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroSAH.Atividades
{
    public class AbrirNavegador
    {
        public static void Entrada()
        {
        }

        public static void Acao()
        {
            var document = Form1.ie.Document as IHTMLDocument3;

            var User = document.getElementById("txtLogin");
            User.innerText = "[SeuNome]";

            var password = document.getElementById("txtSenha");
            password.innerText = "[SuaSenha]";

            var SignIn = document.getElementById("btnEntrar");
            SignIn.click();
        }

        public static void Saida()
        {
            Form1._before = Apontamento.Entrada;
            Form1._actionToRun = Apontamento.Acao;
            Form1._after = Apontamento.Saida;
        }
    }
}
