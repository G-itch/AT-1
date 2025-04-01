using System;

namespace AT_CSharp.Exercicios
{
    public static class Exercicio4
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 4 - Dias até o Próximo Aniversário ===");
            
            DateTime dataNascimento;
            do
            {
                Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento));
            
            DateTime hoje = DateTime.Now;
            DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);
            
            // Se o aniversário deste ano já passou, calcula para o próximo ano
            if (proximoAniversario < hoje)
            {
                proximoAniversario = proximoAniversario.AddYears(1);
            }
            
            TimeSpan diasRestantes = proximoAniversario - hoje;
            
            Console.WriteLine($"\nSeu próximo aniversário será em {proximoAniversario:dd/MM/yyyy}");
            Console.WriteLine($"Faltam {diasRestantes.Days} dias para seu aniversário!");
            
            if (diasRestantes.Days < 7)
            {
                Console.WriteLine("\nUau! Seu aniversário está chegando! Prepare-se para comemorar! 🎉");
            }
            
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
} 