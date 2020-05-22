using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabevi
{
    public class Kitap : Program
    {
        public string Kitaptitle { get; set; }
        public string Kitapyazar { get; set; }
        public string Kitaptur { get; set; }

        private DateTime _kitaptarih;
        public DateTime Kitaptarih
        {
            get { return _kitaptarih; }
            set
            {
                if (value.Year >= 1000 && value.Year <= DateTime.Now.Year)
                {
                    _kitaptarih = value;
                }
                else
                {
                    YilKontrol();
                }
            }
        }

        private void YilKontrol()
        {
            while (!(_kitaptarih.Year >= 1000 && _kitaptarih.Year <= DateTime.Now.Year))
            {
                Console.Write("Hatalı Yıl! Lütfen basım yılını bir daha giriniz: ");
                _kitaptarih = new DateTime(Convert.ToInt32(Console.ReadLine()), 1, 1);
            }
        }


        private static string dosyaYol = AppDomain.CurrentDomain.BaseDirectory + "kitaplist.txt";
        public static void Kitaplar()
        {
            if (File.Exists(dosyaYol))
            {
                string bilgileriOku = File.ReadAllText(dosyaYol);
                Console.WriteLine(bilgileriOku);
            }
        }


        public static void dosyaYaz(string kitaptitle, string kitapyazar, string kitaptur, DateTime kitaptarih)
        {
            string kitapBilgi = "\n-Kitap Bilgileri-\nKitap adı: " + kitaptitle + "\nKitap Yazarı: " + kitapyazar + "\nKitap Türü: " + kitaptur + "\nKitap Basım Tarihi: " + kitaptarih.Year;
            File.AppendAllText(dosyaYol, kitapBilgi + Environment.NewLine);
        }

    }
}
