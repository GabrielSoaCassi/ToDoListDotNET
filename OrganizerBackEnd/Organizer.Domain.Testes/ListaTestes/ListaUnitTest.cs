using System;
using FluentAssertions;
using Organizer.Domain.Models;
using Organizer.Domain.Validation;
using Xunit;

namespace OrganizerTestes.ListaTestes;

public class ListaUnitTest
{

    [Fact]
    public void CriarLista_ComParametroValido_ResultaObjetovalido()
    {
        Action action = () => new Lista("Lista Nome");
        action.Should().NotThrow<DomainValidationException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CriarLista_ComParametroNullOuVazio_ResultaObjetoinvalido(string nome)
    {
        Action action = () => new Lista(nome);
        action.Should().Throw<DomainValidationException>()
            .WithMessage("Nome inválido insira um nome válido para a lista");
    }

    [Theory]
    [InlineData("A")]
    [InlineData("AB")]
    [InlineData("ABC")]
    
    public void CriarLista_ComParametroInvalido_ResultaObjetoinvalido(string nome)
    {
        {
            Action action = () => new Lista(nome);
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Nome da lista precisa ter no minimo 3 caracteres");
        }
    }
}