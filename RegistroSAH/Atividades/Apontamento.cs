using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroSAH.Atividades
{
    public class Apontamento
    {
        public static void Entrada()
        {
            var document = Form1.ie.Document as IHTMLDocument3;

            while (document.getElementById("FramesetCorpo") == null) { }
        }

        public static void Acao()
        {
            Form1.ie.Navigate("http://sah.grupomult.com.br/Apontamento/ApontamentoEdit.aspx");
        }

        public static void Saida()
        {
            Form1._before = InserirApontamento.Entrada;
            Form1._actionToRun = InserirApontamento.Acao;
            Form1._after = InserirApontamento.Saida;

            Form1.ie.Refresh();
        }
    }
}
