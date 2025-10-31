// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using ConsoleApp1.InterfaceRepository;
using ConsoleApp1.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

#region ORM

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(@"C:\\Users\\Landry\\RiderProjects\\ConsoleApp1\\appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // On enregistre le DbContext EF pour gérer la base
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        // On enregistre notre service CSV pour lire le fichier et mapper les objets
        services.AddTransient<DbConnection>();

        services.AddTransient<IPersonRepository, PersonRepository>();
    })
    .Build();

// Crée une portée pour récupérer les services
using var scope = host.Services.CreateScope();
IPersonRepository personRepository = scope.ServiceProvider.GetRequiredService<IPersonRepository>();

String path = configuration.GetRequiredSection("CSVFiles")["CoursSupDeVinci"];
List<Person> persons = new List<Person>();

var lignes = File.ReadAllLines(path);

for (int i = 1; i < lignes.Length; i++) // On commence à 1 pour sauter l'en-tête
{
    string line = lignes[i];
    string[] values = line.Split(',');

    Person person = new Person
    {
        lastname = values[1],
        firstname = values[2],
        birthdate = DateTimeUtils.ConvertToDateTime(values[3]),
        taille = Int32.Parse(values[5])
    };
    
    List<String> details = line.Split(',')[4].Split(';').ToList();
    
    person.AdressDetails.Add(new Detail(details[0], int.Parse(details[1]), details[2]));
    persons.Add(person);
}

Classe maClasse = new Classe();
maClasse.Level = "B2";
maClasse.Name = "B2 C#";
maClasse.School = "SupDeVinci";
maClasse.Persons = persons.ToList();


DbConnection dbConnectionService = scope.ServiceProvider.GetRequiredService<DbConnection>();
// dbConnectionService.SaveFullClasse(maClasse);
List<Person> personsDb = personRepository.GetAllEthan();

foreach (var person in personsDb)
{
    Console.WriteLine("Il y a " + personsDb.Count + " personnes qui s'appelles "+person.firstname + " et habite à "
                      + person.AdressDetails.First().City);
}


#endregion

#region dbConnection
// Déclaration de variable
/*
Dictionary<int, Person> profiles = new Dictionary<int, Person>();
#region lancement services

// Récupération du service CSV

// Charger la configuration manuellement
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(@"C:\\Users\\Landry\\RiderProjects\\ConsoleApp1\\appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        builder.Sources.Clear();
        builder.AddConfiguration(configuration);
    })
    .ConfigureServices(services =>
    {
        // NpgsqlConnection singleton avec ouverture automatique
        services.AddSingleton(provider =>
        {
            var conn = new NpgsqlConnection(
                configuration.GetConnectionString("DefaultConnection"));
            conn.Open(); // ouverture unique
            return conn;
        });

        // On enregistre notre service applicatif
        services.AddTransient<DbConnection>();
        
        // On enregistre du service SCV
        services.AddTransient<IServiceCSV, CSVService>();
    })
    .Build();

using var scope = host.Services.CreateScope();
DbConnection dbConnectionService = scope.ServiceProvider.GetRequiredService<DbConnection>();

IServiceCSV csvService = scope.ServiceProvider.GetRequiredService<IServiceCSV>();

#endregion

#region Lecture du fichier CSV

List<Person> persons = csvService.ReadAndMapPersons();

Classe maClasse = new Classe();
maClasse.Niveau = "B2";
maClasse.NomClasse = "B2 C#";
maClasse.Ecole = "SupDeVinci";
maClasse.Eleves = persons.ToList();

await dbConnectionService.init(maClasse);
#endregion
*/
#endregion

#region Exercice 3

// // Calcule de la taille moyenne
// double moyenne = (int)profiles.Values.Average(p => p.Taille);
// double moyenneMaitre = Math.Floor(moyenne) / 100;
// 
// List<Person> tallerPerson = profiles.Values.Where(person => person.Taille > moyenne).ToList();
// 
// Console.WriteLine($"Il y a {tallerPerson.Count()} personnes qui sont plus grandes que la moyenne de la classe qui est de {moyenneMaitre} mètres");
// 
// 
// foreach (KeyValuePair<int, Person> person in profiles){
//     // Console.WriteLine($"Bonjour {person.Value.Firstname} {person.Value.Lastname},");
//     // Console.WriteLine($"tu as {person.Value.getYearsOld().ToString()} ans et tu habites au {person.Value.AdressDetails.Street} {person.Value.AdressDetails.ZipCode} {person.Value.AdressDetails.City}.");
// }
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
// // Création d'une classe 
// 
// Classe classeB2 = new Classe(profiles.Values.ToList(), "Classe de B2", "Sup de Vinci", "B2");
// 
// // On la tri les élèves tailles décroissante et on sélectionne uniquement ceux et ceux qui sont au dessus de la taille moyenne de la classequi sont de Nantes
// List<Person> tallerPersonNantes = classeB2.Eleves.Where(p => p.Taille > moyenne && p.AdressDetails.City == "Nantes").OrderByDescending(p => p.Taille).ToList();
// 
// // On affiche le résultat
// for (int i=0; i<= tallerPersonNantes.Count-1; i++)
// {
//     double taille = tallerPersonNantes[i].Taille / 100.00;
//     
//     Console.WriteLine($"{i+1} - {tallerPersonNantes[i].Firstname} - {taille:F2}");
// }
// 
#endregion

