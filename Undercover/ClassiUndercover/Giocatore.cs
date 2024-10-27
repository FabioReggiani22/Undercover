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
        private string? _parolaAssegnata;

        public Giocatore(string nome)
        {
            Nome = nome;
            Punteggio = 0;
        }
        public string Nome
        {
            get=>_nome;
            private set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentException("Il nome non è accettabile");
                _nome = value;
            }
        }
        public Ruolo RuoloGiocatore
        {
            get => _ruolo;
            private set
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
                _punteggio = value;
            }
        }
        public string? ParolaAssegnata
        {
            get => _parolaAssegnata;
        }
        public void IncrementaPunteggio()
        {
            Punteggio += 1;
        }        
        public void AssegnaParolaERuolo(Ruolo ruolo, string? parola=null)
        {
            RuoloGiocatore = ruolo;
            _parolaAssegnata=parola;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Giocatore && obj != null)
            {
                if ((obj as Giocatore)!.Nome == Nome) return true;
                return false;
            }
            return false;
        }
    }
}
