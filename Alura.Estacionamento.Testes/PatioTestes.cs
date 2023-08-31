using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {

        [Fact]
        public void ValidaFaturamento()
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Fulano Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1456", "preto", "Gol")]
        [InlineData("Jose Silva", "PSL-5112", "azul", "Fusca")]
        [InlineData("Maria Silva", "GFT-1498", "verde", "Opala")]
        public void ValidaFaturamentoComVariosVeiculos(
            string proprietario,
            string placa,
            string cor,
            string modelo)
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1456", "preto", "Gol")]
        public void LocalizaVeiculoNoPatio(
            string proprietario,
            string placa,
            string cor,
            string modelo)
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var consultado = estacionamento.PesquisaVeiculo(placa);

            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlteraDadosVeiculos()
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Fulano Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Prteo";
            veiculoAlterado.Placa = "asd-9999";
            veiculoAlterado.Modelo = "Opala";

            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

    }
}
