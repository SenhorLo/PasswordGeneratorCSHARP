using System;
using System.Text;

class GeradorSenhas
{

    static void Main()
    {

        Console.WriteLine("== Gerador de senhas ==");

        Consoles.Write("Quantos caracteres a senha precisa?");
        int tamanho = int.Parse(Console.ReadLine());

        Console.Write("Deve conter letras maiúsculas? (sim/nao)");
        bool incluirMaiusculas = Console.ReadLine().ToLower() == "sim";

        Console.Write("Deve conter letras minúsculas? (sim/nao)");
        bool incluirMinusculas = Console.ReadLine().ToLower() == "sim";

        Console.Write("Deve conter números? (sim/nao)");
        bool incluirNumeros = Console.ReadLine().ToLower() == "sim";

        Console.Write("Deve conter símbolos? (sim/nao)");
        bool incluirSimbolos = Console.ReadLine().ToLower() == "sim";

        string senha = GerarSenhar(tamanho, incluirMaiusculas, incluirMinusculas, incluirNumeros, incluirSimbolos);

        Console.WriteLine($"\nSenha : {senha}");
    }



    static string GerarSenhar(int tamanho, bool maiusculas, bool minusculas, bool numeros, bool simbolos)
    {

        const string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
        const string digitos = "0123456789";
        const string caracteresEspeciais = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        StringBuilder conjunto = new StringBuilder();

        if (maiusculas) conjunto.Append(letrasMaiusculas);
        if (minusculas) conjunto.Append(letrasMinusculas);
        if (numeros) conjunto.Append(digitos);
        if (simbolos) conjunto.Append(caracteresEspeciais);

        if (conjunto.Length == 0)
        {
            return "Você precisa escolher pelo menos um caractere.";
        }

        StringBuilder senha = new StringBuilder();
        Random rand = new Random();

        for (int i = 0; i < tamanho; i++)
        {
            int index = rand.Next(conjunto.Length);
            senha.Append(conjunto[index]);
        }

        return senha.ToString();
    }
}
