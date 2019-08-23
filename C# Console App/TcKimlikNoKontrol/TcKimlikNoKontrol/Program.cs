using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcKimlikNoKontrol
{
    class Program
    {
        static void Main(string[] args)
        {
            string tckimliknos;
            bool dogruMu2 = false;
            bool dogruMu3 = false;
            bool dogruMu4 = false;
            bool dogruMu5 = false;

            int tekHanelerToplami = 0;
            int ciftHanelerToplami = 0;

            Console.Write("Tc Kimlik Numarası Giriniz:");
            tckimliknos = Console.ReadLine();
            bool kontrol = false;

            while (kontrol == false)
            {
                if (tckimliknos.Length < 11 || tckimliknos.Length > 11)
                {
                    Console.Write("Tc Kimlik Numarası Giriniz:");
                    tckimliknos = Console.ReadLine();
                }
                else
                {
                    kontrol = true;
                }
            }

            int tchane1 = Convert.ToInt32(tckimliknos[0].ToString());
            if (tchane1 != 0) dogruMu3 = true;

            // Sayısal değer kontrolü
            if (long.TryParse(tckimliknos, out long kimlikNo))
                dogruMu2 = true;

            int fark = 0, kalan = 0, haneon = Convert.ToInt32(tckimliknos[9].ToString());


            for (int tek = 0; tek <= 8; tek += 2)
            {
                tekHanelerToplami += Convert.ToInt32(tckimliknos[tek].ToString());
            }
            tekHanelerToplami *= 7;

            for (int cift = 1; cift <= 7; cift += 2)
            {
                ciftHanelerToplami += Convert.ToInt32(tckimliknos[cift].ToString());
            }
            fark = tekHanelerToplami - ciftHanelerToplami;
            kalan = fark % 10;
            if (kalan == haneon)
            {
                dogruMu4 = true;
            }

            int tumhaneler = 0;
            for (int p = 0; p <= 9; p++)
            {
                tumhaneler += Convert.ToInt32(tckimliknos[p].ToString());
            }
            if (tumhaneler % 10 == Convert.ToInt32(tckimliknos[10].ToString())) dogruMu5 = true;


            if (dogruMu2 && dogruMu3 && dogruMu4 && dogruMu5)
            {
                Console.WriteLine("TC Kimlik Numarası Geçerli.");
            }
            else
            {
                Console.WriteLine("TC Kimlik Numarası Geçersiz");
            }
            Console.ReadKey();
        }
    }
}
