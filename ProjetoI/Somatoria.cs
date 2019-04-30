using System;
class Somatoria
{
  double soma;  // acumulará a soma dos valores passados ao método Somar()
  int quantasSomas;

  public double Valor
  {
    get => soma;  // retorna o conteúdo do atributo soma
  }

  public int Quantos
  {
    get => quantasSomas;  // retorna o conteúdo do atributo quantosValoresForamSomados
  }

  public Somatoria()
  {
    soma         = 0;
    quantasSomas = 0;
  }

  public void Somar(double valorASerSomado)
  {
    soma = soma + valorASerSomado;   // soma += valorASerSomado;
    quantasSomas = quantasSomas + 1; // quantasSomas++;  ou   quantasSomas += 1;
  }

  public double MediaAritmetica()
  {
    if (quantasSomas <= 0)
      throw new Exception("Média não pode ser calculada pois temos quantidade " +
        "inválida de somas");

    return soma / quantasSomas;
  }
}

