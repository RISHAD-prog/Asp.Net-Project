using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TestList
    {
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string TestName { get; set; }
        [Required]
        public int TestFee { get; set; }
        public virtual List<Labratory> Labratories { get; set; }
        public TestList()
        {
            this.Labratories = new List<Labratory>();
        }
    }
}
