namespace ConsoleApp1;

public class Classe
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

    

}