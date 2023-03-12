namespace Asal_Carpanlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sayi;
            int[] tamBolenler = new int[50];
            int sayac = 0;
            while (true)
            {
                Console.WriteLine("Sayi Giriniz.");
                bool kontrol = int.TryParse(Console.ReadLine(), out sayi);
                if (kontrol && sayi > 0)
                    break;
                else Console.WriteLine("Hatali Giris. 0 dan buyuk sayi girin");
            }

            for (int i = 2; i <= sayi; i++)
            {
                if (sayi % i == 0)
                {
                    tamBolenler[sayac] = i;
                    sayac++;
                }
            }

            bool kontrol2 = true;
            Console.WriteLine("-------SAYININ ASAL CARPANLARI-------");

            for (int i = 0; i < sayac - 1; i++)
            {
                for (int j = 2; j < tamBolenler[i] - 1; j++)
                {
                    if (tamBolenler[i] % j == 0)
                        kontrol2 = false;
                }
                if (kontrol2)
                {
                    Console.WriteLine(tamBolenler[i]);
                }
                kontrol2 = true;
            }

        }
    }
}