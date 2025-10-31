using ConsoleApp1.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _appDbContext;

    public PersonRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Person> GetAllPerson()
    {
        return _appDbContext.Persons.ToList();
    }

    public List<Person> GetAllEthan()
    {
        return _appDbContext.Persons
            .Include(person => person.AdressDetails)
            .Where(person => person.firstname.Equals("Ethan"))
            .ToList();
            
    }
}