using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struktura
{
    class Program
    {
        const int maxpisztoly = 100;
        const int maxpuska = 30;
        const int maxágyú = 5;
        enum fegyver { pisztoly, puska, ágyú }
        struct Fegyver
        {
            public fegyver név;
            public int töltény;
        }
        static void Main(string[] args)
        {
            List<Fegyver> fegyvertár = new List<Fegyver>();
            Betáraz(fegyvertár);
            Kilistáz(fegyvertár);
            int db = Ellenőriz(fegyvertár, fegyver.puska); // egy adott fegyverben hány töltény van
            Console.WriteLine(db);
            Felvesz(fegyvertár, fegyver.ágyú);
            Eldob(fegyvertár, fegyver.ágyú);
            Eldob(fegyvertár, fegyver.puska);
            Felvesz(fegyvertár, fegyver.ágyú);
            Kilistáz(fegyvertár);
            Console.ReadKey();
        }

        static void Eldob(List<Fegyver> fegyvertár, fegyver fegy)
        {
            //Ha van olyan fegyver akkor el lehet dobni
            //Kikéne venni a listából
            //Hányadik fegyver?
            bool van = false;
            int i = 0;
            foreach (Fegyver f in fegyvertár)
            {
                if (f.név == fegy)
                {
                    van = true;
                    break;
                }
                i++;
            }
            if (van)
            {
                fegyvertár.RemoveAt(i);
            }
        }

        static void Felvesz(List<Fegyver> fegyvertár, fegyver fegy)
        {
            //Eldöntés tétel
            bool van = false;
            int i = 0;
            foreach (Fegyver f in fegyvertár)
            {
                if (f.név == fegy)
                {
                    van = true;
                    break;
                }
                i++;
            }
            Fegyver akt = fegyvertár[i];
            if (van)
            {
                switch (fegyvertár[i].név)
                {
                    case fegyver.pisztoly:
                        akt.töltény = maxpisztoly;
                        break;
                    case fegyver.puska:
                        akt.töltény = maxpuska;
                        break;
                    case fegyver.ágyú:
                        akt.töltény = maxágyú;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Fegyver újfegyver = new Fegyver();
                újfegyver.név = fegy;
                switch (újfegyver.név)
                {
                    case fegyver.pisztoly:
                        újfegyver.töltény = maxpisztoly;
                        break;
                    case fegyver.puska:
                        újfegyver.töltény = maxpuska;
                        break;
                    case fegyver.ágyú:
                        újfegyver.töltény = maxágyú;
                        break;
                    default:
                        break;
                }
                fegyvertár.Add(újfegyver);
            }
        }

        static int Ellenőriz(List<Fegyver> fegyvertár, fegyver aktFegyver)
        {
            int i = 0;
            while (fegyvertár[i].név != aktFegyver)
            {
                i++;
            }
            return fegyvertár[i].töltény;
        }

        static void Kilistáz(List<Fegyver> fegyvertár)
        {
            foreach (Fegyver item in fegyvertár)
            {
                Console.WriteLine($"{item.név} : {item.töltény}");
            }
        }

        static void Betáraz(List<Fegyver> fegyvertár)
        {
            Fegyver f1 = new Fegyver();
            f1.név = fegyver.pisztoly;
            f1.töltény = maxpisztoly;
            fegyvertár.Add(f1);

            Fegyver f2 = new Fegyver();
            f2.név = fegyver.puska;
            f2.töltény = maxpuska;
            fegyvertár.Add(f2);

            Fegyver f3 = new Fegyver();
            f3.név = fegyver.ágyú;
            f3.töltény = maxágyú;
            fegyvertár.Add(f3);
        }
    }
}
