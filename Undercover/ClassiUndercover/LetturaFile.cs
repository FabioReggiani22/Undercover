using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassiUndercover
{
    public class LetturaFile
    {
        public List<string> LetturaParole(string percorso)
        {
            List<string> parole= new List<string>();
            using (StreamReader sr=new StreamReader(percorso))
            {
                do
                {
                    parole.Add(sr.ReadLine()!);
                } while (!sr.EndOfStream);
            }
            return parole;
        }
        public List<Giocatore> LetturaGiocatori(string percorso)
        {
            List<Giocatore> giocatori= new List<Giocatore>();
            using (StreamReader sr = new StreamReader(percorso))
            {
                do
                {
                    string line= sr.ReadLine()!;
                    giocatori.Add(ConvertiStringaInGiocatore(line));
                } while (!sr.EndOfStream);
            }
            return giocatori;

        }
        private Giocatore ConvertiStringaInGiocatore(string giocatoreS)
        {
            string[] split = giocatoreS.Split(",");
            return new Giocatore(split[0], Convert.ToInt32(split[1]));
        }
    }
}
