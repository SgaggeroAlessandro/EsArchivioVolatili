using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<CPennuto> esemplari = new List<CPennuto>();
            int scelta;
            do
            {
                do
                {
                    Console.WriteLine("Scrivi il numero corrispondente alla funzione che si vuole svolgere, tra quelle proposte:");
                    Console.WriteLine(
                        "\t1. Inserire un nuovo esemplare\n" +
                        "\t2. Visualizzare l'elenco degli esemplari\n" +
                        "\t3. Eliminare un esemplare\n" +
                        "\t4. Registrare gli avvistamenti di un esemplare\n" +
                        "\t5. Consultare gli avvistamenti di un esemplare\n" +
                        "\t6. Cercare gli esemplari di una determinata specie\n" +
                        "\t7. Visualizzare solo i migratori\n" +
                        "\t8. Mostrare il numero di esemplari per categoria\n" +
                        "\t9. Mostrare il numero totale di avvistamenti\n" +
                        "\t10. Termina il programma");
                    Console.Write("Numero: ");


                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 10);
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");
                        AggiungiPennuto(esemplari);

                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.WriteLine("E' stato scelto di visualizzare l'elenco degli esemplari");
                        VisualizzaElenco(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        Console.WriteLine("E' stato scelto di eliminare un esemplare");
                        EliminaEsemplare(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.WriteLine("E' stato scelto di registrare gli avvistamenti di un esemplare");
                        RegistraAvvistamento(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 5:
                        Console.WriteLine("E' stato scelto di consultare gli avvistamenti di un esemplare");
                        ConsultaAvvistamenti(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 6:
                        Console.WriteLine("E' stato scelto di cercare gli esemplari di una determinata specie");
                        CercaPerSpecie(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 7:
                        Console.WriteLine("E' stato scelto di visualizzare solo i pennuti migratori");
                        CercaMigratori(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 8:
                        Console.WriteLine("E' stato scelto di mostare il numero di esemplari per categoria");
                        EsemplariperCategoria(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 9:
                        Console.WriteLine("E' stato scelto di mostrare il numero totale di avvistamenti");
                        NumerodiAvvistamenti(esemplari);
                        Console.WriteLine("\n");
                        break;
                    case 10:
                        Console.WriteLine("E' stato scelto di terminare il programma");
                        break;
                }
            } while (scelta != 10);
        }

        public static void AggiungiPennuto(List<CPennuto> esemplari)
        {

            int codice;
            bool valido;
            do
            {
                Console.WriteLine("Inserisci il codice univoco del pennuto");
                valido = int.TryParse(Console.ReadLine(), out codice) && codice >= 1;

                if (valido == false)
                {
                    Console.WriteLine("Devi inserire un numero intero che parta da 1");
                }
                else
                {
                    foreach (CPennuto p in esemplari)
                    {
                        if (p.CodiceUnivoco == codice)
                        {
                            Console.WriteLine("Il codice è già presente, inserisci un nuovo codice");
                            valido = false;
                        }
                    }
                }
            } while (!valido);

            string specie;
            do
            {
                Console.WriteLine("Inserisci la specie del pennuto");
                specie = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(specie));

            string habitat;
            do
            {
                Console.WriteLine("Inserisci l'habitat dove vive il pennuto");
                habitat = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(habitat));

            string scelta;

            do
            {
                Console.WriteLine("Il pennuto è un migratore (sì/no)?");
                scelta = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(scelta) || (scelta.ToLower() != "si" && scelta.ToLower() != "sì" && scelta.ToLower() != "no"));

            bool migrato = scelta.ToLower() == "sì" || scelta.ToLower() == "si" ? true : false;

            float apertura;
            do
            {
                Console.WriteLine("Inserisci l'apertura alare del pennuto");
            } while (!float.TryParse(Console.ReadLine(), out apertura) || apertura <= 0);

            int categoria;
            do
            {
                Console.WriteLine("Scrivi il numero corrispondente ad una delle seguenti categorie: 1. Rapace 2. Canterino 3. Acquatico");
            } while (!int.TryParse(Console.ReadLine(), out categoria) || categoria < 1 || categoria > 3);

            CPennuto pennuto;

            switch (categoria)
            {
                case 1:
                    string dieta;
                    do
                    {
                        Console.WriteLine("Inserisci la dieta del rapace");
                        dieta = Console.ReadLine();
                    } while (string.IsNullOrEmpty(dieta));
                    pennuto = new CRapace(codice, specie, habitat, migrato, apertura, dieta);
                    break;
                case 2:
                    string canto;
                    do
                    {
                        Console.WriteLine("Inserisci il canto caratteristico del pennuto");
                        canto = Console.ReadLine();
                    } while (string.IsNullOrEmpty(canto));
                    pennuto = new CCanterino(codice, specie, habitat, migrato, apertura, canto);
                    break;
                default:
                    int acqua;
                    do
                    {
                        Console.WriteLine("Inserisci il numero relativo al tipo di acqua del pennuto acquatico: 1. Dolce 2. Salata");
                    } while (!int.TryParse(Console.ReadLine(), out acqua) || acqua < 1 || acqua > 2);

                    string tipo = acqua == 1 ? "Dolce" : "Salata";

                    pennuto = new CAcquatico(codice, specie, habitat, migrato, apertura, tipo);
                    break;
            }
            Console.WriteLine(pennuto.toString());
            esemplari.Add(pennuto);
        }

        public static void VisualizzaElenco(List<CPennuto> esemplari)
        {
            if (esemplari.Count == 0)
            {
                Console.WriteLine("Nessun esemplare salvato");
                return;
            }

            foreach (CPennuto p in esemplari)
            {
                Console.WriteLine(p.toString());
            }
        }

        public static void EliminaEsemplare(List<CPennuto> esemplari)
        {
            if (esemplari.Count == 0)
            {
                Console.WriteLine("Nessun esemplare salvato");
                return;
            }
            int codice;
            do
            {
                Console.WriteLine("Inserisci il codice del pennuto da eliminare");
            } while (!int.TryParse(Console.ReadLine(), out codice));
            CPennuto pennutoEliminato = TrovaPennuto(esemplari, codice);

            if (pennutoEliminato == null)
            {
                Console.WriteLine("Nessun esemplare trovato con questo codice");
            }
            else
            {
                esemplari.Remove(pennutoEliminato);
                Console.WriteLine("Pennuto eliminato");
            }
        }

        public static void RegistraAvvistamento(List<CPennuto> esemplari)
        {
            if (esemplari.Count == 0)
            {
                Console.WriteLine("Nessun esemplare salvato");
                return;
            }

            int codice;
            do
            {
                Console.WriteLine("Inserisci il codice del pennuto a cui vuoi aggiungere un avvistamento");
            } while (!int.TryParse(Console.ReadLine(), out codice));
            CPennuto pennuto = TrovaPennuto(esemplari, codice);

            if (pennuto == null)
            {
                Console.WriteLine("Nessun pennuto trovato con questo codice univoco");
                return;
            }


            DateTime data;
            do
            {
                Console.WriteLine("Inserisci la data dell'avvistamento");
            } while (!DateTime.TryParse(Console.ReadLine(), out data));
            string luogo;
            do
            {
                Console.WriteLine("Inserisci il luogo in cui è avvenuto l'avvistamento");
                luogo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(luogo));

            string note;
            do
            {
                Console.WriteLine("Inserisci delle note sull'avvistamento");
                note = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(note));
            try
            {
                pennuto.AggiungiAvvistamento(data, luogo, note);
                Console.WriteLine("Avvistamento salvato con successo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void ConsultaAvvistamenti(List<CPennuto> esemplari)
        {
            if (esemplari.Count == 0)
            {
                Console.WriteLine("Nessun esemplare presente, quindi non ci sono avvistamenti da visualizzare");
                return;
            }
            int codice;
            do
            {
                Console.WriteLine("Inserisci il codice dell'esemplare di cui si vuole consultare gli avvistamenti");
            } while (!int.TryParse(Console.ReadLine(), out codice));
            CPennuto pennuto = TrovaPennuto(esemplari, codice);

            if (pennuto == null)
            {
                Console.WriteLine("Nessun pennuto trovato con questo codice");
                return;
            }

            if (pennuto.Avvistamenti.Count == 0)
            {
                Console.WriteLine("Nessun avvistamento presente per questo pennuto");
            }
            else
            {
                Console.WriteLine(pennuto.MostraAvvistamenti());
            }

        }

        public static void CercaPerSpecie(List<CPennuto> esemplari)
        {
            if (esemplari.Count == 0)
            {
                Console.WriteLine("Nessun pennuto presente");
                return;
            }
            string specie;
            do
            {
                Console.WriteLine("Inserisci la specie da cercare");
                specie = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(specie));
            bool almenouno = false;
            foreach (CPennuto p in esemplari)
            {
                if (p.Specie.ToLower() == specie.ToLower())
                {
                    almenouno = true;
                    Console.WriteLine(p.toString());
                }
            }

            if (almenouno == false)
            {
                Console.WriteLine("Nessun esemplare di questa specie trovato");
            }
        }

        public static void CercaMigratori(List<CPennuto> esemplari)
        {
            if (esemplari.Count == 0)
            {
                Console.WriteLine("Non ci sono esemplari salvati");
                return;
            }
            bool almenouno = false;
            foreach (CPennuto p in esemplari)
            {
                if (p.Migratore == true)
                {
                    Console.WriteLine(p.toString());
                    almenouno = true;
                }
            }
            if (almenouno == false)
            {
                Console.WriteLine("Nessun migratore trovato");
            }
        }

        public static void EsemplariperCategoria(List<CPennuto> esemplari)
        {
            if (esemplari.Count == 0)
            {
                Console.WriteLine("Nessun esemplare presente");
                return;
            }
            int nRapace = 0;
            int nCanterino = 0;
            int nAcquatico = 0;
            foreach (CPennuto p in esemplari)
            {
                if (p is CRapace)
                {
                    nRapace++;
                }
                else if (p is CCanterino)
                {
                    nCanterino++;
                }
                else
                {
                    nAcquatico++;
                }
            }

            Console.WriteLine($"Numero di rapaci: {nRapace}\nNumero di pennuti canterini: {nCanterino}\nNumero di pennuti acquatici:{nAcquatico}");
        }

        public static void NumerodiAvvistamenti(List<CPennuto> esemplari)
        {
            int nAvvistamenti = 0;
            foreach (CPennuto p in esemplari)
            {
                nAvvistamenti += p.Avvistamenti.Count;
            }
            Console.WriteLine($"Numero di avvistamenti: {nAvvistamenti}");
        }

        public static CPennuto TrovaPennuto(List<CPennuto> esemplari, int codice)
        {
            foreach (CPennuto p in esemplari)
            {
                if (p.CodiceUnivoco == codice)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
