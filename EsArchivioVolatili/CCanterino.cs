using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CCanterino : CPennuto
    {
        private string cantocanterino;

        protected string CantoCanterino
        {
            get => cantocanterino;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Inserisci il canto del pennuto");
                cantocanterino = value;
            }
        }

        public CCanterino(int CodiceUnivoco, string Specie, string Habitat, bool Migratore, float AperturaAlare, string CantoCanterino) : base(CodiceUnivoco, Specie, Habitat, Migratore, AperturaAlare)
        {
            this.CantoCanterino = CantoCanterino;
        }

        public override string toString()
        {
            return base.toString() + $" - Canto del pennuto: {CantoCanterino}";
        }
    }
}
