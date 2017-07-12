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
        Aufgabe parent;
        string kontakt;
        string status;
        TimeSpan zeitAufwand;
        TimeSpan timeLeft;
        DateTime annahme;
        DateTime abgabe;
        TimeSpan zeit;
        string aufnr;
        ZeitStatus zeitStatus;
        string name;
        int id;
        public Aufgabe Partent { get { return parent; } set { parent = value; } }
        public string Kontakt { get { return kontakt; } set { kontakt = value; } }
        public string Status { get { return status; } set { status = value; } }
        public TimeSpan ZeitAufwand {get { return zeitAufwand; } set { zeitAufwand = value; } } 
        public TimeSpan TimeLeft { get { return abgabe.Subtract(DateTime.Now); }}
        public Aufgabe(int id,string name)
        {
            this.name = name;
            this.id = id;
        }

        public Aufgabe(string name,Aufgabe parent,string kontakt,string status,DateTime annahme,DateTime abgabe,string aufnr)
        {
            subAufgaben = new List<Aufgabe>();
            this.name = name;
            this.parent = parent;
            this.kontakt = kontakt;
            this.status = status;
            this.annahme = annahme;
            this.abgabe = abgabe;
            this.aufnr = aufnr;
            timeLeft = abgabe.Subtract(annahme);
            zeitStatus = ZeitStatus.green;
            if(parent != null)
            {
                parent.subAufgaben.Add(this);
            }
        }
        private void SetZeitStatus()
        {

            DateTime heute = DateTime.Now;

            TimeSpan timeLeftNow = abgabe.Subtract(heute);
            TimeSpan timeDiff = timeLeft.Subtract(timeLeftNow);
            int percent = (timeDiff.Days * 100) / timeLeft.Days;
            
            if(percent>0 && percent <= 25)
            {
                zeitStatus = ZeitStatus.red;
            }
            else
            {
                if(percent>25 &&percent<= 65)
                {
                    zeitStatus = ZeitStatus.yellow;
                }
                else
                {
                    zeitStatus = ZeitStatus.green;
                }
            }
            timeLeft = timeLeftNow;

        }



    }
}
