using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalterAbfrageAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Vorname { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string StrasseHausnummer { get; set; }

        public DateTime Birthday { get; set; }

        public string StadtId { get; set; }
        public Stadt Stadt { get; set; }
    }
}
