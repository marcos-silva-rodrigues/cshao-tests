using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes: IDisposable
    {

        private Veiculo veiculo;
        public ITestOutputHelper outputHelper;

        public VeiculoTestes(ITestOutputHelper outputHelper)
        {
            this.veiculo = new Veiculo();
            this.outputHelper = outputHelper;
            this.outputHelper.WriteLine("SETUP");
        }

        [Fact(DisplayName = "Teste n1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            veiculo.Acelerar(10);
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoDeVeiculoPadrao()
        {

            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculos()
        {
            veiculo.Proprietario = "Fulano Silva";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            string dados = veiculo.ToString();

            Assert.Contains("Ficha do Veículo:", dados);
        }

        public void Dispose()
        {
            this.outputHelper.WriteLine("CLEAN UP");
        }
    }
}