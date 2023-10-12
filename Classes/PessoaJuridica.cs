namespace RecuperacaoBackEnd.Classes
{
    public class PessoaJuridica : Pessoa
{
    public string? CNPJ { get; set; }

    public void Inserir(PessoaJuridica pj)
    {
        using (StreamWriter escritor = new StreamWriter(pj.Nome + ".txt"))
        {
            escritor.WriteLine($"{pj.Nome},{pj.Rendimento},{pj.CNPJ}");
        }
    }

    public PessoaJuridica Ler(string nomeArquivo)
    {
        PessoaJuridica pj = new PessoaJuridica();

        using (StreamReader sr = new StreamReader($"{nomeArquivo}.txt"))
        {
                            string[] atributos = sr.ReadLine()!.Split(",");

                pj.Nome = atributos[0];
                pj.Rendimento = float.Parse(atributos[1]);
                pj.CNPJ = atributos[2];
        }
        return pj;
    }
}
}