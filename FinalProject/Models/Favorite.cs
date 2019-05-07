using System;
using SQLite;

namespace FinalProject.Models
{
    [Table("Items")]
    public class Favorite
    {
        [PrimaryKey, Column("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Type { get; set; }

        public Favorite()
        {
        }
    }
}
