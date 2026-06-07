using System.ComponentModel.DataAnnotations;

namespace Organizer.Application.DTOs;

public class TarefaDTO
{
    public string Nome { get; set; }

    [Required(ErrorMessage = "Id da Lista a ser inserido inválido")]
    public int ListaId { get; set; }
}