using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganizerBackEnd.Models;

public class Lista
{
    public Lista()
    {
        Tarefas = new List<Tarefa>();
    }

    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome da lista não Pode ser Nulo")]
    public string Nome { get; set; }

    public IEnumerable<Tarefa> Tarefas { get; set; }
}