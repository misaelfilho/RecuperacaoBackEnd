using PLANTAO_UC_COD_BACK.Classes;
internal class Program
{
    private static void Main(string[] args)
    {
        string cnpj;

        Console.Clear();
        Console.WriteLine(@"
    1 - Cadastro PJ
    2 - Listar PJ
    3 - Sair do Sistema
    ");


        string? opcao = Console.ReadLine();
        PessoaJuridica metodoPJ = new PessoaJuridica();

        if (opcao == "1")
        {

            PessoaJuridica pj = new PessoaJuridica();

            Console.WriteLine("Informe o nome da PJ: ");
            pj.Nome = Console.ReadLine();

            Console.WriteLine("Informe o rendimento da PJ: ");
            pj.Rendimento = float.Parse(Console.ReadLine()!);

            Console.WriteLine("Informe o CNPJ da PJ: ");
            pj.CNPJ = Console.ReadLine();

            do
            {
                Console.WriteLine("Informe o CNPJ da PJ (13 dígitos): ");
                cnpj = Console.ReadLine()!;
            } while (!ValidarCNPJ(cnpj));

            pj.CNPJ = cnpj;

            metodoPJ.Inserir(pj);

            Console.WriteLine("\n\nPessoa Juridica cadastrada com sucesso!!");

        }


        else if (opcao == "2")
        {
            Console.WriteLine($"Digite o nome do arquivo");
            string nomeArquivo = Console.ReadLine()!;

            PessoaJuridica pessoaJuridica = metodoPJ.Ler(nomeArquivo);

            Console.WriteLine(@$"
            Nome: {pessoaJuridica.Nome}
            Rendimento: {pessoaJuridica.Rendimento}
            CNPJ: {pessoaJuridica.CNPJ}
        ");
            Console.WriteLine("\n\nPressione ENTER para sair");
            Console.ReadLine();

        }

        else if (opcao == "3")
        {
            Console.Clear();

            Console.WriteLine("Obrigado por usar o nosso sistema!");
        }

        else
        {
            Console.Clear();

            Console.WriteLine("Opção invalida, Tente novamente.");
        }

        static bool ValidarCNPJ(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            return cnpj.Length == 13;
        }
    }
}