namespace SprintPOO
{
    class Program
    {
        static void Main()
        {
            Aluno a1 = new Aluno("Alex", "10352958570", 71988327557,"alexteix@gmail.com",021885062,"2°Ano","Matutino");
            
            a1.AdicionarNota(7.0);
            a1.AdicionarNota(4.6);
            a1.AdicionarNota(6.0);
            a1.AdicionarNota(5.0);
            a1.CalcularMedia();
            a1.ExibirMedia();


            
        }
    }



}
