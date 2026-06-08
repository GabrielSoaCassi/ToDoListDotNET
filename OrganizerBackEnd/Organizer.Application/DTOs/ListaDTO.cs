using System.ComponentModel.DataAnnotations;

namespace Organizer.Application.DTOs;

public class ListaDTO
{
    public int? Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome da lista não Pode ser Nulo")]
    public string Nome { get; set; }
}