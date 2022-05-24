using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeumLibrary.Model
{
    public class Bruger
    {

        public int _id;
        public string _forNavn;
        public string _efterNavn;
        public int _telefonNr;
        public string _eMail;
        public string _brugerNavn;
        public string _adgangskode;
        public string _role;

        public Bruger() : this (0, "DummyFornavn", "DummyEfternavn", 24242424, "DummyEmail", "DummyBrugernavn", "DummyAdgandskode", "DummyRole")
        {

        }

        public Bruger(int id, string forNavn, string efterNavn, int telefonNr, string eMail, string brugerNavn,
            string adgangskode, string role)
        {
            _id = id;
            _forNavn = forNavn;
            _efterNavn = efterNavn;
            _telefonNr = telefonNr;
            _eMail = eMail;
            _brugerNavn = brugerNavn;
            _adgangskode = adgangskode;
            _role = role;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string ForNavn
        {
            get => _forNavn;
            set => _forNavn = value;
        }

        public string EfterNavn
        {
            get => _efterNavn;
            set => _efterNavn = value;
        }

        public int TelefonNr
        {
            get => _telefonNr;
            set => _telefonNr = value;
        }

        public string EMail
        {
            get => _eMail;
            set => _eMail = value;
        }

        public string BrugerNavn
        {
            get => _brugerNavn;
            set => _brugerNavn = value;
        }

        public string Adgangskode
        {
            get => _adgangskode;
            set => _adgangskode = value;
        }

        public string Role
        {
            get => _role;
            set => _role = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ForNavn)}: {ForNavn}, {nameof(EfterNavn)}: {EfterNavn}, {nameof(TelefonNr)}: {TelefonNr}, {nameof(EMail)}: {EMail}, {nameof(BrugerNavn)}: {BrugerNavn}, {nameof(Adgangskode)}: {Adgangskode}, {nameof(Role)}: {Role}";
        }
    }
}
