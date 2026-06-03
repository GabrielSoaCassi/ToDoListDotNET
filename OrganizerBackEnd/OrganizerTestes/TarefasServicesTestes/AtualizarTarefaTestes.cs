using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using Xunit;

namespace OrganizerTestes.TarefasServicesTestes;

public class AtualizarTarefaTestes
{
    [Fact]
    public async Task Atualizar_QuandoTarefaReceberParametrosCorretos_DeveAtualizarONomeDaTarefa()
    {
        //Arrange
        var listaDummy = new Lista { Id = 1, Nome = "ListaComNomeValido" };
        var tarefaAtualizada = new Tarefa { Id = 1, ListaId = 1, Nome = "NomeNovo" };
        var tarefaBanco = new Tarefa { Id = 1, ListaId = 1, Nome = "NomeAntigo" };
        var mockContext = new Mock<IOrganizerContext>();
        mockContext.Setup(l => l.Listas).Returns(DbSetShared.GetQueryableMockDbSet(new List<Lista> { listaDummy }));
        mockContext.Setup(t => t.Tarefas).Returns(DbSetShared.GetQueryableMockDbSet(new List<Tarefa> { tarefaBanco }));
        var tarefaServices = new TarefasService(mockContext.Object);
        //Act
        var result = await tarefaServices.Atualizar(1, tarefaAtualizada);
        //Assert
        Assert.Equal(result.Id, tarefaAtualizada.Id);
        Assert.Equal(result.Nome, tarefaAtualizada.Nome);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task Atualizar_QuandoReceberParametrosIncorretos_RetornaArgumentException(string nomeIncorreto)
    {
        var listaDummy = new Lista { Id = 1, Nome = "ListaComNomeVálido" };
        var tarefaBanco = new Tarefa { Id = 1, ListaId = 1, Nome = "BeberCairLevantar" };
        var mockContext = new Mock<IOrganizerContext>();
        mockContext.Setup(l => l.Listas).Returns(DbSetShared.GetQueryableMockDbSet(new List<Lista> { listaDummy }));
        mockContext.Setup(l => l.Tarefas).Returns(DbSetShared.GetQueryableMockDbSet(new List<Tarefa> { tarefaBanco }));
        var tarefaService = new TarefasService(mockContext.Object);
        var tarefaIncorreta = new Tarefa { Nome = nomeIncorreto };
        var msgEsperada = "Parâmetro de ID ou tarefa invalida. Verifque e tente novamente";
        //Act
        var excecaoObtida =
            await Assert.ThrowsAsync<ArgumentException>(() => tarefaService.Atualizar(1, tarefaIncorreta));
        //Assert
        Assert.Equal(msgEsperada, excecaoObtida.Message);
    }
}