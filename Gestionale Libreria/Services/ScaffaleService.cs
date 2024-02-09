//Importiamo le classi 
using Gestionale_Libreria.Models;
using Gestionale_Libreria.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Gestionale_Libreria.Services
{
    public static class ScaffaleService
    {

        static List<Scaffale> Libreria = new List<Scaffale>() { };

        static int contaID = 0;

        public static List<Scaffale> GetAll() => Libreria;


        public static Scaffale? GetId(int id) => Libreria.FirstOrDefault(l => l.id == id);


        public static void Add(Scaffale scaffale)
        {
            scaffale.id = contaID++;
            Libreria.Add(scaffale);
        }

        public static void Delete(int id)
        {
            var cercaScaffale = GetId(id);
            if (cercaScaffale is null)
                return;
            Libreria.Remove(cercaScaffale);
        }

        public static void Update(Scaffale scaffale)
        {
            var appoggio = Libreria.FindIndex(l => l.id == scaffale.id);
            if (appoggio == -1)
                return;
            Libreria[appoggio] = scaffale;
        }
    }
}
