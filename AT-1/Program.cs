using AT_CSharp.Exercicios;

namespace AT_1
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("=== AT-CSharp - Exercícios ===");
				Console.WriteLine("1. Exercício 1 - Primeiro Programa");
				Console.WriteLine("2. Exercício 2 - Cifrador de Nome");
				Console.WriteLine("3. Exercício 3 - Calculadora");
				Console.WriteLine("4. Exercício 4 - Dias até Aniversário");
				Console.WriteLine("5. Exercício 5 - Tempo até Formatura");
				Console.WriteLine("6. Exercício 6 - Cadastro de Alunos");
				Console.WriteLine("7. Exercício 7 - Banco Digital");
				Console.WriteLine("8. Exercício 8 - Cadastro de Funcionários");
				Console.WriteLine("9. Exercício 9 - Controle de Estoque");
				Console.WriteLine("10. Exercício 10 - Jogo de Adivinhação");
				Console.WriteLine("11. Exercício 11 - Cadastro de Contatos");
				Console.WriteLine("12. Exercício 12 - Formatos de Exibição");
				Console.WriteLine("0. Sair");
				Console.Write("\nEscolha uma opção: ");

				if (int.TryParse(Console.ReadLine(), out int opcao))
				{
					switch (opcao)
					{
						case 1:
							Exercicio1.Executar();
							break;
						case 2:
							Exercicio2.Executar();
							break;
						case 3:
							Exercicio3.Executar();
							break;
						case 4:
							Exercicio4.Executar();
							break;
						case 5:
							Exercicio5.Executar();
							break;
						case 6:
							Exercicio6.Executar();
							break;
						case 7:
							Exercicio7.Executar();
							break;
						case 8:
							Exercicio8.Executar();
							break;
						case 9:
							Exercicio9.Executar();
							break;
						case 10:
							Exercicio10.Executar();
							break;
						case 11:
							Exercicio11.Executar();
							break;
						case 12:
							Exercicio12.Executar();
							break;
						case 0:
							return;
						default:
							Console.WriteLine("Opção inválida!");
							break;
					}
				}
			}
		}
	}
}
