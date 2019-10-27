using System.Collections.Generic;
using GestaoApp.Models;

namespace GestaoApp.Repositories
{
    public interface IResultadoRepository
    {
        void AddResultados(params Resultado[] resultados);
        IList<Resultado> FindAll();
    }
}