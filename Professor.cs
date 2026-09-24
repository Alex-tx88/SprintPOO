public class Professor:Pessoa
{
    
    public decimal Salario {get; private set;}
    private List<string> Turma;
    public string Disciplina{get;  private set;}



    public Professor(string nome, string cpf, string telefone, string email , DateOnly datanascimento, string disciplina ,decimal salario): base (nome, cpf, telefone, email, datanascimento)
    {
        Salario=salario;
        Turma= new List<string>();
        Disciplina = disciplina;

    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine("======= Professor =======");
        base.ExibirDetalhes();
        Console.WriteLine($"Salario: {Salario} \nTurma: {Turma} \nDisciplina: {Disciplina}");
    }



}