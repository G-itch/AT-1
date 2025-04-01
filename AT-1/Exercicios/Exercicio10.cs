using System;

namespace AT_CSharp.Exercicios
{
    public static class Exercicio10
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 10 - Jogo de Adivinhação ===");
            
            Random random = new Random();
            int numeroSecreto = random.Next(1, 51);
            int tentativas = 0;
            const int MAX_TENTATIVAS = 5;
            
            Console.WriteLine($"Você tem {MAX_TENTATIVAS} tentativas para adivinhar um número entre 1 e 50.");
            
            while (tentativas < MAX_TENTATIVAS)
            {
                Console.Write($"\nTentativa {tentativas + 1}: ");
                
                if (int.TryParse(Console.ReadLine(), out int palpite))
                {
                    if (palpite < 1 || palpite > 50)
                    {
                        Console.WriteLine("O número deve estar entre 1 e 50!");
                        continue;
                    }
                    
                    if (palpite == numeroSecreto)
                    {
                        Console.WriteLine($"\nParabéns! Você acertou em {tentativas + 1} tentativas!");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    
                    Console.WriteLine(palpite < numeroSecreto ? "O número é maior!" : "O número é menor!");
                    tentativas++;
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido!");
                }
            }
            
            Console.WriteLine($"\nGame Over! O número era {numeroSecreto}.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
} 