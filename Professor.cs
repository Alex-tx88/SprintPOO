public class Professor:Pessoa
{
    
    public decimal Salario {get; private set;}
    public List<string> turma {get; private set;}


    public Professor(string nome, string cpf, long telefone, string email , decimal salario): base (nome, cpf, telefone, email)
    {
        Salario=salario;
        turma= new List<string>();

    }



}