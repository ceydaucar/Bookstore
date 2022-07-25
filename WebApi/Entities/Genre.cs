using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // id' yi otomatik atamak için kullanılan bir attribute
        
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}