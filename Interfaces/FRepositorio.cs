using System.Collections.Generic;

namespace DIO.Filmes.Interfaces
{
    public interface FRepositorio<F>
    {
        List<F> Lista();
        F RetornaPorId(int id);        
        void Insere(F entidade);        
        void Exclui(int id);        
        void Atualiza(int id, F entidade);
        int ProximoId();
    }
}