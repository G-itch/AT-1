using System;

namespace AT_CSharp.Exercicios
{
    public static class Exercicio3
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 3 - Calculadora ===");
            
            double num1, num2;
            int operacao;
            
            do
            {
                Console.Write("Digite o primeiro número: ");
            } while (!double.TryParse(Console.ReadLine(), out num1));
            
            do
            {
                Console.Write("Digite o segundo número: ");
            } while (!double.TryParse(Console.ReadLine(), out num2));
            
            do
            {
                Console.WriteLine("\nEscolha a operação:");
                Console.WriteLine("1 - Soma");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.Write("Opção: ");
            } while (!int.TryParse(Console.ReadLine(), out operacao) || operacao < 1 || operacao > 4);
            
            double resultado = 0;
            string operacaoTexto = "";
            
            switch (operacao)
            {
                case 1:
                    resultado = num1 + num2;
                    operacaoTexto = "soma";
                    break;
                case 2:
                    resultado = num1 - num2;
                    operacaoTexto = "subtração";
                    break;
                case 3:
                    resultado = num1 * num2;
                    operacaoTexto = "multiplicação";
                    break;
                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("\nErro: Não é possível dividir por zero!");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    resultado = num1 / num2;
                    operacaoTexto = "divisão";
                    break;
            }
            
            Console.WriteLine($"\nResultado da {operacaoTexto}: {resultado}");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
} 