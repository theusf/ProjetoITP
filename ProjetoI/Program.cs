using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProjetoI
{
    class Program
    {
        static void Main(string[] args)
        {
            SelecionarOpcoes();
        }

        static void WritePos(int coluna, int linha, string texto)
        {
            SetCursorPosition(coluna, linha);
            Write(texto);
        }

        static void ExibirOpcoes()
        {
            BackgroundColor = ConsoleColor.DarkMagenta;
            ForegroundColor = ConsoleColor.White;
            Clear();
            WritePos(25, 0, "__________PROJETO__________");
            ForegroundColor = ConsoleColor.White;
            WritePos(5, 3, " a  - Números amigos");
            WritePos(5, 4, " b  - Decimal para binário");
            WritePos(5, 5, " c  - Constante de Catalan");
            WritePos(5, 6, " d  - Processamento de dados em arquivo texto");
            WritePos(5, 7, " e  - Finalizar o programa");
            ForegroundColor = ConsoleColor.Cyan;
            WritePos(5, 10, "Digite uma opção: ");
        }

        static void SelecionarOpcoes()
        {
            string opcaoEscolhida = "";
            do
            {
                ExibirOpcoes();
                opcaoEscolhida = ReadLine().ToLower();

                switch (opcaoEscolhida)
                {
                    case "a": ExercicioA(); break;
                    case "b": ExercicioB(); break;
                    case "c": ExercicioC(); break;
                    case "d": ExercicioD(); break;
                    case "e": break;
                    default: WritePos(20, 17, "===> Opção inválida <==="); break;
                }
                EsperarEnter();
            }

            while (opcaoEscolhida != "e");

        }

        static void EsperarEnter()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WritePos(10, 23, "Pressione [Enter] para prosseguir");
            ReadLine();
        }

        static void ExercicioA()
        {
            Clear();
            WritePos(5, 4, "Números amigos");
            WritePos(5, 6, "Quantos termos terá o cálculo? ");
            int quantosTermos = int.Parse(ReadLine());

            var meuProj = new Matematica(quantosTermos);

            List<string> numeros = meuProj.Amigos();
            foreach (string umItem in numeros)

            {
                Console.WriteLine(umItem);
            }

            //EsperarEnter();
        }

        static void ExercicioB()
        {
            Clear();
            WritePos(5, 4, "ParaBinario");
            WritePos(5, 6, "Digite um valor decimal menor que 64 para converter para binario: ");

            int valor = int.Parse(ReadLine());

            var meuProj = new Matematica(valor);

            WritePos(5, 8, $"O numero decimal {valor} em binário é: ");
            WritePos(5, 9, meuProj.ParaBinario());

            //EsperarEnter();
        }

        static void ExercicioC()
        {
            Clear();
            WritePos(5, 4, "Constante de Catalan");
            WritePos(5, 6, "Quantos termos terá o cálculo? ");
            int quantosTermos = int.Parse(ReadLine());

            var meuProj = new Matematica(quantosTermos);

            WritePos(5, 8, $"A constante de catalan com {quantosTermos} termos");
            WritePos(5, 9, meuProj.Catalan().ToString());

            //EsperarEnter();
        }

        static void ExercicioD()
        {
            Clear();
            WritePos(4, 4, "Processamento de dados armazenados em arquivo em disco");
            WritePos(5, 6, "Digite o nome do arquivo a ser lido na pasta temp:");

            string NomeDoArquivo = ReadLine();

            var meuAluno = new Aluno(NomeDoArquivo);

            WriteLine(meuAluno.lerDados());
            ReadLine();
            Clear();
            //EsperarEnter();

        }

    }
}
