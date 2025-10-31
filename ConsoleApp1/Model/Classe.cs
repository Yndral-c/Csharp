using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1;

/* public class Classe
{
    private List<Person> eleves;
    private string nomClasse;
    private string ecole;
    private string niveau;

    public List<Person> Eleves
    {
        get => eleves;
        set => eleves = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string NomClasse
    {
        get => nomClasse;
        set => nomClasse = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Ecole
    {
        get => ecole;
        set => ecole = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Niveau
    {
        get => niveau;
        set => niveau = value ?? throw new ArgumentNullException(nameof(value));
    }
} */

public class Classe
{
    [Key]
    public Guid Id { get; set; } =  Guid.NewGuid();

    [Required] private string name;

    [Required] private string school;

    [Required] private string level;

    private List<Person> persons;
    
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Level
    {
        get => level;
        set => level = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string School
    {
        get => school;
        set => school = value ?? throw new ArgumentNullException(nameof(value));
    }
    public List<Person> Persons
    {
        get => persons;
        set => persons = value ?? throw new ArgumentNullException(nameof(value));
    }

}