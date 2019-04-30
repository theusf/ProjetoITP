using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class Aluno
{
    private string classe;
    private string ra;
    private string nota;
    private double media = 0;
    private string nomedoarquivo;

    public StreamReader arquivoDeDados;


    public Aluno(string NomeDoArquivo,string linhaLida)
    {
        nomedoarquivo = NomeDoArquivo;

        Classe = linhaLida.Substring(0, 6);
        RA = linhaLida.Substring(6, 5);
        Nota = linhaLida.Substring(11, 4);

    }

    public Aluno(string arquivo)
    {
        nomedoarquivo = arquivo;

    }

    public string NomeDoArquivo
    {
        get
        {
            return nomedoarquivo;
        }
        set
        {
            nomedoarquivo = value;
        }
    }

    public string Classe
    {
        get
{
            return classe;
        }
        set
        {
            classe = value;
        }
    }

    public string RA
    {
        get
        {
            return ra;
        }
        set
        {
            ra = value;
        }
    }

    public string Nota
    {
        get
        {
            return nota;
        }
        set
        {
            nota = value;
        }
    }



    public string lerDados()
    {
        //No meu windows 10!! ->
        //arquivoDeDados = new StreamReader($"C:\\Windows\\Temp\\{nomedoarquivo}.txt");
        //No pc do colégio! ->
        arquivoDeDados = new StreamReader($"C:\\Temp\\{nomedoarquivo}.txt");
        string resultado = "";
        string ClasseAnteiror = "";
        string RaAnterior = "";
        double somaDasNotas = 0;
        double qntdDeNotas = 0;
        int qntdDeAprovados = 0;
        int qntdDeRec = 0;
        int qntdRetidos = 0;
        bool PrimeiraVez = true;
        bool trocouDeClasse = false;
        double maiorMedia = 0;
        string DonaDaMaiorMedia = "";
        


        while (arquivoDeDados.EndOfStream != true)
        {
            string linhaLida = arquivoDeDados.ReadLine();
            var umAluno = new Aluno(nomedoarquivo, linhaLida);


            if (umAluno.Classe != ClasseAnteiror) //Muda de classe!
            {
                if (!PrimeiraVez )
                {
                    trocouDeClasse = true;
                    media = somaDasNotas / qntdDeNotas;
                    resultado += $"Media do aluno {RaAnterior} da classe {ClasseAnteiror} é de {media}, ";
                    if (media < 3)
                    { resultado += "Aluno Retido \n\n"; qntdRetidos++; }
                    else if (media >= 3 && media < 5)
                    { resultado += "Aluno Em Recuperação \n\n"; qntdDeRec++; }
                    else if (media >= 5)
                    { resultado += "Aluno Aprovado \n\n"; qntdDeAprovados++; }

                    if (media > maiorMedia)
                    { maiorMedia = media; DonaDaMaiorMedia = RaAnterior; }

                    resultado += $"---------------{ClasseAnteiror}--------------------------------\n\n";
                    resultado += $"Quantidade de aprovados nessa classe: {qntdDeAprovados}\n\n";
                    resultado += $"Quantidade de em Rec nessa classe: {qntdDeRec}\n\n";
                    resultado += $"Quantidade de Retidos nessa classe: {qntdRetidos}\n\n";
                    resultado += $"Aluno {DonaDaMaiorMedia} teve a maior desempenho ({maiorMedia}) \n\n";
                    resultado += $"---------------{ClasseAnteiror}--------------------------------\n\n";
                }

                resultado += "Classe: " + umAluno.Classe + " \n\n";
                resultado += $"RA:         Notas\n\n";

                qntdDeAprovados = 0;
            }

            if (umAluno.RA != RaAnterior)
            {
                if (!PrimeiraVez && ( trocouDeClasse == false )  )
                {
                    media = somaDasNotas / qntdDeNotas;
                    resultado += $"Media do aluno {RaAnterior} da classe {ClasseAnteiror} é de {media}, ";
                    if (media < 3)
                    { resultado += "Aluno Retido \n\n"; qntdRetidos++; }
                    else if (media >= 3 && media < 5)
                    { resultado += "Aluno Em Recuperação \n\n"; qntdDeRec++; }
                    else if (media >= 5)
                    { resultado += "Aluno Aprovado \n\n"; qntdDeAprovados++; }


                    if (media > maiorMedia)
                    { maiorMedia = media; DonaDaMaiorMedia = RaAnterior; }

                }

                resultado += $"{umAluno.RA}      {umAluno.Nota}\n\n";
                somaDasNotas = 0;
                somaDasNotas += double.Parse(umAluno.Nota);
                qntdDeNotas = 0;
                qntdDeNotas = qntdDeNotas + 1;


                if (PrimeiraVez)
                    PrimeiraVez = false;
            }
            else
            {

                somaDasNotas += double.Parse(umAluno.Nota);
                qntdDeNotas = qntdDeNotas + 1;
                resultado += $"           {umAluno.Nota}\n\n";


            }

            ClasseAnteiror = umAluno.Classe;
            RaAnterior = umAluno.RA;

        }
        return resultado;



    }
}

