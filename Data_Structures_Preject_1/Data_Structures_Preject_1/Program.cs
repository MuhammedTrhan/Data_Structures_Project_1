using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Preject_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string[] cities = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın",
                "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
                "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri",
                "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli",
                "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize",
                "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van",
                "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır",
                "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };
            int[][] distJagAr = new int[81][];
            string[][] neigJagAr = new string[81][];
            string DISTANCESPATH = "Distances.txt";
            string NEIGPATH = "Neighbors.txt";

            using (StreamReader reader = new StreamReader(DISTANCESPATH)) // Mesafe dosyasından veri çekme
            {
                string distLine;

                for (int i = 0; i < 81; i++) //Text dosyasında satırları gezme
                {
                    int[] tempArray = new int[i + 1];

                    distLine = reader.ReadLine();
                    string[] distParts = distLine.Split(new char[] { ' ' , '	' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < 81; j++) //Satırlardaki tüm elemanları gezip int'e çevirme
                    {
                        if (distParts[j] != "0")
                        {

                            if (int.TryParse(distParts[j], out int Number))
                            {
                                tempArray[j] = Number; //İnt'leri geçici arraya aktarma
                            }
                            else { }

                        }

                        else
                        {
                            tempArray[j] = 0;
                            break;
                        }
                    }

                    distJagAr[i] = tempArray; //İntleri geçici arraydan jagged arraya aktarma
                    
                }

                reader.Close();
            }

            using (StreamReader reader = new StreamReader(NEIGPATH)) //Komşuluk dosyasından veri çekme
            {
                string neigLine;

                for (int i = 0; i < 81; i++) //Text dosyasında satırları gezme
                {
                    int[] tempArray = new int[i + 1];

                    neigLine = reader.ReadLine();
                    neigJagAr[i] = neigLine.Split(new char[] { ' ', '	' }, StringSplitOptions.RemoveEmptyEntries);
                }

                reader.Close() ;
            }

                for (int i = 0; i < 10; i++)
            {
                int row = random.Next(0, 81);
                int column = random.Next(0, 81);

                if (row < column) // Sütun değerinin satırdan büyük olmasını önleme
                {
                    int temp = row;
                    row = column;
                    column = temp;
                }

                else
                {
                    
                }
                string city1 = cities[row];
                string city2 = cities[column];

                int distance = distJagAr[row][column];

                Console.WriteLine("The distance between " + (column + 1) + " " + city2 + " and " + (row + 1) + " " + city1 + " is " + distance);
            }

            for (int k = 0; k < 81; k++) //Mesafeleri yazdırma
            {
                for (int l = 0; l < distJagAr[k].Length; l++)
                {
                    Console.Write(distJagAr[k][l] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 81; i++) // komşulukları yazdırma
            {
                for (int j = 0; j < neigJagAr[i].Length; j++)
                {
                    Console.Write(neigJagAr[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
