using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CAvvistamento
    {
        private DateTime data;
        private string luogo;
        private string note;

        protected DateTime Data
        {
            get => data;
            set
            {
                if (value > DateTime.Now.Date)
                    throw new ArgumentException("La data di avvistamento non è ancora passata. Inserisci una data valida");
                data = value;
            }
        }

        protected string Luogo
        {
            get => luogo;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci un luogo di avvistamento valido");
                luogo = value;
            }
        }

        protected string Note
        {
            get => note;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci delle note sull'avvistamento valide");
                note = value;
            }
        }

        public CAvvistamento(DateTime Data, string Luogo, string Note)
        {
            this.Data = Data;
            this.Luogo = Luogo;
            this.Note = Note;
        }

        public string InfoAvvistamento()
        {
            return $"Data dell'avvistamento: {Data} - Luogo: {Luogo} - Note aggiuntive: {Note}";
        }

    }
}
