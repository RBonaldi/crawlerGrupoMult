using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroSAH.Atividades
{
    public class InserirApontamento
    {
        public static void Entrada()
        {
            var document = Form1.ie.Document as IHTMLDocument3;

            while (document.getElementById("aspnetForm") == null) { }
        }

        public static void Acao()
        {
            var document = Form1.ie.Document as IHTMLDocument3;

            DateTime Atual = DateTime.Now;
            string chegada = System.String.Format("{0:HH:mm}", Atual.AddHours(-9.5));


            var faturado = document.getElementById("ctl00_ContentPlaceHolder1_rbtnTipoFaturamento_1");
            if (faturado != null)
            {
                faturado.click();
            }
            var data_1 = document.getElementById("ctl00_ContentPlaceHolder1_txtManhaInicio");
            if (data_1 != null)
            {
                data_1.innerText = horaSet(chegada);
            }
            var data_2 = document.getElementById("ctl00_ContentPlaceHolder1_txtManhaFim");
            if (data_2 != null)
            {
                data_2.innerText = "12:00";
            }
            var data_3 = document.getElementById("ctl00_ContentPlaceHolder1_txtTardeInicio");
            if (data_3 != null)
            {
                data_3.innerText = "13:00";
            }
            var data_4 = document.getElementById("ctl00_ContentPlaceHolder1_txtTardeFim");
            if (data_4 != null)
            {
                data_4.innerText = horaSet(System.String.Format("{0:HH:mm}", Atual));
            }

            var textArea = document.getElementById("ctl00_ContentPlaceHolder1_txtDescricao");
            if (textArea != null)
            {
                textArea.innerText = Form1.descricao;
            }
        }

        public static void Saida()
        {
        }

        public static string horaSet(string chegada)
        {

            int minutosChegada = Convert.ToInt32(chegada.Substring(4, 1));

            if (minutosChegada <= 5)
                chegada = chegada.Remove(chegada.Length - 1) + 5;
            else
            {
                int minuto = Convert.ToInt32(chegada.Substring(3, 1));
                int hora = Convert.ToInt32(chegada.Substring(0, 2));

                if (minuto != 5)
                    chegada = chegada.Remove(chegada.Length - 2) + (minuto + 1).ToString() + "0";
                else
                {
                    if (chegada.Substring(0, 1) == "0")
                        chegada = "0" + (hora + 1) + ":00";
                    else
                        chegada = (hora + 1) + ":00";
                }

            }

            return chegada;
        }
    }
}
