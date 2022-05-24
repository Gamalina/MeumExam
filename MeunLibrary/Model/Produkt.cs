using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MeumLibrary.Model
{
    public class Produkt
    {
        public int _id;
        public string _produktNavn;
        public string _beskrivelse;
        public int _vareNummer;
        public double _pris;
        public string _image;

        public Produkt()
        {
        }

        public Produkt(int id, string produktNavn, string beskrivelse, int vareNummer, double pris, string image)
        {
            _id = id;
            _produktNavn = produktNavn;
            _beskrivelse = beskrivelse;
            _vareNummer = vareNummer;
            _pris = pris;
            _image = image;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string ProduktNavn
        {
            get => _produktNavn;
            set => _produktNavn = value;
        }

        public string Beskrivelse
        {
            get => _beskrivelse;
            set => _beskrivelse = value;
        }

        public int VareNummer
        {
            get => _vareNummer;
            set => _vareNummer = value;
        }

        public double Pris
        {
            get => _pris;
            set => _pris = value;
        }

        public string Image
        {
            get => _image;
            set => _image = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ProduktNavn)}: {ProduktNavn}, {nameof(Beskrivelse)}: {Beskrivelse}, {nameof(VareNummer)}: {VareNummer}, {nameof(Pris)}: {Pris}, {nameof(Image)}: {Image}";
        }
    }
}
