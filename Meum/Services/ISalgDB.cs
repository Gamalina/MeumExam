using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeumLibrary.Model;

namespace Meum.Services
{
    public interface ISalgDB
    {
        List<Salg> GetAll();
        Salg GetById(int id);
        Salg Create(Salg newItem);
        Salg Delete(int id);
        Salg Modify(Salg modifiedItem);
    }
}
