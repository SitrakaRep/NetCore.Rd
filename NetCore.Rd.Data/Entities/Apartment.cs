using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Rd.Data.Entities
{
    public class Apartment
    {
        public int ID { get; set; }
        public string ApartmentName { get; set; }
        public int ApartmentNumber { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateEdition { get; set; }
        [ForeignKey("OwnerID")]
        public int? OwnerID { get; set; }
        public Owner Owner { get; set; }
    }
}