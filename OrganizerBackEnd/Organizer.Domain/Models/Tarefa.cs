using System.ComponentModel.DataAnnotations;
using Organizer.Domain.Validation;

namespace Organizer.Domain.Models;

public class Tarefa : Base
{
    public Tarefa(string nome, int listaId)
    {
        ValidateDomain(nome, listaId);
    }

    [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome da Tarefa não Pode ser Nulo")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o Id da Lista que deseja Inserir a tarefa")]
    public int ListaId { get; set; }

    public Lista Lista { get; set; }

    private void ValidateDomain(string nome, int listaId)
    {
        DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome inválido insira um nome válido para a tarefa");
        DomainValidationException.When(nome.Length <= 3, "Nome da tarefa precisa ter no minimo 3 caracteres");
        DomainValidationException.When(listaId <= 0, "Essa tarefa precisa estar atribuída a alguma lista");
        Nome = nome;
        ListaId = listaId;
    }
}