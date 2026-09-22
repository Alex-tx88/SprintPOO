namespace SprintPOO
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=======Sistema de Gestão Acadêmica======");
            Console.WriteLine("=======Cadastre um Aluno ou Professor=======");
            Console.WriteLine("1. Cadastre um aluno \n2. Cadastre um Professor");
            
            while (true)
            {
                Console.WriteLine("Selecione uma opção:");
            
            if(int.TryParse(Console.ReadLine(), out int num)){
            switch (num)
            {
                case 1:
                Console.WriteLine("Cadastrando Aluno...");

                break;

                case 2:
                Console.WriteLine("Cadastrando Professor...");

                break;
                
                default:
                Console.WriteLine("Opção inválida! Escolha um número do menu.");
                continue;
            }

            
            }else{
                Console.WriteLine("Numero inválido! Digite apenas números validos");
            }

            
            }
        }
    }



}
