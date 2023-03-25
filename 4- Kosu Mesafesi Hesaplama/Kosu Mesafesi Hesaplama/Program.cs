namespace Kosu_Mesafesi_Hesaplama
{
    internal class Program
    {
       


        #region (Ekstra) kullanici bitirine kadar dakika ve mesafe bilgisi alip toplam mesafe hesaplama.
        // Kullanicidan ortalama adim uzunlugunu alan metod.  
        static int BirAdimKacSantim()
        {
            int adimBoyu;
            while (true)
            {
                Console.Write("Adim boyunuzu santimetre cinsinden giriniz: ");
                bool kontrol = int.TryParse(Console.ReadLine(), out adimBoyu);
                if (kontrol && adimBoyu > 10 && adimBoyu < 200) break;
                else Console.WriteLine("Gecersiz bilgi girisi yapildi .Lutfen adim boyunuzu dogru girin. ");
            }
            return adimBoyu;
        }

        // Kullanici bitirene kadar istedigi kadar dakika icin ortalama adim miktarini alan metod.
        static void KullaniciDakikaAdimSayisiAl(ref int[] dakikalar, ref int[] adimlar)
        {

            int dakika = 0;
            int adim = 0;
            int saat = 0;
            Console.WriteLine("Farkli dakikalar icin farkli adim sayilari girebilirsiniz adim sayisi girisini bitirmek icin bitir yazin.");
            for (int i = 0; i < dakikalar.Length; i++)
            {
                while (true)
                {
                    Console.Write("Saat: ");
                    bool kontrolSaat = int.TryParse(Console.ReadLine(), out saat);
                    Console.Write("Dakika: ");
                    bool kontroldakika = int.TryParse(Console.ReadLine(), out dakika);
                    Console.Write("Dakika Basi Adim Sayisi: ");
                    bool kontrolAdim = int.TryParse(Console.ReadLine(), out adim);
                    if (kontroldakika && kontrolSaat && kontrolAdim && adim >= 0 && dakika >= 0 && dakika < 60)
                    {
                        dakikalar[i] = (saat * 60) + dakika;
                        adimlar[i] = adim;
                        break;
                    }
                    else Console.WriteLine("Hatali giris . Lutfen adim sayisini ve dakikayi pozitif tam sayi girin.");
                }
                Console.WriteLine("Dakika-adim girisini bitirmek icin bitir yazin devam etmek icin herhangi bir tus giris yapin.");
                string devam = Console.ReadLine().ToLower();
                if (devam == "bitir") break;

                Array.Resize(ref dakikalar, dakikalar.Length + 1);
                Array.Resize(ref adimlar, adimlar.Length + 1);

            }
        }

        // Toplam kosu mesafesini hesaplayan metod
        static int ToplamKosuMesafesiniBul(int[] dakikalar, int[] adimlar, int adimBoyu)
        {
            int toplamKosumesafesi = 0;
            for (int i = 0; i < dakikalar.Length; i++)
            {
                int mesafe = (dakikalar[i] * adimlar[i] * adimBoyu) / 100;
                toplamKosumesafesi += mesafe;
            }
            return toplamKosumesafesi;
        }

        // Programin tekrar calistirilip calistirilmayacagini soran metod.
        static bool ProgramTekrarCalistirilsinMi2()
        {
            Console.WriteLine("Tekrar hesaplama yapmak ister misiniz? Istemiyorsaniz bitir yazin.");
            string tekrarCalistir = Console.ReadLine().ToLower();
            if (tekrarCalistir == "bitir")
                return false;
            return true;
        }
        #endregion



        static void Main(string[] args)
        {
            
            // Kullanicinin dakika basi adim sayisinin degistigi kabul edilerek yapilan program .
            bool programiKapatma = true;
            int[] adimlar = new int[1];
            int[] dakikalar = new int[1];
            Console.WriteLine("Bu program girdiginiz kosu bilgileriyle toplam kosu mesafenizi hesaplar.");

            while (programiKapatma)
            {
                int adimBoyu = BirAdimKacSantim();
                KullaniciDakikaAdimSayisiAl(ref dakikalar, ref adimlar);
                int toplamMesafe = ToplamKosuMesafesiniBul(dakikalar, adimlar, adimBoyu);
                int toplamSaat = dakikalar.Sum() / 60;
                int toplamDakika = dakikalar.Sum() % 60;
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"Toplam kosu sureniz : {toplamSaat} saat {toplamDakika} dakikadir.");
                Console.WriteLine("Toplam kosu mesafeniz : " + toplamMesafe + " metredir.");
                Console.WriteLine("----------------------------------------------------------");
                programiKapatma = ProgramTekrarCalistirilsinMi2();
            }


        }
    }

}