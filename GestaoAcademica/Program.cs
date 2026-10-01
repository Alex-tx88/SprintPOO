using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace GestaoAcademica
{
    internal class Program
    {
        private static readonly List<Pessoa> pessoas = new();

        static void Main()
        {
            bool executando = true;
            while (executando)
            {
                ExibirMenu();
                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        CadastrarAluno();
                        break;
                    case "2":
                        CadastrarProfessor();
                        break;
                    case "3":
                        ListarPessoas();
                        break;
                    case "4":
                        ExibirEstatisticas();
                        break;
                    case "0":
                        executando = false;
                        ExibirMensagem("\nSaindo do sistema. Até mais!", ConsoleColor.Cyan);
                        break;
                    default:
                        ExibirErro("\nOpção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("        SISTEMA DE GESTÃO ACADÊMICA         ");
            Console.WriteLine("============================================");
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Professor");
            Console.WriteLine("3 - Listar Todas as Pessoas");
            Console.WriteLine("4 - Exibir Estatísticas do Sistema");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("============================================");
            Console.Write("Escolha uma opção: ");
        }

        private static void CadastrarAluno()
        {
            Console.Clear();
            Console.WriteLine("--- CADASTRAR ALUNO ---");

            string nome = LerNome("Nome: ");
            string cpf = LerCPF("CPF (apenas números): ");
            DateTime dataNascimento = LerDataNascimento("Data de Nascimento (dd/mm/aaaa): ");
            string matricula = LerMatricula("Matrícula (apenas números): ");

            var aluno = new Aluno(nome, cpf, dataNascimento, matricula);

            int qtdNotas = LerInteiroPositivo("Quantas notas deseja cadastrar para este aluno? ");
            for (int i = 0; i < qtdNotas; i++)
            {
                aluno.AdicionarNota(LerNota($"Digite a nota {i + 1} (ex: 8.5 ou 8,5): "));
            }

            pessoas.Add(aluno);
            ExibirSucesso("\n✅ Aluno cadastrado com sucesso!");
            Pausar();
        }

        private static void CadastrarProfessor()
        {
            Console.Clear();
            Console.WriteLine("--- CADASTRAR PROFESSOR ---");

            string nome = LerNome("Nome: ");
            string cpf = LerCPF("CPF (apenas números): ");
            DateTime dataNascimento = LerDataNascimento("Data de Nascimento (dd/mm/aaaa): ");
            double salario = LerDoublePositivo("Salário (R$ ex: 3500.00 ou 3500,00): ");

            var professor = new Professor(nome, cpf, dataNascimento, salario);

            int qtdTurmas = LerInteiroPositivo("Quantas disciplinas/turmas deseja cadastrar? ");
            for (int i = 0; i < qtdTurmas; i++)
            {
                professor.AdicionarTurma(LerNomeDisciplina($"Nome da disciplina {i + 1}: "));
            }

            pessoas.Add(professor);
            ExibirSucesso("\n✅ Professor cadastrado com sucesso!");
            Pausar();
        }

        private static void ListarPessoas()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE PESSOAS CADASTRADAS ---");

            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada até o momento.");
            }
            else
            {
                foreach (var p in pessoas)
                {
                    p.ExibirInformacoes();
                    Console.WriteLine("--------------------------------------------");
                }
            }

            Pausar();
        }

        private static void ExibirEstatisticas()
        {
            Console.Clear();
            Console.WriteLine("--- ESTATÍSTICAS ACADÊMICAS ---");

            var alunos = pessoas.OfType<Aluno>().ToList();
            var professores = pessoas.OfType<Professor>().ToList();

            Console.WriteLine($"Total de Pessoas Cadastradas: {pessoas.Count}");
            Console.WriteLine($"Total de Alunos: {alunos.Count}");
            Console.WriteLine($"Total de Professores: {professores.Count}\n");

            if (alunos.Count > 0)
            {
                Console.WriteLine($"Média Geral de Todos os Alunos: {alunos.Average(a => a.CalcularMedia()):F2}");
                Console.WriteLine($"Maior Média Individual: {alunos.Max(a => a.CalcularMedia()):F2}");
            }
            else
            {
                Console.WriteLine("Sem dados de alunos para calcular médias.");
            }

            if (professores.Count > 0)
            {
                Console.WriteLine($"Média Salarial dos Professores: R$ {professores.Average(p => p.Salario):F2}");
            }

            Pausar();
        }

        private static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }

        private static string LerValido(string msg, Func<string, string?> validar)
        {
            while (true)
            {
                Console.Write(msg);
                string input = (Console.ReadLine() ?? "").Trim();
                string? erro = validar(input);

                if (erro == null) return input;

                ExibirErro($"❌ Erro: {erro}. Tente novamente.\n");
            }
        }

        private static string LerNome(string msg) => LerValido(msg, s =>
        {
            if (string.IsNullOrWhiteSpace(s)) return "O nome não pode ser vazio";
            if (!Regex.IsMatch(s, @"^[a-zA-A-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ\s]+$")) return "O nome deve conter apenas letras e espaços";
            return null;
        });

        private static string LerCPF(string msg) => LerValido(msg, s =>
        {
            if (string.IsNullOrWhiteSpace(s)) return "O CPF não pode ser vazio";
            string apenasNumeros = Regex.Replace(s, @"[^\d]", "");
            if (apenasNumeros.Length != 11) return "O CPF deve conter exatamente 11 dígitos numéricos";
            return null;
        });

        private static string LerMatricula(string msg) => LerValido(msg, s =>
        {
            if (string.IsNullOrWhiteSpace(s)) return "A matrícula não pode ser vazia";
            if (!s.All(char.IsDigit)) return "A matrícula deve conter apenas números";
            return null;
        });

        private static string LerNomeDisciplina(string msg) => LerValido(msg, s =>
            string.IsNullOrWhiteSpace(s) ? "O nome da disciplina não pode ser vazio" : null);

        private static DateTime LerDataNascimento(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string input = (Console.ReadLine() ?? "").Trim();

                if (DateTime.TryParseExact(input, new[] { "dd/MM/yyyy", "d/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out var data) ||
                    DateTime.TryParse(input, out data))
                {
                    if (data > DateTime.Now)
                        ExibirErro("❌ Erro: A data de nascimento não pode ser no futuro. Tente novamente.\n");
                    else if (data.Year < 1900)
                        ExibirErro("❌ Erro: Ano de nascimento inválido (deve ser maior que 1900). Tente novamente.\n");
                    else
                        return data;
                }
                else
                {
                    ExibirErro("❌ Erro: Data inválida! Digite no formato dd/mm/aaaa (ex: 15/05/2000). Tente novamente.\n");
                }
            }
        }

        private static int LerInteiroPositivo(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (int.TryParse((Console.ReadLine() ?? "").Trim(), out int valor) && valor >= 0)
                    return valor;

                ExibirErro("❌ Erro: Digite um número inteiro maior ou igual a 0. Tente novamente.\n");
            }
        }

        private static double LerDoublePositivo(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (double.TryParse((Console.ReadLine() ?? "").Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double valor) && valor >= 0)
                    return valor;

                ExibirErro("❌ Erro: Digite um valor numérico válido (ex: 2500.00 ou 2500,00). Tente novamente.\n");
            }
        }

        private static double LerNota(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (double.TryParse((Console.ReadLine() ?? "").Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double nota))
                {
                    if (nota >= 0 && nota <= 10) return nota;
                    ExibirErro("❌ Erro: A nota deve estar entre 0.0 e 10.0. Tente novamente.\n");
                }
                else
                {
                    ExibirErro("❌ Erro: Valor inválido! Digite um número decimal (ex: 8.5 ou 8,5). Tente novamente.\n");
                }
            }
        }


        private static void ExibirMensagem(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        private static void ExibirErro(string texto) => ExibirMensagem(texto, ConsoleColor.Red);
        private static void ExibirSucesso(string texto) => ExibirMensagem(texto, ConsoleColor.Green);
    }
}