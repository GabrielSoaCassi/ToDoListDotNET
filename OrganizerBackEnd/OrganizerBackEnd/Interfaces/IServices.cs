using System.Collections.Generic;

namespace OrganizerBackEnd.Interfaces
{
    public interface IServices<T>
  {
    T Adicionar(T opt);
    void Remover(int id);
    T Atualizar(int id,T opt);
    T PesquisarPorId(int id);
    List<T> Pesquisar();
  }
}
