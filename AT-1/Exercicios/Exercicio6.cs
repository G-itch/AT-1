using System;

namespace AT_CSharp.Exercicios
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public double MediaNotas { get; set; }
        
        public Aluno(string nome, string matricula, string curso, double mediaNotas)
        {
            Nome = nome;
            Matricula = matricula;
            Curso = curso;
            MediaNotas = mediaNotas;
        }
        
        public void ExibirDados()
        {
            Console.WriteLine("\nDados do Aluno:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine($"Média das Notas: {MediaNotas:F2}");
            Console.WriteLine($"Status: {VerificarAprovacao()}");
        }
        
        public string VerificarAprovacao()
        {
            return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
        }
    }
    
    public static class Exercicio6
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Exercício 6 - Cadastro de Alunos ===");
            
            // Criando um objeto Aluno com dados do usuário
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            
            Console.Write("Digite sua matrícula: ");
            string matricula = Console.ReadLine();
            
            Console.Write("Digite seu curso: ");
            string curso = Console.ReadLine();
            
            double mediaNotas;
            do
            {
                Console.Write("Digite sua média de notas: ");
            } while (!double.TryParse(Console.ReadLine(), out mediaNotas) || mediaNotas < 0 || mediaNotas > 10);
            
            Aluno aluno = new Aluno(nome, matricula, curso, mediaNotas);
            aluno.ExibirDados();
            
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
} 