using System.Linq;

public class Angajat
{
    private static int counter = 1;
    public int Cod_Angajat { get; set; }
    public string Nume { get; set; }
    public string Status { get; set; }
    public double Salariu { get; set; }
    public int CodAdresa { get; set; }
    public Angajat(string nume, string status, double salariu, int codadress)
    {
        Cod_Angajat = counter++;
        Nume = nume;
        Status = status;
        Salariu = salariu;
        CodAdresa = codadress;
    }
    public void ArataTot()
    {
        Console.WriteLine($"{Cod_Angajat} {Nume} {Status} {Salariu} {CodAdresa}");
    }
}

public class Adresa
{
    private static int counter = 1;
    public int Cod_addresa { get; set; }
    public string Strada { get; set; }
    public string Bloc { get; set; }
    public string Apartament { get; set; }
    public Adresa(string strada, string bloc, string apartament)
    {
        Cod_addresa = counter++;
        Strada = strada;
        Bloc = bloc;
        Apartament = apartament;
    }
    public void ArataTot()
    {
        Console.WriteLine($"{Cod_addresa} {Strada} {Bloc} {Apartament}");
    }
}

public class plicatieintrebatoare
{
    static void Main()
    {
       
        IList<Angajat> angajati = new List<Angajat>(){
            new Angajat("Abobus Vasile", "specialist", 10000, 3),
            new Angajat("Patlatii Ion", "nespecialist", 19000, 4),
            new Angajat("Bujor Nicolae", "nespecialist", 20000, 1),
            new Angajat("Guzun Victor", "nespecialist", 9100, 2),
            new Angajat("Varzari Liviu", "specialist", 20000, 5),
        };

        
        IList<Adresa> adrese = new List<Adresa>(){
            new Adresa("Teilor", "21", "45/3"),
            new Adresa("Brum Brum", "11", "17/2"),
            new Adresa("Ghreorghel", "29", "45/3"),
            new Adresa("Ionut", "114", "34/2"),
            new Adresa("Trofim", "78", "94/5"),
        };

       
        IList<int> intcol1 = new List<int>() { 5, 6, 6, 7, 8, 9, 14 };
        IList<int> intcol2 = new List<int>() { 13, 65, 65, 60, 13, 64, 29, 18, 71, 22 };

        Console.WriteLine("\n---------- Raspuns ----------\n");

        Console.WriteLine("\n-1.1- Afisati numele angajatului si strada unde traieste");

        var result = from pers in angajati
                     join adr in adrese on pers.CodAdresa equals adr.Cod_addresa
                     select new { numestudent = pers.Nume, strada = adr.Strada };

        Console.WriteLine("\n");
        foreach (var pers in result)
        {
            Console.WriteLine($"{pers.numestudent} {pers.strada}");
        }

        Console.WriteLine("\n-2.1- Grupati angajatii dupa salariu");

        var lookup = angajati.ToLookup(item => item.Salariu);

        foreach (var grouping in lookup)
        {
            Console.WriteLine("\n");
            foreach (Angajat item in grouping)
            {
                Console.WriteLine($"{item.Nume} {item.Salariu}");
            }
        }

        Console.WriteLine("\n-1.2- Returnati valorile distincte din colectie");

        var colectienoua = intcol1.Distinct();
        Console.WriteLine("");
        foreach (int nr in colectienoua)
            Console.Write(nr + " ");

        Console.WriteLine("\n-2.2- Returnati elementele ce apar intr-o colectie dar nu apar in alta colectie");

        var colectienoua2 = intcol1.Except(intcol2);
        Console.WriteLine("");
        foreach (int nr in colectienoua)
            Console.Write(nr + " ");

        Console.WriteLine("\n-3.2- Returnati elementele ce apar in ambele colectii");

        var colectienoua3 = intcol1.Intersect(intcol2);
        Console.WriteLine("");
        foreach (int nr in colectienoua)
            Console.Write(nr + " ");

        Console.WriteLine("\n-4.2- Returnati elementele unice din cele doua colectii ");

        var colectienoua4 = intcol1.Union(intcol2);
        Console.WriteLine("");
        foreach (int nr in colectienoua)
            Console.Write(nr + " ");

        Console.WriteLine("\n-5.2- Verificati daca avem un numar anumit cu metoda DefaultIEmpty");

        Console.WriteLine("Nam idee cum");

        Console.WriteLine("\nGenerati o succesiune de 1000 de numere intregi");

        IEnumerable<int> nums = Enumerable.Range(1, 1000);
        Console.WriteLine();
        foreach (int i in nums)
            Console.Write(i + " ");

        Console.WriteLine("\nGenerati o secventa in care se repeta numarul 7 de 100 de ori");

        IEnumerable<int> nums2 = Enumerable.Repeat(7, 100);
        Console.WriteLine();
        foreach (int i in nums)
            Console.Write(i + " ");



    }
}


