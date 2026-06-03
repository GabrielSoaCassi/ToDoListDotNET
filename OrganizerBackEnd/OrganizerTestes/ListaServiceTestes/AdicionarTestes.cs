using System;
using System.Threading.Tasks;
using Moq;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using Xunit;

namespace OrganizerTestes.ListaServiceTestes;

public class Adicionar
{
    [Fact]
    public async Task Adicionar_QuandoReceberParametrosCorretos_DeveInserirAListaNoBD()
    {
        //Arrange
        var listaDummy = new Lista { Id = 1, Nome = "ListaComTamanhoMaiorQueDezNoNome" };
        var mockContextoLista = new Mock<IOrganizerContext>();
        mockContextoLista.Setup(l => l.Listas.Add(It.IsAny<Lista>()));
        var listaService = new ListaService(mockContextoLista.Object);
        //Act
        await listaService.Adicionar(listaDummy);
        //Assert
        mockContextoLista.Verify(l => l.Listas.Add(It.IsAny<Lista>()), Times.Once);
        mockContextoLista.Verify(l => l.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task Adicionar_QuandoReceberParametrosNullos_DeveRetornarArgumentExceptionComMensagem()
    {
        //Arrange
        var objetoDummy = new Lista();
        var mockContextoLista = new Mock<IOrganizerContext>();
        mockContextoLista.Setup(l => l.Listas.Add(It.IsAny<Lista>()));
        var listaService = new ListaService(mockContextoLista.Object);
        var msgEsperada = "Lista nula ou parâmetro inválido, dado não inserido no Banco.";
        //Act
        var excecaoObtida = await Assert.ThrowsAsync<ArgumentException>(() => listaService.Adicionar(objetoDummy));
        //Assert
        Assert.Equal(msgEsperada, excecaoObtida.Message);
    }
}