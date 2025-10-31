using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1;

public class Detail
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    
    private String street;

    private int zipCode;
    
    private String city;
    
    [Required]
    //relation n..n vers Detail
    public ICollection<Person> Persons { get; set; } = new List<Person>();

    public Detail(string street, int zipCode, string city)
    {
        this.street = street;
        this.zipCode = zipCode;
        this.city = city;
    }
    
    public string Street
    {
        get => street;
        set => street = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int ZipCode
    {
        get => zipCode;
        set => zipCode = value;
    }

    public string City
    {
        get => city;
        set => city = value ?? throw new ArgumentNullException(nameof(value));
    }
}