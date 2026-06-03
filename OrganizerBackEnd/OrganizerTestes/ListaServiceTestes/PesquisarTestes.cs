using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using Xunit;

namespace OrganizerTestes.ListaServiceTestes;

public class PesquisarTarefaTestes
{
    [Fact]
    public async Task Pesquisar_QuandoChamado_DeveRetornarListasPaginadas()
    {
        //Arrange
        var quantidadeListasEsperadas = 5;
        var listasDummy = new List<Lista>();
        for (var i = 0; i < 10; i++)
        {
            var listaAtual = new Lista { Id = i, Nome = "NomeVálido" };
            listasDummy.Add(listaAtual);
        }

        var mockContextLista = new Mock<IOrganizerContext>();
        mockContextLista.Setup(l => l.Listas)
            .Returns(DbSetShared.GetQueryableMockDbSet(listasDummy));
        var listaService = new ListaService(mockContextLista.Object);
        //Act
        var resultado = await listaService.PesquisarPaginados();
        //Assert
        Assert.NotNull(resultado);
        Assert.Equal(quantidadeListasEsperadas, resultado.Count());
    }

    [Fact]
    public async Task PesquisarPorId_QuandoReceberId_DeveRetornarListaReferenteAoId()
    {
        var listaEsperadaId1 = 1;
        var listaDummy1 = new Lista { Nome = "", Id = listaEsperadaId1 };
        var mockContextLista = new Mock<IOrganizerContext>();
        mockContextLista.Setup(l => l.Listas)
            .Returns(DbSetShared
                .GetQueryableMockDbSet(new List<Lista> { listaDummy1 }));
        var listaService = new ListaService(mockContextLista.Object);
        //Act
        var resultado = await listaService.PesquisarPorId(listaEsperadaId1);
        //Assert
        Assert.NotNull(resultado);
        Assert.Equal(listaEsperadaId1, resultado.Id);
    }
}