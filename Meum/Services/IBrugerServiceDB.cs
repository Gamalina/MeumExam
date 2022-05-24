using MeumLibrary.Model; // <--- Reference to Library Model.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meum.Services
{
    public interface IBrugerServiceDB
    {
        // Methods
        List<Bruger> GetAll();
        Bruger GetByBruger(string userName);
        Bruger Create(Bruger newUser);
        Bruger Delete(string userName);
        Bruger Modify(Bruger modifiedUser);

    }
}
