using System.ComponentModel.DataAnnotations;

namespace OrganizerBackEnd.Dto
{
    public class CreateListaDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome da lista não Pode ser Nulo")]
        public string Nome { get; set; }
    }
}
