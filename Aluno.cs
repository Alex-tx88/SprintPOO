using System.Linq.Expressions;

public class Aluno:Pessoa
{
    public int Matricula {get; private set;}
    public List<double> Notas {get; private set;}
    public string Serie{ get; private set;}
    public string Turma{get; private set;}

    public Aluno(string nome, string cpf, string telefone, string email, DateOnly datanascimento ,int matricula, string serie, string turma): base(nome, cpf, telefone, email, datanascimento)
    {
      
        Matricula = matricula;
        Notas = new List<double>();
        Serie = serie;
        Turma =  turma;
   
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine("======= Aluno =======");
        base.ExibirDetalhes();
        Console.WriteLine($"Matricula: {Matricula} \nNotas: {Notas} \nSerie: {Serie} \nTurma: {Turma}");

    }




    public double CalcularMedia()
    {
        if( Notas== null || !Notas.Any())
        {
              return 0.0;
              
        }
        else
        {
         return Notas.Average();
        }
    }

    public void ExibirBoletim()
    {
        
    }

    public void ExibirMedia()
    {       
        double Media = CalcularMedia();
        if (Media>=6.0)
        {
            Console.WriteLine($"O aluno {base.Nome} tirou {CalcularMedia()} e está aprovado!");
        }
        else
        {
            Console.WriteLine($"O aluno {base.Nome}, tirou {CalcularMedia()} e está reprovado");
        }

        
    }

    
        
    


} 