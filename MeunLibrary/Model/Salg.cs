using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeumLibrary.Model
{
    public class Salg
    {
        public int _id;
        public int _vareNummer;
        public int _antal;
        public string _dateTime;
        public string _shipped;

        public Salg()
        {
        }

        public Salg(int id, int vareNummer, int antal, string dateTime, string shipped)
        {
            _id = id;
            _vareNummer = vareNummer;
            _antal = antal;
            _dateTime = dateTime;
            _shipped = shipped;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int VareNummer
        {
            get => _vareNummer;
            set => _vareNummer = value;
        }

        public int Antal
        {
            get => _antal;
            set => _antal = value;
        }

        public string DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }

        public string Shipped
        {
            get => _shipped;
            set => _shipped = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(VareNummer)}: {VareNummer}, {nameof(Antal)}: {Antal}, {nameof(DateTime)}: {DateTime}, {nameof(Shipped)}: {Shipped}";
        }
    }
}
