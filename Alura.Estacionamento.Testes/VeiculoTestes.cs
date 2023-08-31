using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste
    {
        public ITestOutputHelper Output { get; }
        private Veiculo veiculo;

        public VeiculoTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do  construtor.");
            veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
        }

        [Fact(DisplayName = "Teste n°1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComAceleracao10()
        {
            veiculo.Acelerar(10);
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n°2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComFreio10()
        {
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietario()
        {
        }

        [Fact]
        public void AlteraDadosVeiculoDeUmDeterminadoVeiculoComBaseNaPlaca()
        {

            Patio estacionamento = new Patio();
            Operador operador = new Operador();
            operador.Nome = "Operador Noturno";
            estacionamento.OperadorPatio = operador;
            var veiculo = new Veiculo();
            veiculo.Proprietario = "José Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Tipo = TipoVeiculo.Motocicleta;
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Opala";

            var alterado = estacionamento.AlterarDados(veiculoAlterado);
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        [Fact]
        public void GerarFichadeInformaçãodoProprioVeiculo()
        {
            var veiculo = new Veiculo();
            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ZXC-8888";

            string dadosveiculo = veiculo.ToString();

            Assert.Contains("Ficha do veículo", dadosveiculo);
        }

        [Fact]
        public void TestaNomeProprietarioComDoisCaracteres()
        {            
            string nomeProprietario = "Ab";
         
            Assert.Throws<FormatException>(
            
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaQuantidadeCaracteresPlacaVeiculo()
        {
            string placa = "Ab";
            Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
            );
        }
    }
}