using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E122.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double latitude { get; set; }

        public double length { get; set; }

        public String longDescription { get; set; }

        public String shortDescription { get; set; }

        public override string ToString()
        {
            return "Descripcion Corta: " + shortDescription + " | Descripcion Larga: " + " | Latitude: "
                + latitude + "Longitud: " + length;
        }

    }
}
