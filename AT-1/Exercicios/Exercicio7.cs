using System;

namespace AT_CSharp.Exercicios
{
    public class ContaBancaria
    {
        public string Titular { get; set; }
        private decimal saldo;
        
        public ContaBancaria(string titular)
        {
            Titular = titular;
            saldo = 0;
        }
        
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
                return;
            }
            
            saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
            ExibirSaldo();
        }
        
        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor do saque deve ser positivo!");
                return;
            }
            
            if (valor > saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
                return;
            }
            
            saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
            ExibirSaldo();
        }
        
        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
        }
    }
    
    public static class Exercicio7
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 7 - Banco Digital ===");
            
            Console.Write("Digite o nome do titular da conta: ");
            string titular = Console.ReadLine();
            
            ContaBancaria conta = new ContaBancaria(titular);
            
            while (true)
            {
                Console.WriteLine("\nEscolha uma operação:");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Exibir Saldo");
                Console.WriteLine("4 - Sair");
                Console.Write("Opção: ");
                
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Digite o valor do depósito: R$ ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito))
                            {
                                conta.Depositar(valorDeposito);
                            }
                            break;
                            
                        case 2:
                            Console.Write("Digite o valor do saque: R$ ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque))
                            {
                                conta.Sacar(valorSaque);
                            }
                            break;
                            
                        case 3:
                            conta.ExibirSaldo();
                            break;
                            
                        case 4:
                            return;
                            
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
} 