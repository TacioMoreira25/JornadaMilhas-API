using Bogus;
using JornadaMilhas.Dominio.Entidades;

internal class RotaDataBuilder : Faker<Rota>
{
    public string? Origem { get; set; }
    public string? Destino { get; set; }

    public RotaDataBuilder()
    {
        CustomInstantiator(f =>
        {
            string origem = Origem ?? f.Lorem.Sentence(2);
            string destino = Destino ?? f.Lorem.Sentence(2);
            return new Rota(origem, destino);
        });
    }

    public Rota Build() => Generate();
}