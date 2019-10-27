using System.Collections.Generic;
using GestaoApp.Models;

namespace GestaoApp.Repositories
{
    public interface IProvaRepository
    {
        void AddRangeProva(params Prova[] prova);
        IList<Prova> FindAll();
    }
}