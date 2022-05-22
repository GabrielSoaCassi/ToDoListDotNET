using System.ComponentModel.DataAnnotations;

namespace OrganizerBackEnd.Dto
{
    public class CreateTarefaDto
    {
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Id da Lista que deseja Inserir a tarefa")]
        public int ListaId { get; set; }
    }
}
