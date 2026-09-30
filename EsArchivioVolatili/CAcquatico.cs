using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    
    public class CAcquatico : CPennuto
    {
        public enum TipoAcqua
        {
            Dolce,
            Salata
        }

        private string tipoacquatico;

        protected string TipoAcquatico
        {
            get => tipoacquatico;
            set
            {
                if (string.IsNullOrEmpty(value) || value != TipoAcqua.Dolce.ToString() || value != TipoAcqua.Salata.ToString())
                    throw new ArgumentException("Puoi scegliere solo tra acqua salata o acqua dolce");
                tipoacquatico = value;
            }
        }

        public CAcquatico(int CodiceUnivoco, string Specie, string Habitat, bool Migratore, float AperturaAlare, string TipoAcquatico) : base(CodiceUnivoco,Specie,Habitat, Migratore, AperturaAlare)
        {
            this.TipoAcquatico = TipoAcquatico;
        }

        public override string toString()
        {
            return base.toString() + $" - Tipo di pennuto: {TipoAcquatico}";
        }
    }
}
