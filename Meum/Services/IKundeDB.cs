using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeumLibrary.Model;

namespace Meum.Services
{
    public interface IKundeDB
    {
        List<Kunde> GetAll();
        Kunde GetById(int id);
        Kunde Create(Kunde newItem);
        Kunde Delete(int id);
        Kunde Modify(Kunde modifiedItem);

    }
}
