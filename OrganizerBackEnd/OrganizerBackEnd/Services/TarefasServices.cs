using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizerBackEnd.Services
{
    public class TarefasServices : IServices<Tarefa>
    {
        private readonly IOrganizerContext _context;
        public TarefasServices(IOrganizerContext context)
        {
            _context = context;
        }

        public Tarefa Adicionar(Tarefa tarefa)
        {
            if (!string.IsNullOrEmpty(tarefa.Nome) && tarefa.ListaId != 0)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return tarefa;
            }
            throw new ArgumentException("Tarefa sem nome ou sem referência a lista, dado não inserido no banco");
        }

        public Tarefa Atualizar(int id, Tarefa novaTarefa)
        {
            if (id != 0 && !string.IsNullOrEmpty(novaTarefa.Nome) && !string.IsNullOrWhiteSpace(novaTarefa.Nome))
            {
                var tarefaParaAtualizar = PesquisarPorId(id);
                tarefaParaAtualizar.Nome = novaTarefa.Nome;
                _context.Tarefas.Update(tarefaParaAtualizar);
                _context.SaveChanges();
                return novaTarefa;
            }
            throw new ArgumentException("Parâmetro de ID ou tarefa invalida. Verifque e tente novamente");
        }

        public List<Tarefa> Pesquisar()
        {
            var resultado = _context.Tarefas.ToList();
            return resultado;
        }

        public Tarefa PesquisarPorId(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
                return tarefa;
            throw new ArgumentException("Tarefa não encontrada");
        }

        public void Remover(int id)
        {
            var resultadoTarefa = PesquisarPorId(id);
            _context.Tarefas.Remove(resultadoTarefa);
            _context.SaveChanges();
        }

    }
}