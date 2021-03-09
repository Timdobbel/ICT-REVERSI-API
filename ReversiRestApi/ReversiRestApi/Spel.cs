using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReversiRestApi
{
    public class Spel : ISpel
    {
        public int ID { get; set; }
        public string Omschrijving { get; set; }
        public string Token { get; set; }
        public string Speler1Token { get; set; }
        public string Speler2Token { get; set; }
        public Kleur[,] Bord { get; set; }
        public Kleur AandeBeurt { get; set; }

        public Spel()
        {
            InitialiseerBord();
        }

        public void InitialiseerBord()
        {
            Bord = new Kleur[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Bord[i, j] = Kleur.Geen;
                }
            }

            Bord[3, 3] = Kleur.Wit;
            Bord[4, 4] = Kleur.Wit;
            Bord[4, 3] = Kleur.Zwart;
            Bord[3, 4] = Kleur.Zwart;
        }

        public bool Pas()
        {
            bool result = false;


            return result;
        }

        public bool Afgelopen()
        {
            throw new NotImplementedException();
        }

        public Kleur OverwegendeKleur()
        {
            throw new NotImplementedException();
        }

        public bool ZetMogelijk(int rijZet, int kolomZet)
        {
            bool result = false;

            if (!(rijZet > 7 || kolomZet > 7) && !(rijZet < 0 || kolomZet < 0))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool DoeZet(int rijZet, int kolomZet)
        {
            Bord[rijZet, kolomZet] = KleurToggle(Bord[rijZet, kolomZet]);
            return true;
        }

        public Kleur KleurToggle(Kleur kleur)
        {
            Kleur result = Kleur.Geen;
            if (kleur == Kleur.Wit)
            {
                result = Kleur.Zwart;
            }
            else if (kleur == Kleur.Zwart)
            {
                result = Kleur.Wit;
            }
            return result;
        }
    }
}
