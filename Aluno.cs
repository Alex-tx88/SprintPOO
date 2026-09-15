using System.Linq.Expressions;

public class Aluno:Pessoa
{
    public int Matricula {get; private set;}
    public List<int> Notas {get; private set;} 
    public string Curso{ get; private set;}
    public string Turma{get; private set;}

    public Aluno(int matricula, List<int>notas, string curso, string turma)
    {
        Matricula = matricula;
        Notas = notas;
        Curso = curso;
        Turma =  turma;
   
    }




} 