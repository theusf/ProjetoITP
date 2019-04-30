using System;
using System.Collections.Generic;

class Matematica
{
   //================================================================
    //                  PROJETO

    public double Catalan()
    {
        var meuSoma = new Somatoria();

        var i = new Contador(1, numeroInteiro * 2, 2);

        int sinal = 1;

        while (i.Prosseguir())
        {
            double expressao = 1.0 / (i.Valor * i.Valor);

            meuSoma.Somar(sinal * expressao);

            sinal = -sinal;
        }

        return meuSoma.Valor;
    }

    public string ParaBinario()
    {
        if (numeroInteiro < 64)
        {
            int resto;
            string convertor = "";
            string resultado = "";

            while (numeroInteiro != 0)
            {
                resto = numeroInteiro % 2;
                numeroInteiro = numeroInteiro / 2;

                convertor = resto.ToString();
                resultado = convertor + resultado;
            }

            return resultado;
        }
        else
            return $"O numéro informado ({numeroInteiro}) tem de ser menor que 64! \n\n Porfavor informe outro número";

    }

    public List<string> Amigos()
    {
        int SomaDosDivisoresDeI;
        int SomaDosDivisoresDeJ;

        List<string> resultado = new List<string>();

        var matAmigos = new Matematica(0);
        for (int i = 1; i <= this.numeroInteiro; i++)
        {
            matAmigos.NumeroInteiro = i;
            SomaDosDivisoresDeI = (matAmigos.SomaDosDivisores() - i);
            for (int j = 0; j <= i; j++)
            {
                matAmigos.NumeroInteiro = j;
                SomaDosDivisoresDeJ = (matAmigos.SomaDosDivisores() - j);
                if ((SomaDosDivisoresDeJ == i) && (SomaDosDivisoresDeI == j) && !(matAmigos.EhPerfeito()))
                {
                    resultado.Add(i + "," + j);

                }
            }
        }
        return resultado;
    }

    // =================================================================================

    int numeroInteiro; // armazenará o valor a ser usado como base nos cálculos

    // construtor da classe Matematica, que recebe como parâmetro o valor que
    // será usado como base nos cálculos e o armazena no atributo numeroInteiro

    public int NumeroInteiro
    {
        get
        {
            return numeroInteiro;
        }
        set
        {
            numeroInteiro = value;
        }
    }


    public Matematica(int numeroDesejado)
    {
        numeroInteiro = numeroDesejado;
    }

    // Esta função calcula o fatorial do valor armazenado no atributo numeroInteiro
    public int Fatorial()
  {
    var fat = new Produtorio(); // cria na memória um objeto da classe Produtorio

    // abaixo criamos o gerador de inteiros de 1 a numeroInteiro (Contador)
    var parcela = new Contador(1, numeroInteiro, 1);

    while (parcela.Prosseguir()) // gera números e vê se prossegue a contagem
    {
      fat.Multiplicar(parcela.Valor);  // acumula o número gerado (parcela.Valor)
    }
    return (int)fat.Valor;  // (int) ---> Type Cast ou conversão de tipo
  }

  public int FatorialSemObjetos()
  {
    int fat = 1; // valor inicial de qualquer Produtorio
    // iniciamos com 1 o gerador de inteiros 
    int parcela = 1;
    while (parcela <= numeroInteiro) // vê se prossegue a contagem
    {
      fat = fat * parcela;  // acumula o número gerado (parcela.Valor)
      parcela = parcela + 1;      // gera próximo números inteiro da sequência
    }
    return fat;
  }

  public string ListaDosDivisores()
  {
    string resultado = " 1";
    var possivelDivisor = new Contador(2, numeroInteiro / 2, 1);
    while (possivelDivisor.Prosseguir())
    {
      int resto = numeroInteiro % possivelDivisor.Valor;
      if (resto == 0)
        resultado = resultado + ", " + possivelDivisor.Valor;
    }
    resultado += ", " + numeroInteiro;
    return resultado;
  }

  public int MDC(int outroValor)
  {
    int dividendo = numeroInteiro;
    int divisor = outroValor;
    int resto = 0;
    do
    {
      resto = dividendo % divisor;
      if (resto != 0)
      {
        dividendo = divisor;
        divisor = resto;
      }
    }
    while (resto != 0);

    return divisor;
  }

  public bool EhPalindromo()
  {
    int aoContrario = 0;
    int numero = numeroInteiro;
    while (numero > 0)
    {
      int quociente = numero / 10;
      int resto = numero - 10 * quociente;  // separo o dígito mais à direita do número
      aoContrario = aoContrario * 10 + resto; // 
      numero = quociente;
    }

    if (aoContrario == numeroInteiro)
      return true;  // é palíndromo
    else
      return false; // não é palíndromo
  }

