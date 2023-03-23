namespace Polindrom
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Girilen sayinin polindrom olup olmadigini kontrol eder.

            Console.WriteLine("Sayi Giriniz.");
            int sayi;
            bool sayiMi = int.TryParse(Console.ReadLine(), out sayi);
            int sayac1 = 0;
            int sayac2 = 0;
            int sayac3 = 0;
            int sayiTutucu = sayi;

            while (sayiTutucu > 0)
            {
                sayiTutucu /= 10;  // basamak sayisini bulur
                sayac3++;
            }

            int[] diziSayi = new int[sayac3];
            int[] diziSayiTersi = new int[sayac3];

            if (sayiMi)
            {
                for (int i = 0; i < diziSayi.Length; i++)
                {
                    diziSayi[i] = sayi % 10;   // sayinin her basamagini diziye atar
                    sayi /= 10;
                }

                for (int j = 0; j < diziSayiTersi.Length; j++)
                {
                    diziSayiTersi[j] = diziSayi[diziSayi.Length - (j + 1)];  // dizinin tersini alir .
                }

                for (sayac1 = 0; sayac1 < diziSayi.Length; sayac1++)  
                {
                    if (diziSayi[sayac1] == diziSayiTersi[sayac1])  // dizinin tersiyle kendisini karsilastirip polindrom kontrolu yapar.
                        sayac2++;
                }
                if (sayac2 == sayac1)
                    Console.WriteLine("Palindromdur.");
                else
                    Console.WriteLine("Palindrom degildir.");
            }
            else Console.WriteLine("Gecersiz Giris.");
        }
    }
}