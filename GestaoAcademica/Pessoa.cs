using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoAcademica
{
    // Classe abstrata que serve de base para Aluno e Professor
    public abstract class Pessoa
    {
        private string _nome = string.Empty;
        private string _cpf = string.Empty;

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome não pode ser vazio.");
                _nome = value;
            }
        }

        public string CPF
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O CPF não pode ser vazio.");
                _cpf = value;
            }
        }

        public DateTime DataNascimento { get; set; }

        public Pessoa(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        // Método abstrato para demonstrar Polimorfismo nas classes filhas
        public abstract void ExibirInformacoes();
    }
}