public class Professor:Pessoa
{
    
    public decimal Salario {get; private set;}
    private List<string> Turma;
    public string Disciplina{get;  private set;}



    public Professor(string nome, string cpf, string telefone, string email , decimal salario): base (nome, cpf, telefone, email)
    {
        Salario=salario;
        Turma= new List<string>();

    }



}