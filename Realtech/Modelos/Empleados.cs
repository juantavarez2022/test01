﻿

using System.ComponentModel.DataAnnotations;

namespace Realtech.Modelos
{
    public class Empleados
    {
        [Key]
         public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public DateOnly Fechain { get; set; }
        public DateOnly Fechaactualizacion { get; set; }
        public string Dir1 { get; set; }
        public string Dir2 { get; set; }
        public string Dir3 { get; set; }
        public string Pueblo { get; set; }
        public string Zipcode { get; set; }
        public string Cia1 { get; set; }
        public string Puesto1 { get; set; }
        public DateOnly Desde1 { get; set; }

        public DateOnly Hasta1 { get; set; }
        public string Telefono { get; set; }
        public IFormFile foto  { get; set; }

    }
}