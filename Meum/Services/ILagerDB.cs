using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeumLibrary.Model;

namespace Meum.Services
{
    public interface ILagerDB
    {

        List<Lager> GetAll();

        Lager GetByID(int ID);
        Lager Create(Lager newItem);
        Lager Delete(int ID);
        Lager Modify(Lager modifiedItem);
    }
}
