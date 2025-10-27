// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

class Program {
    static void Main()
    {

        var data = new StreamReader("Data/CoursSupDeVinci_C#.csv");
        data.ReadLine();

        Dictionary<int, Person> profiles = new Dictionary<int, Person>();

        #region Lecture du fichier CSV
        // Lecture du fichier CSV
        string line;
        while ((line = data.ReadLine()) != null)
        {
            string[] values = line.Split(',');
            
            Person person = new Person();
            
            person.Firstname = values[1];
            person.Lastname = values[2];
            person.Birthdate = DateTime.Parse(values[3]);
            var details = values[4].Split(';');
            person.AdressDetails = new Detail(details[0], int.Parse(details[1].Trim()), details[2]);
            person.Taille = Int32.Parse(values[5]);

            profiles.Add(int.Parse(values[0]), person);
        }
        #endregion

        Console.WriteLine();

        #region Exercice 3
        
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
        // string nomClasse = Console.ReadLine("Quel est le nom de la classe");
        // string ecole = Console.ReadLine("Quel est le nom de l'école");
        // string niveau = Console.ReadLine("Quel est le niveau de la classe");
        
        // Classe classeB2 = new Classe(profiles.Values.ToList(), nomClasse, ecole, niveau);
        // Console.WriteLine(classeB2.Eleves[0].Firstname);

        #endregion
        
        #region Exercice 4
        // On reprend la list tallerPerson qui a été fait dans Exercice 3
        // On la tri dans l'ordre des personnes les plus grandes et on sélectionne uniquement celle qui sont de Nantes
        List<Person> tallerPersonNantes = tallerPerson.OrderByDescending(p => p.Taille).ToList().Where(p => p.AdressDetails.City == "Nantes").ToList();
       
        // On affiche le résultat
        for (int i=0; i<= tallerPersonNantes.Count-1; i++)
        {
            double taille = tallerPersonNantes[i].Taille / 100.00;
            
            Console.WriteLine($"{i+1} - {tallerPersonNantes[i].Lastname} - {taille:F2}");
        }
        
        #endregion
    }
}
