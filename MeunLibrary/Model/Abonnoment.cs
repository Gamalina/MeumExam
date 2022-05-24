using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeumLibrary.Model
{
    public class Abonnoment
    {
        public int _id;
        public int _abonnomentNr;
        public string _abonnomentNavn;
        public int _pris;
        public int _løbetid;
        public string _beskrivelse;

        public Abonnoment()
        {
        }

        public Abonnoment(int id, int abonnomentNr, string abonnomentNavn, int pris, int løbetid, string beskrivelse)
        {
            _id = id;
            _abonnomentNr = abonnomentNr;
            _abonnomentNavn = abonnomentNavn;
            _pris = pris;
            _løbetid = løbetid;
            _beskrivelse = beskrivelse;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int AbonnomentNr
        {
            get => _abonnomentNr;
            set => _abonnomentNr = value;
        }

        public string AbonnomentNavn
        {
            get => _abonnomentNavn;
            set => _abonnomentNavn = value;
        }

        public int Pris
        {
            get => _pris;
            set => _pris = value;
        }

        public int Løbetid
        {
            get => _løbetid;
            set => _løbetid = value;
        }

        public string Beskrivelse
        {
            get => _beskrivelse;
            set => _beskrivelse = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(AbonnomentNr)}: {AbonnomentNr}, {nameof(AbonnomentNavn)}: {AbonnomentNavn}, {nameof(Pris)}: {Pris}, {nameof(Løbetid)}: {Løbetid}, {nameof(Beskrivelse)}: {Beskrivelse}";
        }
    }
}
