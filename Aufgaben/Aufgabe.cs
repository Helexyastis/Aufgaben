using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgaben
{
    class Aufgabe
    {
        enum ZeitStatus { red,green,yellow};
        List<Aufgabe> subAufgaben;
        string kontakt;
        string status;
        TimeSpan zeitAufwand;
        DateTime annahme;
        DateTime abgabe;
        TimeSpan zeit;
        string aufnr;
        ZeitStatus zeitStatus;
        string name;

        public Aufgabe(string name)
        {
            this.name = name;
        }
    }
}
