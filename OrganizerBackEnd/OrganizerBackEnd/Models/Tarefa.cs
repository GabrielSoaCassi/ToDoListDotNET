using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizerBackEnd.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome da Tarefa não Pode ser Nulo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Id da Lista que deseja Inserir a tarefa")]
        public int ListaId { get; set; }
    }
}
