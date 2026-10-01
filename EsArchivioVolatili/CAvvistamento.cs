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

        private DateTime Data
        {
            get => data;
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException("La data di avvistamento non è ancora passata. Inserisci una data valida");
                data = value;
            }
        }

        private string Luogo
        {
            get => luogo;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci un luogo di avvistamento valido");
                luogo = value;
            }
        }

        private string Note
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
            return $"Data dell'avvistamento: {Data : dd/MM/yyyy} - Luogo: {Luogo} - Note aggiuntive: {Note}\n";
        }

    }
}
