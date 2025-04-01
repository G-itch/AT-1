using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AT_CSharp.Exercicios
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        
        public Produto(string nome, int quantidade, decimal preco)
        {
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }
        
        public override string ToString()
        {
            return $"{Nome},{Quantidade},{Preco:F2}";
        }
        
        public static Produto FromString(string linha)
        {
            string[] partes = linha.Split(',');
            return new Produto(
                partes[0],
                int.Parse(partes[1]),
                decimal.Parse(partes[2])
            );
        }
    }
    
    public static class Exercicio9
    {
        private const string ARQUIVO_ESTOQUE = "estoque.txt";
        private static List<Produto> produtos = new List<Produto>();
        
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 9 - Controle de Estoque ===");
            
            CarregarProdutos();
            
            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Inserir Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Sair");
                Console.Write("Opção: ");
                
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            InserirProduto();
                            break;
                            
                        case 2:
                            ListarProdutos();
                            break;
                            
                        case 3:
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
        
        private static void CarregarProdutos()
        {
            if (File.Exists(ARQUIVO_ESTOQUE))
            {
                produtos = File.ReadAllLines(ARQUIVO_ESTOQUE)
                    .Select(linha => Produto.FromString(linha))
                    .ToList();
            }
        }
        
        private static void SalvarProdutos()
        {
            File.WriteAllLines(ARQUIVO_ESTOQUE, produtos.Select(p => p.ToString()));
        }
        
        private static void InserirProduto()
        {
            if (produtos.Count >= 5)
            {
                Console.WriteLine("\nLimite de produtos atingido!");
                return;
            }
            
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();
            
            int quantidade;
            do
            {
                Console.Write("Quantidade: ");
            } while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0);
            
            decimal preco;
            do
            {
                Console.Write("Preço unitário: R$ ");
            } while (!decimal.TryParse(Console.ReadLine(), out preco) || preco < 0);
            
            produtos.Add(new Produto(nome, quantidade, preco));
            SalvarProdutos();
            
            Console.WriteLine("\nProduto cadastrado com sucesso!");
        }
        
        private static void ListarProdutos()
        {
            if (!produtos.Any())
            {
                Console.WriteLine("\nNenhum produto cadastrado.");
                return;
            }
            
            Console.WriteLine("\nProdutos cadastrados:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Produto: {produto.Nome} | Quantidade: {produto.Quantidade} | Preço: R$ {produto.Preco:F2}");
            }
        }
    }
} 