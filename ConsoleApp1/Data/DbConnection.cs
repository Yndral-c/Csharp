using Npgsql;

namespace ConsoleApp1;

public class DbConnection
{
    private readonly AppDbContext _appDbContext;
    public DbConnection(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void SaveFullClasse(Classe maClasse)
    {
        _appDbContext.Add(maClasse);
        _appDbContext.SaveChanges();
    }
    
    
    /*
    public async Task init(Classe maClasse)
    {
         // Commence une transaction pour tout insérer ensemble
        await using var transaction = await _connection.BeginTransactionAsync();

        // --- Insert Classe ---
        var insertClasseCmd = new NpgsqlCommand(
            "INSERT INTO \"Classe\"(nom, \"Niveau\", \"Ecole\") VALUES (@name, @level, @school) RETURNING id", _connection, transaction);
        insertClasseCmd.Parameters.AddWithValue("name", maClasse.NomClasse);
        insertClasseCmd.Parameters.AddWithValue("level", maClasse.Niveau);
        insertClasseCmd.Parameters.AddWithValue("school", maClasse.Ecole);
        
        Guid classeId = (Guid)await insertClasseCmd.ExecuteScalarAsync();

        // --- Insert Persons ---
        
        foreach (var person in maClasse.Eleves)
        {
            var insertPersonCmd = new NpgsqlCommand(
                "INSERT INTO \"Person\"(firstname, lastname, birthdate, size, id_classe) VALUES (@firstname, @lastname, @birthdate, @size, @idClasse) RETURNING id", _connection, transaction);
            insertPersonCmd.Parameters.AddWithValue("firstname", person.Firstname);
            insertPersonCmd.Parameters.AddWithValue("lastname", person.Lastname);
            insertPersonCmd.Parameters.AddWithValue("birthdate", person.Birthdate);
            insertPersonCmd.Parameters.AddWithValue("size", person.Taille);
            insertPersonCmd.Parameters.AddWithValue("idclasse", classeId);
            
            Guid personId = (Guid)await insertPersonCmd.ExecuteScalarAsync();

            // --- Insert Details ---
                var insertDetailCmd = new NpgsqlCommand(
                    "INSERT INTO \"Detail\"(street, city, zipCode) VALUES (@street, @city, @zipCode) RETURNING id", _connection, transaction);
                insertDetailCmd.Parameters.AddWithValue("street", person.AdressDetails.Street);
                insertDetailCmd.Parameters.AddWithValue("city", person.AdressDetails.City);
                insertDetailCmd.Parameters.AddWithValue("zipCode", person.AdressDetails.ZipCode);
                
                Guid detailId = (Guid)await insertDetailCmd.ExecuteScalarAsync();

                var insertPersonDetailCmd = new NpgsqlCommand(
                    "INSERT INTO \"Person_detail\"(\"id_Person\", \"id_Detail\") VALUES (@idPerson, @idDetail)", _connection, transaction);
                insertPersonDetailCmd.Parameters.AddWithValue("idPerson", personId);
                insertPersonDetailCmd.Parameters.AddWithValue("idDetail", detailId);
                await insertPersonDetailCmd.ExecuteNonQueryAsync();
                
        }

        // Commit
        await transaction.CommitAsync();

        Console.WriteLine("Insertion hiérarchique réussie");
    }

*/
}
