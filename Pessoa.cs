public abstract class Pessoa
{
    public string Nome{get; private set;}
    public string Cpf {get; private set;}
    public string Telefone{get; private set;}
    public string Email{get; private set;}
    public DateOnly DataNascimento { get; private set;}

    public Pessoa(string nome, string cpf, string telefone, string email, DateOnly datanascimento )
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Email = email;
        DataNascimento = datanascimento;
    }


    public virtual void ExibirDetalhes()
    {
        Console.WriteLine($"Nome: {Nome} \nCPF: {Cpf} \nTelefone: {Telefone} \nEmail: {Email} \nData de Nascimento: {DataNascimento}");
    }







}