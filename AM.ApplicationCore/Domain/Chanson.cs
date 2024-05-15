using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum StyleMusical
    {
        Classique,
        Pop,
        Rap,
        Rock
    }
    public class Chanson
    {
        [Key]
        public int ChansonId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "DateFete doit etre une date valide")]
        public DateTime DateSortie { get; set; }
      
        public int Duree { get; set; }
        public StyleMusical StyleMusical { get; set; }
        [MinLength(3)]
        [MaxLength(12)]
        public string Titre { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Le nombre de vues doit être un entier positif.")]
        public int VuesYoutube { get; set; }
        public int ArtisteFk { get; set; }
        [ForeignKey("ArtisteFk")]
        public virtual Artiste Artiste { get; set; }

    }
}
