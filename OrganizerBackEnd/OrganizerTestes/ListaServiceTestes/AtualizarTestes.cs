using Moq;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OrganizerTestes.ListaServiceTestes
{
    public class AtualizarTarefaTestes
    {
        [Theory]
        [InlineData("NomeAtualizado", " ")]
        public void Atualizar_QuandoReceberParametrosCorretos_DeveAtualizarONomeDaLista(string nomeAtualizado, string nome)
        {
            //Arrange
            var listaAtualizada = new Lista() { Id = 1, Nome = nomeAtualizado };
            var listaDummy = new Lista() { Id = 1, Nome = nome };
            var mockContextLista = new Mock<IOrganizerContext>();
            mockContextLista.Setup(l => l.Listas).Returns(DbSetShared.GetQueryableMockDbSet(new List<Lista>() { listaDummy }));
            var listaService = new ListaServices(mockContextLista.Object);
            // Act
            listaService.Atualizar(1, listaAtualizada);
            //Assert
            Assert.Contains(listaAtualizada.Nome, listaDummy.Nome);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Atualizar_QuandoReceberParametrosIncorretos_RetornaArgumentException(string nomeIncorreto)
        {
            var listaDummy = new Lista() { Id = 1, Nome = "Nome Que será trocado" };
            var mockContextLista = new Mock<IOrganizerContext>();
            mockContextLista.Setup(l => l.Listas).Returns(DbSetShared.GetQueryableMockDbSet(new List<Lista>() { listaDummy }));
            var listaService = new ListaServices(mockContextLista.Object);
            var listaIncorreta = new Lista() { Nome = nomeIncorreto};
            var msgEsperada = "Parâmetro de ID ou lista invalida. Verifique e tente novamente";
            //Act
            var excecaoObtida = Assert.Throws<ArgumentException>(() => listaService.Atualizar(1, listaIncorreta));
            //Assert
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}
