
using Microsoft.EntityFrameworkCore;
using Moq;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using System;
using Xunit;

namespace OrganizerTestes.ListaServiceTestes
{
    public class Adicionar
    {
        [Fact]
        public void Adicionar_QuandoReceberParametrosCorretos_DeveInserirAListaNoBD()
        {
            //Arrange
            var listaDummy = new Lista() { Id = 1, Nome = "ListaComTamanhoMaiorQueDezNoNome" };
            var mockContextoLista = new Mock<IOrganizerContext>();
            mockContextoLista.Setup(l => l.Listas.Add(It.IsAny<Lista>()));
            var listaService = new ListaServices(mockContextoLista.Object);
            //Act
            listaService.Adicionar(listaDummy);
            //Assert
            mockContextoLista.Verify(l => l.Listas.Add(It.IsAny<Lista>()), Times.Once);
            mockContextoLista.Verify(l => l.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Adicionar_QuandoReceberParametrosNullos_DeveRetornarArgumentExceptionComMensagem()
        {
            //Arrange
            var objetoDummy = new Lista();
            var mockContextoLista = new Mock<IOrganizerContext>();
            mockContextoLista.Setup(l => l.Listas.Add(It.IsAny<Lista>()));
            var listaService = new ListaServices(mockContextoLista.Object);
            var msgEsperada = "Lista nula ou parâmetro inválido, dado não inserido no Banco.";
            //Act
            var excecaoObtida = Assert.Throws<ArgumentException>(
                () => listaService.Adicionar(objetoDummy));
            //Assert
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}
