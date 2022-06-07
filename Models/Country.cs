using System.ComponentModel.DataAnnotations;

namespace FinalCinema.Models
{
    public class Country
    {
        public Country()
        {
            Studios = new List<Studio>();
            Cinemas = new List<Cinema>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути пустим")]
        [Display(Name = "Країна")]
        public string CountryName { get; set; }

        public virtual ICollection<Studio> Studios { get; set; }
        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}
