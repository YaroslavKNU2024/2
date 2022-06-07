using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Linq;

namespace FinalCinema.Models
{
    public class FilmStudioSeance
    {
        public FilmStudioSeance() { }
        public int Id { get; set; }
        public int? FilmId { get; set; }
        public int? StudioId { get; set; }
        public int? SeanceId { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film Film { get; set; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { get; set; }

        [ForeignKey("SeanceId")]
        public virtual Seance Seance { get; set; }
    }
}
