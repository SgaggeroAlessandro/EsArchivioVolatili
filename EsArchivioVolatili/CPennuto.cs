using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CPennuto
    {
        private int codiceunivoco;
        private string specie;
        private string habitat;
        private bool migratore;
        private float aperturaAlare;

        public List<CAvvistamento> Avvistamenti;

        protected int CodiceUnivoco
        {
            get => codiceunivoco;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Il codice univoco può partire da 1, inserire un valore valido");
                codiceunivoco = value;
            }
        }


        protected string Specie
        {
            get => specie;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserire una specie valida");
                specie = value;
            }
        }

        protected string Habitat
        {
            get => habitat;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserire un habitat del volatile valido");
                habitat = value;
            }
        }

        protected bool Migratore
        {
            get => migratore;
            set
            {
                migratore = value;
            }
        }

        protected float AperturaAlare
        {
            get => aperturaAlare;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("L'apertura alare deve essere maggiore o uguale a 1");
                aperturaAlare = value;
            }
        }

        public CPennuto(int CodiceUnivoco, string Specie, string Habitat, bool Migratore, float AperturaAlare)
        {
            this.CodiceUnivoco = CodiceUnivoco;
            this.Specie = Specie;
            this.Habitat = Habitat;
            this.Migratore = Migratore;
            this.AperturaAlare = AperturaAlare;
            Avvistamenti = new List<CAvvistamento>();
        }

        public virtual string toString()
        {
            string migrato = "";
            if(Migratore == true)
            {
                migrato = "Sì";
            }
            else
            {
                migrato = "No";
            }
            return $"Codice del pennuto: {CodiceUnivoco}  - Specie: {Specie} - Habitat: {Habitat} - E' un migratore: {migrato} - Apertura alare (cm): {AperturaAlare}";
        }

        public string MostraAvvistamenti()
        {
            string testo = "";

            foreach (CAvvistamento a in Avvistamenti)
            {
                testo += a.InfoAvvistamento();
            }
            return testo;
        }


        public void AggiungiAvvistamento(DateTime Data, string Luogo, string Note)
        {
            CAvvistamento avvistamento = new CAvvistamento(Data, Luogo, Note);
            Avvistamenti.Add(avvistamento);
        }
    }
}
