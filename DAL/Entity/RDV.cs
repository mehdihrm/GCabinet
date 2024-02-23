using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAL.Entity
{
    [Table("T_RDV")]
    public class RDV
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public DateTime DateRDV { get; set; }
        public bool etatRDV { get; set; }
        
        public int PatientId { get; set; }
        //public Patient Patient { get; set; }
    }
}
