using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GestaoAcademica
{
    internal class Program
    {
        private static List<Pessoa> pessoas = new();

        static void Main()
        {
            bool executando = true;
            while (executando)
            {
                Console.Clear();
                Console.WriteLine("============================================\n     SISTEMA DE GESTÃO ACADÊMICA            \n============================================\n1 - Cadastrar Aluno\n2 - Cadastrar Professor\n3 - Listar Todas as Pessoas\n4 - Exibir Estatísticas do Sistema\n0 - Sair\n============================================");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine() ?? "")
                {
                    case "1": CadastrarAluno(); break;
                    case "2": CadastrarProfessor(); break;
                    case "3": ListarPessoas(); break;
                    case "4": ExibirEstatisticas(); break;
                    case "0":
                        executando = false;
                        Console.WriteLine("\nSaindo do sistema. Até mais!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CadastrarAluno()
        {
            Console.Clear();
            Console.WriteLine("--- CADASTRAR ALUNO ---");
            var aluno = new Aluno(LerNome("Nome: "), LerCPF("CPF (apenas números ou pontuação): "), LerDataNascimento("Data de Nascimento (dd/mm/aaaa): "), LerMatricula("Matrícula (apenas números): "));
            
            int qtdNotas = LerInteiroPositivo("Quantas notas deseja cadastrar para este aluno? ");
            for (int i = 0; i < qtdNotas; i++) aluno.AdicionarNota(LerNota($"Digite a nota {i + 1} (ex: 8.5 ou 8,5): "));

            pessoas.Add(aluno);
            Console.WriteLine("\n✅ Aluno cadastrado com sucesso!");
            Pausar();
        }

        private static void CadastrarProfessor()
        {
            Console.Clear();
            Console.WriteLine("--- CADASTRAR PROFESSOR ---");
            var professor = new Professor(LerNome("Nome: "), LerCPF("CPF (apenas números ou pontuação): "), LerDataNascimento("Data de Nascimento (dd/mm/aaaa): "), LerDoublePositivo("Salário (R$ ex: 3500.00 ou 3500,00): "));

            int qtdTurmas = LerInteiroPositivo("Quantas disciplinas/turmas deseja cadastrar? ");
            for (int i = 0; i < qtdTurmas; i++) professor.AdicionarTurma(LerNomeDisciplina($"Nome da disciplina {i + 1}: "));

            pessoas.Add(professor);
            Console.WriteLine("\n✅ Professor cadastrado com sucesso!");
            Pausar();
        }

        private static void ListarPessoas()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE PESSOAS CADASTRADAS ---");
            if (pessoas.Count == 0) Console.WriteLine("Nenhuma pessoa cadastrada até o momento.");
            else foreach (var p in pessoas) { p.ExibirInformacoes(); Console.WriteLine("--------------------------------------------"); }
            Pausar();
        }

        private static void ExibirEstatisticas()
        {
            Console.Clear();
            Console.WriteLine("--- ESTATÍSTICAS ACADÊMICAS ---");
            var alunos = pessoas.OfType<Aluno>().ToList();
            var professores = pessoas.OfType<Professor>().ToList();

            Console.WriteLine($"Total de Pessoas Cadastradas: {pessoas.Count}\nTotal de Alunos: {alunos.Count}\nTotal de Professores: {professores.Count}");

            if (alunos.Count > 0)
                Console.WriteLine($"Média Geral de Todos os Alunos: {alunos.Average(a => a.CalcularMedia()):F2}\nMaior Média Individual: {alunos.Max(a => a.CalcularMedia()):F2}");
            else
                Console.WriteLine("Sem dados de alunos para calcular médias.");

            if (professores.Count > 0)
                Console.WriteLine($"Média Salarial dos Professores: R$ {professores.Average(p => p.Salario):F2}");

            Pausar();
        }

        private static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }

        // =========================================================================
        // MÉTODOS AUXILIARES DE VALIDAÇÃO
        // =========================================================================

        private static string LerValido(string msg, Func<string, string?> validar)
        {
            while (true)
            {
                Console.Write(msg);
                string input = (Console.ReadLine() ?? "").Trim();
                string? erro = validar(input);
                if (erro == null) return input;
                Console.WriteLine($"❌ Erro: {erro}. Tente novamente.\n");
            }
        }

        private static string LerNome(string m) => LerValido(m, s => string.IsNullOrWhiteSpace(s) ? "O nome não pode ser vazio" : s.Any(char.IsDigit) ? "O nome não pode conter números" : null);
        private static string LerCPF(string m) => LerValido(m, s => string.IsNullOrWhiteSpace(s) ? "O CPF não pode ser vazio" : s.Any(char.IsLetter) ? "O CPF não pode conter letras" : null);
        private static string LerMatricula(string m) => LerValido(m, s => string.IsNullOrWhiteSpace(s) ? "A matrícula não pode ser vazia" : s.Any(char.IsLetter) ? "A matrícula não pode conter letras" : null);
        private static string LerNomeDisciplina(string m) => LerValido(m, s => string.IsNullOrWhiteSpace(s) ? "O nome da disciplina não pode ser vazio" : null);

        private static DateTime LerDataNascimento(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string input = (Console.ReadLine() ?? "").Trim();
                if (DateTime.TryParseExact(input, new[] { "dd/MM/yyyy", "d/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out var d) || DateTime.TryParse(input, out d))
                {
                    if (d > DateTime.Now) Console.WriteLine("❌ Erro: A data de nascimento não pode ser no futuro. Tente novamente.\n");
                    else if (d.Year < 1900) Console.WriteLine("❌ Erro: Ano de nascimento inválido (deve ser maior que 1900). Tente novamente.\n");
                    else return d;
                }
                else Console.WriteLine("❌ Erro: Data inválida! Digite no formato dd/mm/aaaa (ex: 15/05/2000). Tente novamente.\n");
            }
        }

        private static int LerInteiroPositivo(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (int.TryParse((Console.ReadLine() ?? "").Trim(), out int v) && v >= 0) return v;
                Console.WriteLine("❌ Erro: Digite um número inteiro maior ou igual a 0. Tente novamente.\n");
            }
        }

        private static double LerDoublePositivo(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (double.TryParse((Console.ReadLine() ?? "").Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double v) && v >= 0) return v;
                Console.WriteLine("❌ Erro: Digite um valor numérico válido (ex: 2500.00 ou 2500,00). Tente novamente.\n");
            }
        }

        private static double LerNota(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (double.TryParse((Console.ReadLine() ?? "").Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double n))
                {
                    if (n >= 0 && n <= 10) return n;
                    Console.WriteLine("❌ Erro: A nota deve estar entre 0.0 e 10.0. Tente novamente.\n");
                }
                else Console.WriteLine("❌ Erro: Valor inválido! Digite um número decimal (ex: 8.5 ou 8,5). Tente novamente.\n");
            }
        }
    }
}