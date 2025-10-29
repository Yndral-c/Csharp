using ConsoleApp1.Utils;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    // C'est la classe qui gère toute la logique CSV
    public class CSVService
    {
        private readonly string _path;

        // Le chemin est injecté via le constructeur
        public CSVService(IConfiguration configuration)
        {
            // Récupérer le chemin du fichier CSV à partir de la configuration (appsettings.json)
            _path = configuration.GetRequiredSection("CSVFiles")["CoursSupDeVinci"] ?? 
                    throw new InvalidOperationException("CSV path not found in configuration.");
        }

        public List<Person> ReadAndMapPersons()
        {
            List<Person> persons = new List<Person>();
            
            // Lire toutes les lignes du fichier
            var lignes = File.ReadAllLines(_path);

            for (int i = 1; i < lignes.Length; i++) // On commence à 1 pour sauter l'en-tête
            {
                string line = lignes[i];
                string[] values = line.Split(',');

                Person person = new Person
                {
                    Lastname = values[1],
                    Firstname = values[2],
                    Birthdate = DateTimeUtils.ConvertToDateTime(values[3]),
                    Taille = Int32.Parse(values[5])
                };
                
                // Gérer les détails de l'adresse
                var details = values[4].Split(';');
                person.AdressDetails = new Detail(details[0], int.Parse(details[1].Trim()), details[2]);

                persons.Add(person);
            }

            return persons;
        }
    }
}