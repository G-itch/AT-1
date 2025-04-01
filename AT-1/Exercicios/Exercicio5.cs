using System;

namespace AT_CSharp.Exercicios
{
    public static class Exercicio5
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 5 - Tempo até a Formatura ===");
            
            // Data prevista de formatura (definida manualmente no código)
            DateTime dataFormatura = new DateTime(2026, 12, 15);
            
            DateTime dataAtual;
            do
            {
                Console.Write("Digite a data atual (dd/MM/yyyy): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out dataAtual));
            
            // Validação da data atual
            if (dataAtual > DateTime.Now)
            {
                Console.WriteLine("\nErro: A data informada não pode ser no futuro!");
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }
            
            if (dataAtual > dataFormatura)
            {
                Console.WriteLine("\nParabéns! Você já deveria estar formado!");
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }
            
            TimeSpan tempoRestante = dataFormatura - dataAtual;
            
            int anos = (int)(tempoRestante.TotalDays / 365.25);
            int meses = (int)((tempoRestante.TotalDays % 365.25) / 30.44);
            int dias = (int)(tempoRestante.TotalDays % 30.44);
            
            Console.WriteLine($"\nFaltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");
            
            if (anos == 0 && meses < 6)
            {
                Console.WriteLine("\nA reta final chegou! Prepare-se para a formatura!");
            }
            
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
} 