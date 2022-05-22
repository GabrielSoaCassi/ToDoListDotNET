using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizerBackEnd.Services
{
    public class ListaServices : IServices<Lista>
    {
        private readonly IOrganizerContext _context;

        public ListaServices(IOrganizerContext context)
        {
            _context = context;
        }

        public Lista Adicionar(Lista lista)
        {
            if (!string.IsNullOrEmpty(lista.Nome))
            {
                _context.Listas.Add(lista);
                _context.SaveChanges();
                return lista;
            }
            throw new ArgumentException("Lista nula ou parâmetro inválido, dado não inserido no Banco.");
        }

        public Lista Atualizar(int id, Lista listaAtualizada)
        {
            if (id != 0 && !string.IsNullOrEmpty(listaAtualizada.Nome) && !string.IsNullOrWhiteSpace(listaAtualizada.Nome))
            {
                var listaParaAtualizar = PesquisarPorId(id);
                listaParaAtualizar.Nome = listaAtualizada.Nome;
                _context.SaveChanges();
                return listaAtualizada;
            }
            throw new ArgumentException("Parâmetro de ID ou lista invalida. Verifique e tente novamente");
        }

        public List<Lista> Pesquisar()
        {
            var resultado = from lista in _context.Listas
                            select new Lista()
                            {
                                Id = lista.Id,
                                Nome = lista.Nome,
                                Tarefas = lista.Tarefas
                            };
            return resultado.ToList();
        }

        public Lista PesquisarPorId(int id)
        {
            var resultado = _context.Listas.FirstOrDefault(l => l.Id == id);
            if (resultado != null)
                return resultado;

            throw new ArgumentException("Lista não encontrada");
        }

        public void Remover(int id)
        {
            var resultadoLista = PesquisarPorId(id);
            _context.Listas.Remove(resultadoLista);
            _context.SaveChanges();
        }
    }
}