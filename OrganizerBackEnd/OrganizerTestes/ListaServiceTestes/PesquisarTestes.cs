using Moq;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using System.Collections.Generic;
using Xunit;

namespace OrganizerTestes.ListaServiceTestes
{
    public class PesquisarTarefaTestes
    {
        [Fact]
        public void Pesquisar_QuandoChamado_DeveRetornarListas()
        {
            //Arrange
            var listasEsperadas = new List<Lista>() { };
            for (var i = 0; i < 5; i++)
            {
                var listaAtual = new Lista() { Id = i, Nome = "NomeVálido" };
                listasEsperadas.Add(listaAtual);
            }
            var mockContextLista = new Mock<IOrganizerContext>();
            mockContextLista.Setup(l => l.Listas)
                .Returns(DbSetShared
                .GetQueryableMockDbSet(listasEsperadas));
            var listaService = new ListaServices(mockContextLista.Object);
            //Act
            var resultado = listaService.Pesquisar();
            //Assert
            Assert.NotNull(resultado);
            Assert.Equal(listasEsperadas.Count, resultado.Count);
        }

        [Fact]
        public void PesquisarPorId_QuandoReceberId_DeveRetornarListaReferenteAoId()
        {
            var listaEsperadaId1 = 1;
            var listaDummy1 = new Lista() { Nome = "", Id = listaEsperadaId1 };
            var listaEsperada = new List<Lista>() { listaDummy1 };
            var mockContextLista = new Mock<IOrganizerContext>();
            mockContextLista.Setup(l => l.Listas)
                .Returns(DbSetShared
                .GetQueryableMockDbSet(new List<Lista>() { listaDummy1 }));
            var listaService = new ListaServices(mockContextLista.Object);
            //Act
            var resultado = listaService.PesquisarPorId(listaEsperadaId1);
            //Assert
            Assert.NotNull(resultado);
            Assert.Equal(listaEsperadaId1, resultado.Id);

        }
    }
}