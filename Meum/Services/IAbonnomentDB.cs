using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeumLibrary.Model;

namespace Meum.Services
{
    public interface IAbonnomentDB
    {
        List<Abonnoment> GetAll();
        Abonnoment GetById(int id);
        Abonnoment Create(Abonnoment newItem);
        Abonnoment Delete(int id);
        Abonnoment Modify(Abonnoment modifiedItem);
    }
}
