using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassiUndercover
{
    public class Partita
    {
        private List<Giocatore> _giocatori;
        private string _parolaCiv;
        private string? _parolaUnder;
        private int _nGiocatori;
        private int[]? _posMrW;
        private int[]? _posUnd;
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
        public void RimuoviGiocatore(Giocatore giocatore)
        {
            if (giocatore == null) throw new ArgumentNullException("Il giocatore non può essere nullo");
            Giocatori.Remove(giocatore);
        }

    }
}
