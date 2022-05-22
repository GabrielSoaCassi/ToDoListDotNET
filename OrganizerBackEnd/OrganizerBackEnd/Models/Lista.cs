using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganizerBackEnd.Models
{
    public class Lista
  {
    public int Id { get; set; }
    [Required(AllowEmptyStrings = false,ErrorMessage = "O Nome da lista não Pode ser Nulo")]
    public string Nome { get; set; }
    public List<Tarefa> Tarefas { get; set; }

    public Lista()
    {
      Tarefas = new List<Tarefa>() ;
    }
  }
}