  public int SomaDeQuadrados()
  {
    var somaValores = new Somatoria();
    var contador = new Contador(1, numeroInteiro, 1);
    while (contador.Prosseguir())
    {
      int umQuadrado = contador.Valor * contador.Valor;
      somaValores.Somar(umQuadrado);
    }

    return (int)somaValores.Valor;
  }

  public int SomaDosDigitos()
  {
    var somaDig = new Somatoria();
    int numeroADecompor = numeroInteiro;
    while (numeroADecompor > 0)
    {
      int quoc = numeroADecompor / 10;
      int digito = numeroADecompor - quoc * 10;
      somaDig.Somar(digito);

      numeroADecompor = quoc;
    }
    return (int)somaDig.Valor;
  }

  public double Elevado(double a)
  {
    var pot = new Produtorio();

    var cont = new Contador(1, numeroInteiro, 1);

    while (cont.Prosseguir())
      pot.Multiplicar(a);

    return pot.Valor;
  }
  public int SomaDosDivisores() // calcula a soma dos divisores de numeroInteiro (de 1 a numeroInteiro)
  {
    int resultado = 0;
    var possivelDivisor = new Contador(2, numeroInteiro / 2, 1);
    while (possivelDivisor.Prosseguir())
    {
      int resto = numeroInteiro % possivelDivisor.Valor;
      if (resto == 0)
        resultado = resultado + possivelDivisor.Valor;
    }
        resultado += 1 + numeroInteiro;
    return resultado;
  }

    public bool EhPerfeito()
  {
    int somaComONumero = SomaDosDivisores();
    int somaSemONumero = somaComONumero - numeroInteiro;
    if (somaSemONumero == numeroInteiro)
      return true;
    else
      return false;
  }

  public bool EhPrimo1()
  {
    int somaDiv = SomaDosDivisores();  /// esse método calcula a soma dos divisores de numeroInteiro
    if (somaDiv == numeroInteiro + 1)
      return true; // numeroInteiro é primo!
    else
      return false; // numeroInteiro não é primo!
  }

  public bool EhPrimo2()
  {
    int quantosDivisores = 2;  // todo inteiro tem pelo menos 2 divisores
    var possivelDivisor = new Contador(2, numeroInteiro / 2, 1);
    while (possivelDivisor.Prosseguir())
    {
      int resto = numeroInteiro % possivelDivisor.Valor;
      if (resto == 0)          // se isso acontece, achamos mais um divisor
        quantosDivisores++;  // e o contamos para determinar a quantidade 
                             // de divisores de numeroInteiro
    }

    if (quantosDivisores == 2)   // todo número primo tem somente 2 divisores
      return true; // numeroInteiro é primo!
    else                         // números não primos tem mais que 2 divisores
      return false; // numeroInteiro não é primo!
  }

  public bool EhPrimo3()
  {
    var possivelDivisor = new Contador(2, numeroInteiro / 2, 1);

    int resto = 1; // para não começar com zero e parar o while na 1a vez!!

    while (resto != 0 && possivelDivisor.Prosseguir())
      resto = numeroInteiro % possivelDivisor.Valor; // se deu divisão exata (resto = 0), paramos de repetir

    if (resto != 0)   // todo número primo não tem divisores exatos entre 2 e sua metade
      return true; // numeroInteiro é primo!
    else                         // números não primos tem divisores entre 2 e sua metade
      return false; // numeroInteiro não é primo!
  }

  public double Cosseno(double anguloEmGraus)
  {
    double x = anguloEmGraus*Math.PI/180;  // cpnverte medida em graus para medida em radianos

    var somaDosTermos = new Somatoria();

    int sinal = 1;
    var contador = new Contador(0, numeroInteiro*2, 2);

    while (contador.Prosseguir())
    {
      double potencia = Math.Pow(x, contador.Valor);

      var fat = new Matematica(contador.Valor);
      double fatorial = fat.Fatorial();  // já temos essa função pronta na classe Matematica

      double termo = potencia / fatorial;

      somaDosTermos.Somar(sinal*termo);
      sinal = -sinal;
    }

    return somaDosTermos.Valor;
  }

  public double Pi()
  {
    int sinal = 1;
    var soma = new Somatoria();
    var i = new Contador(1, numeroInteiro * 2, 2);
    while (i.Prosseguir())
    {
      double termo = 1.0 / (i.Valor * i.Valor * i.Valor);
      soma.Somar(sinal * termo);
      sinal = -sinal; // alterna  o sinal para calcular o próximo termo
    }

    double pi = Math.Pow(32 * soma.Valor, 1.0 / 3.0);
    return pi;
  }
}
