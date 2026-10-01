using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoAcademica
{
    public class Aluno : Pessoa
    {
        public string Matricula { get; set; }
        public List<double> Notas { get; set; }

        public Aluno(string nome, string cpf, DateTime dataNascimento, string matricula)
            : base(nome, cpf, dataNascimento)
        {
            if (string.IsNullOrWhiteSpace(matricula))
                throw new ArgumentException("A matrícula não pode ser vazia.");

            Matricula = matricula;
            Notas = new List<double>();
        }

        public void AdicionarNota(double nota)
        {
            if (nota < 0 || nota > 10)
                throw new ArgumentOutOfRangeException(nameof(nota), "A nota deve estar entre 0 e 10.");

            Notas.Add(nota);
        }

        public double CalcularMedia()
        {
            if (Notas.Count == 0) return 0.0;
            return Notas.Average();
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine($"[ALUNO] Nome: {Nome} | CPF: {CPF} | Nasc: {DataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"        Matrícula: {Matricula} | Média: {CalcularMedia():F2} | Notas: {string.Join(", ", Notas)}");
        }
    }
}