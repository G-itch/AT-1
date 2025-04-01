using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AT_CSharp.Exercicios
{
    public abstract class ContatoFormatter
    {
        public abstract void ExibirContatos(List<Contato> contatos);
    }
    
    public class MarkdownFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("\n## Lista de Contatos\n");
            
            foreach (var contato in contatos)
            {
                Console.WriteLine($"- **Nome:** {contato.Nome}");
                Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
                Console.WriteLine($"- 📧 Email: {contato.Email}\n");
            }
        }
    }
    
    public class TabelaFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("| Nome | Telefone | Email |");
            Console.WriteLine("----------------------------------------");
            
            foreach (var contato in contatos)
            {
                Console.WriteLine($"| {contato.Nome} | {contato.Telefone} | {contato.Email} |");
            }
            
            Console.WriteLine("----------------------------------------");
        }
    }
    
    public class RawTextFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("\nContatos cadastrados:");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
            }
        }
    }
    
    public static class Exercicio12
    {
        private const string ARQUIVO_CONTATOS = "contatos.txt";
        private static List<Contato> contatos = new List<Contato>();
        
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 12 - Formatos de Exibição de Contatos ===");
            
            CarregarContatos();
            
            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos (Markdown)");
                Console.WriteLine("3 - Listar contatos (Tabela)");
                Console.WriteLine("4 - Listar contatos (Texto Puro)");
                Console.WriteLine("5 - Sair");
                Console.Write("Opção: ");
                
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            AdicionarContato();
                            break;
                            
                        case 2:
                            new MarkdownFormatter().ExibirContatos(contatos);
                            break;
                            
                        case 3:
                            new TabelaFormatter().ExibirContatos(contatos);
                            break;
                            
                        case 4:
                            new RawTextFormatter().ExibirContatos(contatos);
                            break;
                            
                        case 5:
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
    }
} 