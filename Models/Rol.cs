﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Rol
    {
        [Key]
        public int PkRol { get; set; }
        public string Nom { get; set; }



    }
}
