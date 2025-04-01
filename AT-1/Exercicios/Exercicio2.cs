using System;
using System.Text;

namespace AT_CSharp.Exercicios
{
    public static class Exercicio2
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 2 - Cifrador de Nome ===");
            
            Console.Write("Digite seu nome completo: ");
            string nome = Console.ReadLine();
            
            string nomeCifrado = CifrarNome(nome);
            Console.WriteLine($"\nNome cifrado: {nomeCifrado}");
            
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        
        private static string CifrarNome(string nome)
        {
            StringBuilder resultado = new StringBuilder();
            
            foreach (char c in nome)
            {
                if (char.IsLetter(c))
                {
                    // Desloca a letra 2 posições para frente no alfabeto
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char cifrado = (char)(((c - baseChar + 2) % 26) + baseChar);
                    resultado.Append(cifrado);
                }
                else
                {
                    // Mantém espaços e outros caracteres inalterados
                    resultado.Append(c);
                }
            }
            
            return resultado.ToString();
        }
    }
} 