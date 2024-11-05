using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassiUndercover
{
    public class ScritturaFile
    {
        public void ScritturaGiocatore(Giocatore giocatore,string percorso)
        {
            using (StreamWriter sw=new StreamWriter(percorso, true))
            {
                sw.WriteLine(giocatore);
            }
        }
    }
}
