namespace Listeye_Sarki_Ekleme_Cikarma
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            string[] playList = new string[0];

            Console.WriteLine("Eklemek istediginiz sarkiyi girin , sarki eklemeden cikmak icin tamam yazin.");
            while (true)
            {
                string sarkiAdi = Console.ReadLine();
                if (sarkiAdi != "tamam")
                {
                    Array.Resize(ref playList, playList.Length + 1);
                    playList[playList.Length - 1] = sarkiAdi;
                }
                else break;
            }

            Console.WriteLine("Listeden cikarmak istediginiz sarki varsa sarkinin adini yazin yoksa tamam yazin ");
            while (true)
            {
                string songDelete = Console.ReadLine();
                if (songDelete == "tamam")
                    break;
                else if (!playList.Contains(songDelete))
                {
                    Console.WriteLine("Listede Boyle bir sarki bulunamadi");
                    Console.WriteLine("Playlistiniz");
                    foreach (string item in playList)
                    {
                        if (item != "")
                            Console.Write(" - " + item);
                    }
                    Console.WriteLine();
                }
                else
                {
                    playList = playList.Except(new string[] { songDelete }).ToArray();
                    Console.WriteLine("Playlistiniz");
                    foreach (string item in playList)
                    {
                        if (item != "")
                            Console.Write(" - " + item);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("---------Playlistiniz---------- ");

            foreach (string item in playList)
            {
                if (item != "")
                    Console.WriteLine(item);
            }
        }
    }
}