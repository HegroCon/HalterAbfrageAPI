﻿namespace HalterAbfrageAPI.Models
{
    public class Stadt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bundesland { get; set; }

        List <Person> Personen { get; set; }

    }
}
