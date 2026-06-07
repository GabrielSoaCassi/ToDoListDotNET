using System.ComponentModel.DataAnnotations;
using Organizer.Domain.Validation;

namespace Organizer.Domain.Models;

public class Lista : Base
{
    public Lista(string nome)
    {
        ValidateDomain(nome);
    }

    [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome da lista não Pode ser Nulo")]
    public string Nome { get; set; }

    public IEnumerable<Tarefa> Tarefas { get; set; }

    private void ValidateDomain(string nome)
    {
        DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome inválido insira um nome válido para a lista");
        DomainValidationException.When(nome.Length <= 3, "Nome da lista precisa ter no minimo 3 caracteres");
        Nome = nome;
    }
}