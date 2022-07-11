using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using System.ComponentModel.DataAnnotations;

namespace BlazorEmpty.ViewModel
{
    public class FootballerView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
