namespace ConsoleApp1;

public class Detail
{
    private String street;
    private int zipCode;
    private String city;

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