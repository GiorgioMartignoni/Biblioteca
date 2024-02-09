//Importiamo le classi 
using Gestionale_Libreria.Models;
using Gestionale_Libreria.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Gestionale_Libreria.Services
{
    public static class GenereService
    {

        static List<Genere> Generi = new List<Genere>() { };

        static int contaID = 0;

        public static List<Genere> GetAll() => Generi;


        public static Genere? GetId(int id) => Generi.FirstOrDefault(l => l.id == id);


        public static void Add(Genere genere)
        {
            genere.id = contaID++;
            Generi.Add(genere);
        }

        public static void Delete(int id)
        {
            var cercaGenere = GetId(id);
            if (cercaGenere is null)
                return;
            Generi.Remove(cercaGenere);
        }

        public static void Update(Genere genere)
        {
            var appoggio = Generi.FindIndex(l => l.id == genere.id);
            if (appoggio == -1)
                return;
            Generi[appoggio] = genere;
        }
    }
}
