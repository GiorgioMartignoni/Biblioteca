
using Microsoft.EntityFrameworkCore;

namespace Gestionale_Libreria.Models
{
        public class Libro
        {
        //Attributi classe Libro
            public int id { get; set; }
            public String titolo { get; set; }
            public Boolean prestito { get; set; } = false;
            public int idGenere { get; set; }
            public int idScaffale { get; set; }
           // public Scaffale? Scaffale { get; set; } 
            //public Genere Genere { get; set; }

    }
    
}
