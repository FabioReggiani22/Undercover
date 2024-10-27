namespace ClassiUndercover
{
    public enum Ruolo
    {
        Civile,
        Undercover,
        MrWhite
    }
    public class Giocatore
    {
        private string _nome;
        private Ruolo _ruolo;
        private int _punteggio;

        public Giocatore(string nome)
        {
            Nome = nome;
            Punteggio = 0;
        }
        public string Nome
        {
            get=>_nome;
            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentException("Il nome non è accettabile");
                _nome = value;
            }
        }
        public Ruolo RuoloGiocatore
        {
            get => _ruolo;
            set
            {
                if (!Enum.IsDefined<Ruolo>(value)) throw new ArgumentException("Il ruolo non è accettabile");
                _ruolo = value;
            }
        }
        public int Punteggio
        {
            get => _punteggio;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Il punteggio non può essere minore di zero");
                _punteggio = 0;
            }
        }
        public void IncrementaPunteggio()
        {
            Punteggio += 1;
        }        
    }
}
