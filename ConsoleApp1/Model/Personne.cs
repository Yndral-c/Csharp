    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ConsoleApp1;

    public class Person
    {
        [Key]
        public Guid Id { get; set; } =  Guid.NewGuid();
        
        [Required]
        public String firstname { get; set; }
        [Required]
        public String lastname { get; set; }
        [Required]
        public DateTime birthdate { get; set; }
    
        [Required]
        public ICollection<Detail> AdressDetails { get; set; } = new List<Detail>();
        [Required]
        public int taille { get; set; }
        
        [ForeignKey("person_classe_fk")]
        public Guid ClasseId { get; set; }
        public Classe Classe {  get; set; }
        
        
        public int getYearsOld()
        {
            DateTime today = DateTime.Today;

            int years = today.Year - birthdate.Year;

            if (today.Month < birthdate.Month || today.Month == birthdate.Month && today.Day < birthdate.Day)
            {
                years--;
            }
            
            return years;
        }
    }