using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalterAbfrageAPI.Models
{
    public class Stadt
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Bundesland { get; set; }

        List <Person> Personen { get; set; }

    }
}
