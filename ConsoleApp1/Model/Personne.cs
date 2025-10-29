    using ConsoleApp1;

    public class Person
    {
        private String firstname;

        private String lastname;
        
        private DateTime birthdate;
        
        private Detail adressDetails;

        private int taille;

        public int Taille
        {
            get => taille;
            set => taille = value;
        }

        public Detail AdressDetails
        {
            get => adressDetails;
            set => adressDetails = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Firstname
        {
            get => firstname;
            set => firstname = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Lastname
        {
            get => lastname;
            set => lastname = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime Birthdate
        {
            get => birthdate;
            set => birthdate = value;
        }

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