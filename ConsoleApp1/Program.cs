// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

class Program {
    static void Main()
    {
        // Déclaration de variable
        Dictionary<int, Person> profiles = new Dictionary<int, Person>();

        #region Lecture du fichier CSV
        // Lecture du fichier CSV
        var data = new StreamReader("Data/CoursSupDeVinci_C#.csv");
        data.ReadLine();
        
        
        string line;
        while ((line = data.ReadLine()) != null)
        {
            string[] values = line.Split(',');
            
            Person person = new Person();
            
            person.Lastname = values[1];
            person.Firstname = values[2];
            person.Birthdate = DateTime.Parse(values[3]);
            var details = values[4].Split(';');
            person.AdressDetails = new Detail(details[0], int.Parse(details[1].Trim()), details[2]);
            person.Taille = Int32.Parse(values[5]);

            profiles.Add(int.Parse(values[0]), person);
        }
        #endregion

        #region Exercice 3
        
        // Calcule de la taille moyenne
        double moyenne = (int)profiles.Values.Average(p => p.Taille);
        double moyenneMaitre = Math.Floor(moyenne) / 100;

        List<Person> tallerPerson = profiles.Values.Where(person => person.Taille > moyenne).ToList();
        
        Console.WriteLine($"Il y a {tallerPerson.Count()} personnes qui sont plus grandes que la moyenne de la classe qui est de {moyenneMaitre} mètres");
        
        
        foreach (KeyValuePair<int, Person> person in profiles){
            // Console.WriteLine($"Bonjour {person.Value.Firstname} {person.Value.Lastname},");
            // Console.WriteLine($"tu as {person.Value.getYearsOld().ToString()} ans et tu habites au {person.Value.AdressDetails.Street} {person.Value.AdressDetails.ZipCode} {person.Value.AdressDetails.City}.");
        }
        #endregion

        #region Exercice 3.5 
        // Console.WriteLine("Quel est le nom de la classe")
        // string nomClasse = Console.ReadLine();
        // Console.WriteLine("Quel est le nom de l'école")
        // string ecole = Console.ReadLine();
        // Console.WriteLine("Quel est le niveau de la classe")
        // string niveau = Console.ReadLine();
        
        // Classe classeB2 = new Classe(profiles.Values.ToList(), nomClasse, ecole, niveau);
        // Console.WriteLine(classeB2.Eleves[0].Firstname);

        #endregion
        
        #region Exercice 4
        // Création d'une classe 
        
        Classe classeB2 = new Classe(profiles.Values.ToList(), "Classe de B2", "Sup de Vinci", "B2");
        
        // On la tri les élèves tailles décroissante et on sélectionne uniquement ceux et ceux qui sont au dessus de la taille moyenne de la classequi sont de Nantes
        List<Person> tallerPersonNantes = classeB2.Eleves.Where(p => p.Taille > moyenne && p.AdressDetails.City == "Nantes").OrderByDescending(p => p.Taille).ToList();
       
        // On affiche le résultat
        for (int i=0; i<= tallerPersonNantes.Count-1; i++)
        {
            double taille = tallerPersonNantes[i].Taille / 100.00;
            
            Console.WriteLine($"{i+1} - {tallerPersonNantes[i].Firstname} - {taille:F2}");
        }
        
        #endregion
    }
}
