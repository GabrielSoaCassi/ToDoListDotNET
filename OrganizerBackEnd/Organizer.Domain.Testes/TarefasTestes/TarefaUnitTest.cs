using System;
using FluentAssertions;
using Organizer.Domain.Models;
using Organizer.Domain.Validation;
using Xunit;

namespace OrganizerTestes.TarefasTestes;

public class TarefaUnitTest
{
    [Fact]
    public void CriarTarefa_ComParametroValido_ResultaObjetovalido()
    {
        Action action = () => new Tarefa("Tarefa Nome",1);
        action.Should().NotThrow<DomainValidationException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CriarTarefa_ComNomeNullOuVazio_ResultaObjetoinvalido(string nome)
    {
        Action action = () => new Tarefa(nome,1);
        action.Should().Throw<DomainValidationException>()
            .WithMessage("Nome inválido insira um nome válido para a tarefa");
    }

    [Theory]
    [InlineData("A")]
    [InlineData("AB")]
    [InlineData("ABC")]
    
    public void CriarTarefa_ComParametroInvalido_ResultaObjetoinvalido(string nome)
    {
        {
            Action action = () => new Tarefa(nome,1);
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Nome da tarefa precisa ter no minimo 3 caracteres");
        }
    }
    
    [Fact]
    public void CriarTarefa_ComIdInvalido_ResultaObjetoInvalido()
    {
        Action action = () => new Tarefa("Tarefa Nome",-1);
        action.Should().Throw<DomainValidationException>()
            .WithMessage("Essa tarefa precisa estar atribuída a alguma lista");
    }
    
    
}