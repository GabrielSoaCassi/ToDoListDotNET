using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using Xunit;

namespace OrganizerTestes.ListaServiceTestes;

public class AtualizarTarefaTestes
{
    [Theory]
    [InlineData("NomeAtualizado")]
    public async Task Atualizar_QuandoReceberParametrosCorretos_DeveAtualizarONomeDaLista(string nomeAtualizado)
    {
        //Arrange
        var listaAtualizada = new Lista { Id = 1, Nome = nomeAtualizado };
        var mockSet = new Mock<DbSet<Lista>>();
        var mockContextLista = new Mock<IOrganizerContext>();
        mockContextLista.Setup(l => l.Listas)
            .Returns(mockSet.Object);
        var listaService = new ListaService(mockContextLista.Object);
        // Act
        var lista = await listaService.Atualizar(1, listaAtualizada);
        //Assert
        Assert.Contains(lista.Nome, listaAtualizada.Nome);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("    ")]
    public async Task Atualizar_QuandoReceberParametrosIncorretos_RetornaArgumentException(string nomeIncorreto)
    {
        var listaDummy = new Lista { Id = 1, Nome = "Nome Que será trocado" };
        var mockSet = new Mock<DbSet<Lista>>();
        var mockContextLista = new Mock<IOrganizerContext>();
        mockContextLista.Setup(l => l.Listas)
            .Returns(mockSet.Object);
        var listaService = new ListaService(mockContextLista.Object);
        var listaIncorreta = new Lista { Nome = nomeIncorreto };
        var msgEsperada = "Parâmetro de ID ou lista invalida. Verifique e tente novamente";
        //Act
        var excecaoObtida =
            await Assert.ThrowsAsync<ArgumentException>(() => listaService.Atualizar(1, listaIncorreta));
        //Assert
        Assert.Equal(msgEsperada, excecaoObtida.Message);
    }
}