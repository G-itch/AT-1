using System;

namespace AT_CSharp.Exercicios
{
    public static class Exercicio1
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 1 - Primeiro Programa ===");
            
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            
            Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
            {
                Console.WriteLine($"\nOlá, meu nome é {nome}!");
                Console.WriteLine($"Nasci em {dataNascimento:dd/MM/yyyy} e estou aprendendo C#!");
            }
            else
            {
                Console.WriteLine("Data de nascimento inválida!");
            }
            
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
} 