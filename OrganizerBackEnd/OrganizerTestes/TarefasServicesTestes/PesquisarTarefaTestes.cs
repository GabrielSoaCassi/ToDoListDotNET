using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using Xunit;

namespace OrganizerTestes.TarefasServicesTestes;

public class PesquisarTarefaTestes
{
    [Fact]
    public async Task Pesquisar_QuandoChamado_DeveRetornarTarefas()
    {
        //Arrange
        var tarefasEsperadas = new List<Tarefa>();
        for (var i = 0; i < 5; i++)
        {
            var tarefaAtual = new Tarefa { Id = i, Nome = "NomeVálido" };
            tarefasEsperadas.Add(tarefaAtual);
        }

        var mockContext = new Mock<IOrganizerContext>();
        mockContext.Setup(t => t.Tarefas)
            .Returns(DbSetShared
                .GetQueryableMockDbSet(tarefasEsperadas));
        var tarefaService = new TarefasService(mockContext.Object);
        //Act
        var resultado = await tarefaService.PesquisarPaginados(1, 5);
        //Assert
        Assert.NotNull(resultado);
        Assert.Equal(tarefasEsperadas.Count, resultado.Count());
    }

    [Fact]
    public void PesquisarPorId_QuandoReceberId_DeveRetornarTarefaReferenteAoId()
    {
        //Arrange
        var tarefaEsperadaId1 = 1;
        var tarefaBanco = new Tarefa { Id = tarefaEsperadaId1, ListaId = 1, Nome = "TarefaEsperada" };
        var listaDummy1 = new Lista { Nome = "ListaComNomeVálido", Id = 1 };
        var mockContext = new Mock<IOrganizerContext>();
        mockContext.Setup(l => l.Listas)
            .Returns(DbSetShared
                .GetQueryableMockDbSet(new List<Lista> { listaDummy1 }));
        mockContext.Setup(t => t.Tarefas)
            .Returns(DbSetShared
                .GetQueryableMockDbSet(new List<Tarefa> { tarefaBanco }));
        var tarefaService = new ListaService(mockContext.Object);
        //Act
        var resultado = tarefaService.PesquisarPorId(tarefaEsperadaId1);
        //Assert
        Assert.NotNull(resultado);
        Assert.Equal(tarefaEsperadaId1, resultado.Id);
    }
}