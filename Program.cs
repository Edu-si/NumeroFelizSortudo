using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InicioPrograma();
            Console.ReadKey();
        }


        private static void InicioPrograma(){
            
            string entrada;

            Console.WriteLine("Digite um número");
            entrada = Console.ReadLine();
            try 
        	{	        
		            bool IsSortudo = VerificarNumeroSortudo(entrada);
                    string mensagem = entrada + " - ";
               
                     if (IsSortudo)
                        mensagem += "Número Sortudo e ";
                     else
                        mensagem += "Número Não-Sortudo e ";
             
                     bool Isfeliz = VerificarNumeroFeliz(entrada);
                     if (Isfeliz)
                        mensagem += "Feliz.";
                     else
                        mensagem += "Não-Feliz.";

                    Console.WriteLine(mensagem);
                    InicioPrograma();

                }
	            catch (Exception)
	            {
                    Console.WriteLine("Digite um número valido");
                    InicioPrograma();
	            }
        }

        private static bool VerificarNumeroFeliz(string entrada)
        {
            double valorFinal = 0;
            for (int i = 0; i < 100; i++)
            {

                //Calculo dos valores
                for (int j = 0; j < entrada.Length; j++)
                {
                    double somaValores = Math.Pow(Convert.ToDouble(entrada[j].ToString()), 2);
                    valorFinal += somaValores;
                }

                if (valorFinal == 1)
                {
                    return true;
                }
                else
                {
                    entrada = valorFinal.ToString();
                    valorFinal = 0;
                }

            }
            return false;
        }


        private static bool VerificarNumeroSortudo(string entrada)
        {
            List<int> lista = new List<int>();

            for (int i = 1; i <= Convert.ToInt32(entrada); i++)
            {
                lista.Add(i);
            }

            //posição múltipla de 2 
            int posicao = 1;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (i == posicao)
                {
                    lista.RemoveAt(posicao);
                    posicao = posicao + 1;
                }
            }

            //posição múltipla de 3 
            posicao = 2;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (i == posicao)
                {
                    lista.RemoveAt(posicao);
                    posicao = posicao + 2;
                }
            }

            //posição múltipla de 7
            posicao = 6;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (i == posicao)
                {
                    lista.RemoveAt(posicao);
                    posicao = posicao + 6;
                }
            }

            var achou = lista.FindAll(x => x == Convert.ToInt32(entrada));

            return achou.Count == 1 ? true : false;

        }

    }
}
