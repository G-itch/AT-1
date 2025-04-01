using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AT_CSharp.Exercicios
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        
        public Contato(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
        
        public override string ToString()
        {
            return $"{Nome},{Telefone},{Email}";
        }
        
        public static Contato FromString(string linha)
        {
            string[] partes = linha.Split(',');
            return new Contato(partes[0], partes[1], partes[2]);
        }
    }
    
    public static class Exercicio11
    {
        private const string ARQUIVO_CONTATOS = "contatos.txt";
        private static List<Contato> contatos = new List<Contato>();
        
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 11 - Gerenciador de Contatos ===");
            
            CarregarContatos();
            
            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("Opção: ");
                
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            AdicionarContato();
                            break;
                            
                        case 2:
                            ListarContatos();
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
        
        private static void CarregarContatos()
        {
            if (File.Exists(ARQUIVO_CONTATOS))
            {
                try
                {
                    contatos = File.ReadAllLines(ARQUIVO_CONTATOS)
                        .Select(linha => Contato.FromString(linha))
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao carregar contatos: {ex.Message}");
                }
            }
        }
        
        private static void SalvarContatos()
        {
            try
            {
                File.WriteAllLines(ARQUIVO_CONTATOS, contatos.Select(c => c.ToString()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar contatos: {ex.Message}");
            }
        }
        
        private static void AdicionarContato()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            
            Console.Write("Email: ");
            string email = Console.ReadLine();
            
            contatos.Add(new Contato(nome, telefone, email));
            SalvarContatos();
            
            Console.WriteLine("\nContato cadastrado com sucesso!");
        }
        
        private static void ListarContatos()
        {
            if (!contatos.Any())
            {
                Console.WriteLine("\nNenhum contato cadastrado.");
                return;
            }
            
            Console.WriteLine("\nContatos cadastrados:");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
            }
        }
    }
} 