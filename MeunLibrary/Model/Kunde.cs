using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeumLibrary.Model
{
    public class Kunde
    {
        public int _id;
        public string _forNavn;
        public string _efterNavn;
        public int _telefonNr;
        public string _eMail;
        public string _addresse;
        public int _abonnomentNr;
        public string _nyhedsbrev;

        public Kunde()
        {
        }

        public Kunde(int id, string forNavn, string efterNavn, int telefonNr, string eMail, string addresse, int abonnomentNr, string nyhedsbrev)
        {
            _id = id;
            _forNavn = forNavn;
            _efterNavn = efterNavn;
            _telefonNr = telefonNr;
            _eMail = eMail;
            _addresse = addresse;
            _abonnomentNr = abonnomentNr;
            _nyhedsbrev = nyhedsbrev;
        }

        public string Nyhedsbrev
        {
            get => _nyhedsbrev;
            set => _nyhedsbrev = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string ForNavn
        {
            get => _forNavn;
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Fornavn skal mindst være 3 ord lang.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Fornavn skal mindst være 3 ord lang.");
                }

                if (value.Length > 20)
                {
                    throw new ArgumentException("Fornavn skal mindst være 20 ord lang.");
                }
                _forNavn = value;
            }
        
        }
        

        public string EfterNavn
        {
            get => _efterNavn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Efternavn skal mindst være 3 ord lang.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Efternavn skal mindst være 3 ord lang.");
                }

                if (value.Length > 20)
                {
                    throw new ArgumentException("Efternavn skal mindst være 20 ord lang.");
                }
                _efterNavn = value;
            }
        }

        public int TelefonNr
        {
            get => _telefonNr;
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentNullException("Telefon skal være 8 nummer lang.");
                }

                if (value.ToString().Length < 8)
                {
                    throw new ArgumentException("Telefon skal være 8 nummer lang.");
                }

                if (value.ToString().Length > 8)
                {
                    throw new ArgumentException("Telefon skal være 8 nummer lang.");
                }
                _telefonNr = value;
            }

        }

        public string EMail
        {
            get => _eMail;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Email skal mindst være 5 ord lang.");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Fornavn skal mindst være 3 ord lang.");
                }
                // Lav det så at der skal være et @ og . for at det er i orden.
                if (value.Length > 20)
                {
                    throw new ArgumentException("Fornavn skal mindst være 20 ord lang.");
                }
                _eMail = value;
            }
        }

        public string Addresse
        {
            get => _addresse;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Addresse skal mindst være 5 ord lang.");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Addresse skal mindst være 5 ord lang.");
                }
              
                if (value.Length > 35)
                {
                    throw new ArgumentException("Addresse skal mindre end være 35 ord lang.");
                }
                _addresse= value;
            }
        }

        public int AbonnomentNr
        {
            get => _abonnomentNr;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("AbonnomentNr skal være 0 eller positivt.");
                }
            }
        }

        public override string ToString()
        {
            return $"{nameof(Nyhedsbrev)}: {Nyhedsbrev}, {nameof(Id)}: {Id}, {nameof(ForNavn)}: {ForNavn}, {nameof(EfterNavn)}: {EfterNavn}, {nameof(TelefonNr)}: {TelefonNr}, {nameof(EMail)}: {EMail}, {nameof(Addresse)}: {Addresse}, {nameof(AbonnomentNr)}: {AbonnomentNr}";
        }
    }
}
