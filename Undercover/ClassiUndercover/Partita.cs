using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassiUndercover
{
    public enum StatoPartita
    {
        VittoriaC,
        VittoriaU,
        VittoriaM,
        InCorso
    }
    public class Partita
    {
        private List<Giocatore> _giocatori;
        private string _parolaCiv;
        private string? _parolaUnder;
        private int _nGiocatori;
        private int[]? _posMrW;
        private int[]? _posUnd;
        private StatoPartita _statoPartita;

        public Partita(List<Giocatore> giocatori, string parolaCiv, string? parolaUnder, int nGiocatori,int? nWhite,int? nUnder)
        {
            if (String.IsNullOrEmpty(parolaCiv)) throw new ArgumentException("La parola dei civili non può essere vuota o nulla");
            if (parolaUnder != null && (parolaUnder == "" || parolaUnder == " ")) throw new ArgumentException("La parola degli undercover non può essere nulla");
            if (nWhite < 0 || nUnder < 0) throw new ArgumentException("Il numero non è accettabile");
            if (nWhite == null && nUnder == null) throw new ArgumentNullException("Entrambi i numeri non possono essere nulli");
            if ((nWhite == 0 && nUnder == null) || (nWhite == null && nUnder == 0)) throw new ArgumentException("I numeri non sono accettabili");
            _giocatori = [.. giocatori];
            _nGiocatori = nGiocatori;
            _parolaCiv = parolaCiv;
            _parolaUnder = parolaUnder;
            _statoPartita = StatoPartita.InCorso;
            if (nWhite == null) _posMrW = null;
            else _posMrW = new int[(int)nWhite];

            if (nUnder== null) _posUnd= null;
            else _posUnd = new int[(int)nUnder];

            RiempiPosRuoli();


        }

        private void RiempiPosRuoli()
        {
            Random r = new Random();
            List<int> numeriUsciti = new List<int>();
            int numeroUscito;
            if (_posMrW != null)
            {
                for(int i = 0; i < _posMrW.Length; i++)
                {
                    do
                    {
                        numeroUscito = r.Next(0, _nGiocatori);
                        if (!numeriUsciti.Contains(numeroUscito))
                        {
                            _posMrW [i] = numeroUscito;
                            numeriUsciti.Add(numeroUscito);
                            break;
                        }
                    } while (true);
                }
            }
            if (_posUnd != null)
            {
                for (int i = 0; i < _posUnd.Length; i++)
                {
                    do
                    {
                        numeroUscito = r.Next(0, _nGiocatori);
                        if (!numeriUsciti.Contains(numeroUscito))
                        {
                            _posUnd[i] = numeroUscito;
                            numeriUsciti.Add(numeroUscito);
                            break;
                        }
                    } while (true);
                }
            }
        }

        public List<Giocatore> Giocatori
        {
            get => _giocatori;
        }
        public void RimuoviGiocatoreCivile(Giocatore giocatore)
        {
            if (giocatore == null) throw new ArgumentNullException("Il giocatore non può essere nullo");
            Giocatori.Remove(giocatore);
        }
        public bool TentativoMrWhite(string parolaTentativo,Giocatore white)
        {
            if (white == null || white.RuoloGiocatore != Ruolo.MrWhite) throw new ArgumentException("Il giocatore non sono accettabili"); 
            if (String.IsNullOrEmpty(parolaTentativo)) throw new ArgumentNullException("Il tentativo non è accettabile");
            bool vittoria = false;
            if (parolaTentativo == _parolaCiv)
            {
                vittoria = true;
                AssegnaPunteggioVincitori(Ruolo.MrWhite);
            }
            else
            {
                _giocatori.Remove(white);
            }

            return vittoria;
        }
        public void VerificaVittoria()
        {
            int civ = 0;
            int und = 0;
            int white = 0;

            foreach(Giocatore giocatore in _giocatori)
            {
                if (giocatore.RuoloGiocatore == Ruolo.Civile) civ += 1;
                else if(giocatore.RuoloGiocatore == Ruolo.Undercover) und += 1;
                else if(giocatore.RuoloGiocatore== Ruolo.MrWhite) white += 1;
            }
            //vittoria MrWhite
            if((civ+und)<white)
            {
                _statoPartita = StatoPartita.VittoriaM;
                AssegnaPunteggioVincitori(Ruolo.Undercover);
            }

        }

        private void AssegnaPunteggioVincitori(Ruolo ruolo)
        {
            foreach(Giocatore giocatore in _giocatori)
            {
                if(giocatore.RuoloGiocatore==ruolo) giocatore.IncrementaPunteggio();
            }
        }
    }
}
