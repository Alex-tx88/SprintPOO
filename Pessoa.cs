public abstract class Pessoa
{
    public string Nome{get; private set;}
    public string Cpf {get; private set;}
    public int Telefone{get; private set;}
    public string Email{get; private set;}

    public DateOnly DataNascimento { get; private set;} 

    public Pessoa(string nome, string cpf, int telefone, string email )
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Email = email;
    }


  




}