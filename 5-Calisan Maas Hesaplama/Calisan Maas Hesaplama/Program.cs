namespace Calisan_Maas_Hesaplama
{
    internal class Program
    {
        // Calisanin maasini hesaplayan metod.
        static double CalisanMaasiHesaplama(string calisanUnvani, double haftaiciEkstraMesai, double haftasonuEkstaMesai)
        {
            double toplamMaas = 0;
            if (calisanUnvani == "cirak")
                toplamMaas = 3000 + haftaiciEkstraMesai * ((3000 / 300) * 1.5) + haftasonuEkstaMesai * ((3000 / 300) * 2);
            else if (calisanUnvani == "kalfa")
                toplamMaas = 4500 + haftaiciEkstraMesai * ((4500 / 300) * 1.5) + haftasonuEkstaMesai * ((4500 / 300) * 2);
            else toplamMaas = 9000 + haftaiciEkstraMesai * ((9000 / 300) * 1.5) + haftasonuEkstaMesai * ((9000 / 300) * 2);
            return toplamMaas;
        }

        // Calisanlarin bilgilerini dizide tutan method 
        static string[] CalisanMaaslariniDizideTut(ref string[] calisanBilgileri, string calisanAdi, string calisanSoyadi, double calisanToplamMaasi, int index)
        {
            Array.Resize(ref calisanBilgileri, calisanBilgileri.Length + 1);
            calisanBilgileri[index] = calisanAdi + " " + calisanSoyadi + "- Bu ayki toplam maasi : " + calisanToplamMaasi.ToString();
            foreach (string item in calisanBilgileri)
            {
                Console.WriteLine(item);
            }
            return calisanBilgileri;
        }

        // Bu metod kullanicinin bilgileri dogru girip girmedigini kontrol eder. 
        static void BilgileriKontrolEt(out double haftaiciEkstraMesai, out double haftasonuEkstraMesai, out string calisanUnvani, out string calisanAdi, out string calisanSoyadi)
        {
            while (true)
            {
                string[] unvanlar = { "cirak", "kalfa", "usta" };
                Console.Write("Calisan Adini Giriniz : ");
                calisanAdi = Console.ReadLine().Trim();
                Console.Write("Calisan Soyadini giriniz : ");
                calisanSoyadi = Console.ReadLine().Trim();
                Console.Write("Calisan unvanini giriniz :");
                calisanUnvani = Console.ReadLine().Trim();
                Console.Write("Calisanin bu ayki ekstra haftaici mesaisini giriniz :");
                bool mesaiKontrol = double.TryParse(Console.ReadLine().Trim(), out haftaiciEkstraMesai);
                Console.Write("Calisanin bu ayki ekstra haftasonu mesaisini giriniz :");
                bool mesaiKontrol2 = double.TryParse(Console.ReadLine().Trim(), out haftasonuEkstraMesai);
                if (haftaiciEkstraMesai > 10)
                    Console.WriteLine("Bu kadar insan calistirilmaz.");
                else if (haftasonuEkstraMesai > 10)
                    Console.WriteLine("Bu kadar insan calistirilmaz.");
                else if (mesaiKontrol2 && mesaiKontrol && unvanlar.Contains(calisanUnvani) && calisanAdi != "" && calisanSoyadi != "" && haftaiciEkstraMesai >= 0 && haftasonuEkstraMesai >= 0)
                    break;
                else Console.WriteLine("Hatali bilgi girisi . Tekrar giriniz.");
            }
        }

        // Programin Devam edip etmemesini kontrol eden metod
        static bool ProgramiBitirVeyaDevamEttir()
        {
            Console.WriteLine("Programi tekrar kullanmak isterseniz tamam yazin istemezseniz herhangi bir tusa basin.");
            string tekrarKullanilsinMi = Console.ReadLine();
            if (tekrarKullanilsinMi == "tamam")
                return true;
            else return false;
        }


        static void Main(string[] args)
        {
            double haftaiciEkstraMesai = 0;
            double haftasonuEkstraMesai = 0;
            string calisanUnvani = "";
            string calisanAdi = "";
            string calisanSoyadi = "";
            string[] calisanBilgileri = new string[0];
            int sayac = 0;
            bool devamMi = true;

            Console.WriteLine("Bu program calisaninizin bilgilerini isteyerek aylik alacagi maasi hesaplar. Lutfen bilgileri dogru giriniz!");
            while (devamMi)
            {
                BilgileriKontrolEt(out haftaiciEkstraMesai, out haftasonuEkstraMesai, out calisanUnvani, out calisanAdi, out calisanSoyadi);
                double toplamMaas = CalisanMaasiHesaplama(calisanUnvani, haftaiciEkstraMesai, haftasonuEkstraMesai);
                calisanBilgileri = CalisanMaaslariniDizideTut(ref calisanBilgileri, calisanAdi, calisanSoyadi, toplamMaas, sayac);
                sayac++;
                devamMi = ProgramiBitirVeyaDevamEttir();
            }





        }


        }

    }