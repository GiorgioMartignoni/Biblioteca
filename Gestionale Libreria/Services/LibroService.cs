//Importiamo le classi 
using Gestionale_Libreria.Models;
using Gestionale_Libreria.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Gestionale_Libreria.Services
{
    public static class LibroService
    {
        //Creo l'array di libri
        static List<Libro> Libri = new List<Libro>() { };

        //Conta id 
        static int contaID = 0;

        //Metodo GetAll() che ritornerà la lista di libri
        public static List<Libro> GetAll() => Libri;

        //Metodo GetId() che ritorna un libro o null (?) cercherà la prima istanza che combacia con l'id
        public static Libro? GetId(int id) => Libri.FirstOrDefault(l => l.id == id);

        //Metodo Add(libro)
        public static void Add(Libro libro)
        {
            libro.id = contaID++;
            Libri.Add(libro);
        }

        //Metodo Delete(id)
        public static void Delete(int id)
        {
            var cercaLibro = GetId(id);
            if (cercaLibro is null)
                return;
            Libri.Remove(cercaLibro);
        }

        //Metodo Update(libro)
        public static void Update(Libro libro)
        {
            var appoggio = Libri.FindIndex(l => l.id == libro.id);
            if (appoggio == -1)
                return;
            Libri[appoggio] = libro;
        }
    }
}
