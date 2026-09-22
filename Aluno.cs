using System.Linq.Expressions;

public class Aluno:Pessoa
{
    public int Matricula {get; private set;}
    public List<double> Notas {get; private set;}
    public string Serie{ get; private set;}
    public string Turma{get; private set;}

    public Aluno(string nome, string cpf, long telefone, string email, int matricula, string serie, string turma): base(nome, cpf, telefone, email)
    {
      
        Matricula = matricula;
        Notas = new List<double>();
        Serie = serie;
        Turma =  turma;
   
    }

    public void AdicionarNota(double notaSerie)
    {
        Notas.Add(notaSerie);
        Console.WriteLine($"Nota {notaSerie} adicionada com sucesso!");
    }

    public void RemoverNota(double notaSerie)
    {
        Notas.Remove(notaSerie);
        Console.WriteLine($"Nota {notaSerie} removida com sucesso!");
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