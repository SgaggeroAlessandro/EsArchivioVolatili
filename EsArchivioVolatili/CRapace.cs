using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CRapace : CPennuto
    {
        private string dieta;

        protected string Dieta
        {
            get => dieta;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci una dieta del rapace valida");
                dieta = value;
            }
        }

        public CRapace(int CodiceUnivoco, string Specie, string Habitat, bool Migratore, float AperturaAlare, string Dieta) : base(CodiceUnivoco, Specie, Habitat, Migratore, AperturaAlare)
        {
            this.Dieta = Dieta;
        }

        public override string toString()
        {
            return base.toString() + $" - Dieta del rapace: {Dieta}";
        }
    }
}
