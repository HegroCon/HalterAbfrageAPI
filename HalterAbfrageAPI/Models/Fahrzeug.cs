using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalterAbfrageAPI.Models
{
    public class Fahrzeug
    {
        [Column(TypeName = "varchar(15)")]
        public string Kennzeichen { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Marke { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Kategory { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Farbe { get; set; }
        public Person Person { get; set; }

    }
}
