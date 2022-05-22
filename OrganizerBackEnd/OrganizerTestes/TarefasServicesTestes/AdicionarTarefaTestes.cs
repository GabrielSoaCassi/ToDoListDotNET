
using Microsoft.EntityFrameworkCore;
using Moq;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using Xunit;

namespace OrganizerTestes.TarefasServicesTestes
{
    public class AdicionarTarefa
    {
        [Fact]
        public void Adicionar_QuandoReceberParametrosCorretos_DeveInserirATarefa()
        {
            //Arrange
            var listaDummy = new Lista() { Id = 1, Nome = "ListaComTamanhoMaiorQueDezNoNome" };
            var tarefaDummy = new Tarefa() { Nome = "Casar com a Talise", ListaId = 1 };
            var mockContextoLista = new Mock<IOrganizerContext>();
            var mockContextoTarefa = new Mock<IOrganizerContext>();
            mockContextoLista.Setup(l => l.Listas.Add(It.IsAny<Lista>()));
            mockContextoTarefa.Setup(t => t.Tarefas.Add(It.IsAny<Tarefa>()));
            var listaService = new ListaServices(mockContextoLista.Object);
            var tarefaService = new TarefasServices(mockContextoTarefa.Object);
            //Act
            listaService.Adicionar(listaDummy);
            tarefaService.Adicionar(tarefaDummy);
            //Assert
            mockContextoTarefa
                .Verify(t => t.Tarefas.Add(It.IsAny<Tarefa>()), Times.Once);
            mockContextoTarefa.Verify(t => t.SaveChanges(), Times.Once);

        }

        [Fact]
        public void AdicionarTarefa_QuandoReceberParametrosNullos_DeveRetornarArgumentExceptionComMensagem()
        {
            //Arrange
            var tarefaDummy = new Tarefa();
            var mockContextoTarefa = new Mock<IOrganizerContext>();
            mockContextoTarefa.Setup(t => t.Tarefas.Add(It.IsAny<Tarefa>()));
            var tarefaService = new TarefasServices(mockContextoTarefa.Object);
            var msgEsperada = "Tarefa sem nome ou sem referência a lista, dado não inserido no banco";
            //Act
            var excecaoObtida = Assert.Throws<System.ArgumentException>(
                () => tarefaService.Adicionar(tarefaDummy));
            //Assert
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}
