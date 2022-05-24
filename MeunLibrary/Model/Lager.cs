using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeumLibrary.Model
{
    public class Lager
    {
        public int _id;
        public int _vareNummer;
        public string _navn;
        public string _beskrivelse;
        public int _antal;

        public Lager()
        {
        }

        public Lager(int id, int vareNummer, string navn, string beskrivelse, int antal)
        {
            _id = id;
            _vareNummer = vareNummer;
            _navn = navn;
            _beskrivelse = beskrivelse;
            _antal = antal;
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

        public string Navn
        {
            get => _navn;
            set => _navn = value;
        }

        public string Beskrivelse
        {
            get => _beskrivelse;
            set => _beskrivelse = value;
        }

        public int Antal
        {
            get => _antal;
            set => _antal = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(VareNummer)}: {VareNummer}, {nameof(Navn)}: {Navn}, {nameof(Beskrivelse)}: {Beskrivelse}, {nameof(Antal)}: {Antal}";
        }
    }

}
