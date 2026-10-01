using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoAcademica
{
    public class Professor : Pessoa
    {
        private double _salario;

        public double Salario
        {
            get => _salario;
            set
            {
                if (value < 0)
                    throw new ArgumentException("O salário não pode ser negativo.");
                _salario = value;
            }
        }

        public List<string> Turmas { get; set; }

        public Professor(string nome, string cpf, DateTime dataNascimento, double salario)
            : base(nome, cpf, dataNascimento)
        {
            Salario = salario;
            Turmas = new List<string>();
        }

        public void AdicionarTurma(string turma)
        {
            if (!string.IsNullOrWhiteSpace(turma))
                Turmas.Add(turma);
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine($"[PROFESSOR] Nome: {Nome} | CPF: {CPF} | Nasc: {DataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"            Salário: R$ {Salario:F2} | Turmas/Disciplinas: {string.Join(", ", Turmas)}");
        }
    }
}