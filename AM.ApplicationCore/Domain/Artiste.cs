using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Artiste
    {
        [Key]
        public int ArtisteId { get; set; }
        public string Contact { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Nationalite { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public virtual List<Concert> Concerts { get; set; }
        public virtual List<Chanson> Chansons { get; set; }
    }
}
