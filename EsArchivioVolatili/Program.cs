using System;
using System.Collections.Generic;
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


                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 3:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 5:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 6:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 7:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 8:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 9:
                        Console.WriteLine("E' stato scelto di inserire un nuovo pennuto");

                        Console.WriteLine("\n");
                        break;
                    case 10:
                        Console.WriteLine("E' stato scelto di terminare il programma");
                        break;
                }
            } while (scelta != 10);
        }
    }
}
