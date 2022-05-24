using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeumLibrary.Model;

namespace Meum.Services
{
    public interface IProduktDB
    {
        List<Produkt> GetAll();
        Produkt GetByID(int id);
        Produkt Create(Produkt newItem);
        Produkt Delete(int id);
        Produkt Modify(Produkt modifiedItem);


    }
}
