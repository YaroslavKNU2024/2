using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCinema.Models
{
    public class Film
    {
        public Film()
        {
            FilmStudioSeances = new List<FilmStudioSeance>();
        }
        public int Id { get; set; }
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Композиція")]
        public string FilmName { get; set; }

        //public virtual Genre Genre { get; set; }
        public virtual ICollection<FilmStudioSeance> FilmStudioSeances { get; set; }

    }
}
