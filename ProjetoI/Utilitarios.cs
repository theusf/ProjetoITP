using System;
using static System.Console;

public static class Utilitarios
{
  public static void WritePos(int coluna, int linha, string texto)
  {
    SetCursorPosition(coluna, linha);
    Write(texto);
  }

  public static void EsperarEnter()
  {
    WritePos(1, 23, "Pressione [Enter] para prosseguir");
    ReadLine();
  }
}
