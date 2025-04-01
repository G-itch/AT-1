using System;

namespace AT_CSharp.Exercicios
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioBase { get; set; }
        
        public Funcionario(string nome, string cargo, decimal salarioBase)
        {
            Nome = nome;
            Cargo = cargo;
            SalarioBase = salarioBase;
        }
        
        public virtual decimal CalcularSalario()
        {
            return SalarioBase;
        }
        
        public void ExibirDados()
        {
            Console.WriteLine("\nDados do Funcionário:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salário Base: R$ {SalarioBase:F2}");
            Console.WriteLine($"Salário Total: R$ {CalcularSalario():F2}");
        }
    }
    
    public class Gerente : Funcionario
    {
        private const decimal BONUS_GERENTE = 0.20m; // 20% de bônus
        
        public Gerente(string nome, decimal salarioBase) 
            : base(nome, "Gerente", salarioBase)
        {
        }
        
        public override decimal CalcularSalario()
        {
            return SalarioBase + (SalarioBase * BONUS_GERENTE);
        }
    }
    
    public static class Exercicio8
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 8 - Cadastro de Funcionários ===");
            
            // Criando um funcionário comum
            Console.WriteLine("\nCadastro de Funcionário Comum:");
            Console.Write("Nome: ");
            string nomeFuncionario = Console.ReadLine();
            
            decimal salarioBase;
            do
            {
                Console.Write("Salário Base: R$ ");
            } while (!decimal.TryParse(Console.ReadLine(), out salarioBase) || salarioBase <= 0);
            
            Funcionario funcionario = new Funcionario(nomeFuncionario, "Funcionário", salarioBase);
            funcionario.ExibirDados();
            
            // Criando um gerente
            Console.WriteLine("\nCadastro de Gerente:");
            Console.Write("Nome: ");
            string nomeGerente = Console.ReadLine();
            
            do
            {
                Console.Write("Salário Base: R$ ");
            } while (!decimal.TryParse(Console.ReadLine(), out salarioBase) || salarioBase <= 0);
            
            Gerente gerente = new Gerente(nomeGerente, salarioBase);
            gerente.ExibirDados();
            
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
} 