using System;
using System.Collections.Generic;

namespace ExplorandoMarte
{
    public class Program
    {
        static void Main()
        {
            string result = "x";
            List<string> argss = new List<string>();
            while (!string.IsNullOrEmpty(result))
            {
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result))
                    argss.Add(result.ToUpper());
            }
            string[] args = argss.ToArray();

            try
            {
                if (args == null || args.Length < 2)
                {
                    Console.WriteLine("Entrada fornecida incompatível com o esperado!");
                    return;
                }
                int pulo = 0;
                bool continua = true;
                string dadosSonda = string.Empty;
                string coordenadas = string.Empty;
                string comandos = string.Empty;
                Sonda _sonda = new Sonda();
                while (continua)
                {
                    dadosSonda = getDadosSonda(args, pulo) == string.Empty ? dadosSonda : getDadosSonda(args, pulo);
                    coordenadas = getCoordenadas(args, pulo);
                    comandos = getComandos(args, pulo);
                    pulo += 3;
                    if (_sonda.DadosDaSonda != dadosSonda)
                        _sonda = new Sonda(dadosSonda);
                    else
                        pulo -= 1;
                    Console.WriteLine(_sonda.MovimentaSonda(comandos, coordenadas));
                    continua = pulo < args.Length;
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado (Quantidade/Formato inadequados de parametros informados, favor verificar e tentar novamente) !");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado ({ex.Message}) .");
            }
        }

        private static string getDadosSonda(string[] args, int pulo)
        {
            for (int index = pulo; index <= pulo + 3; index++)
            {
                foreach (char c in args[index].ToCharArray())
                    if (Sonda.getDirecoesPossiveis.Contains(c) || Sonda.getComandosPossiveis.Contains(c))
                        return string.Empty;
                return args[pulo];
            }
            return string.Empty;
        }
        private static string getCoordenadas(string[] args, int pulo)
        {
            for (int index = pulo; index <= pulo + 3; index++)
            {
                foreach (char c in args[index].ToCharArray())
                    if (Sonda.getDirecoesPossiveis.Contains(c))
                        return args[index];
            }
            return string.Empty;
        }
        private static string getComandos(string[] args, int pulo)
        {
            for (int index = pulo; index <= pulo + 3; index++)
            {
                foreach (char c in args[index].ToCharArray())
                    if (Sonda.getComandosPossiveis.Contains(c))
                        return args[index];
            }
            return string.Empty;
        }
    }
}