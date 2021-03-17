using System;
using System.Collections.Generic;
using System.Text;

namespace BCLocaliza.CadastroSeries
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atuliza(int id, T entidade);
        int ProximoId();
    }
}
