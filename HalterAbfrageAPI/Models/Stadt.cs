using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalterAbfrageAPI.Models
{
    public class Stadt
    {
        [Key]
        [Column(TypeName = "varchar(5)")]
        public string Plz { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Bundesland { get; set; }


    }
}
