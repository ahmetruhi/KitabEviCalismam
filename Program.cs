using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabevi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Kitap[] Kitabevi = new Kitap[0];
            string cik = "";
            while (cik != "E")
            {
                Console.WriteLine("Kitabevi uygulamasına hoşgeldiniz.");
                Console.Write("Kitap eklemek için 1'e\nKitap listesini görmek için 2'ye basınız ");
                int list = int.Parse(Console.ReadLine());
                if (list == 1)
                {
                    try
                    {
                        Console.WriteLine("Kaç Kitap Eklemek İstiyorsunuz?");
                        byte kitapSecim = byte.Parse(Console.ReadLine());
                        Kitabevi = new Kitap[kitapSecim];
                        for (int i = 0; i < kitapSecim; i++)
                        {
                            try
                            {
                                Kitap kitap = new Kitap();
                                Console.WriteLine("Lütfen {0}. kitap bilgilerini ekleyiniz", i + 1);
                                Console.Write("Kitabın adını giriniz: ");
                                kitap.Kitaptitle = Console.ReadLine().ToUpper();
                                Console.Write("Kitabın yazarını giriniz: ");
                                kitap.Kitapyazar = Console.ReadLine();
                                Console.Write("Kitabın türünü giriniz: ");
                                kitap.Kitaptur = Console.ReadLine();
                                Console.Write("Kitabın basım yılını giriniz: ");
                                kitap.Kitaptarih = new DateTime(Convert.ToInt32(Console.ReadLine()), 1, 1);
                                Console.WriteLine("--------------------------------------");
                                Kitabevi[i] = kitap;
                                Kitap.dosyaYaz(kitap.Kitaptitle, kitap.Kitapyazar, kitap.Kitaptur, kitap.Kitaptarih);
                            }
                            catch (Exception hata)
                            {
                                Console.WriteLine("Şöyle bir hata var: " + hata.Message);
                            }
                        }
                    }
                    catch (Exception hata)
                    {
                        Console.WriteLine("Şöyle bir hata var: " + hata.Message);
                    }
                }
                else if (list == 2)
                {
                    Kitap.Kitaplar();
                }
                else
                {
                    Console.WriteLine("\nHatalı Girdiniz Lütfen Tekrar Deneyiniz.\n");
                }
                Console.WriteLine("Programdan Çıkmak İstiyor musunuz? (E/H):");
                cik = Console.ReadLine().ToUpper();
            }
        }
    }
}
