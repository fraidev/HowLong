using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowLong.Models.Persistance
{
    public interface ISerieRepository
    {
        Serie Get(int id);
        IEnumerable<Serie> GetAll();
        Serie Add(Serie serverData);
        void Delete(int id);
        bool Update(Serie serverData);
    }
}