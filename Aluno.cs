using System.Linq.Expressions;

public class Aluno:Pessoa
{
    public int Matricula {get; private set;}
    public List<double> Notas {get; private set;} 
    public string Serie{ get; private set;}
    public string Turma{get; private set;}

    public Aluno(string nome, string cpf, int telefone, string email, int matricula, string serie, string turma): base(nome, cpf, telefone, email)
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


    public void CalcularMedia()
    {
        if(Notas.Any() == true)
        {
              Notas.Average();
              
        }
    
    else
    {
         0.0;
    }
    }

    public void ExibirMedia()
    {
        if(N >=6 )
        {
            
        }
        
    }

    
        
    


} 