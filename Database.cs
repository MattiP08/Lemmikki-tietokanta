
using System.Net;
using Microsoft.Data.Sqlite;

public class OwnerArray
    {
        public int id;
        public string name;
        public int phone_number;
    }

public class PetArray
    {
        public int id;
        public string name;
        public string species;
        public int owner_id;
    }

public class Database
{

    private static string ConnectionString = "Data Source=Database.db";

    public Database()
    {

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var CreateOwner = Connection.CreateCommand();
        CreateOwner.CommandText = @"
            CREATE TABLE IF NOT EXISTS Owners (
                id INTEGER PRIMARY KEY,
                name TEXT,
                phone_number INTEGER
            )
        ";
        CreateOwner.ExecuteNonQuery();

        var CreatePets = Connection.CreateCommand();
        CreatePets.CommandText = @"
            CREATE TABLE IF NOT EXISTS Pets (
                id INTEGER PRIMARY KEY,
                name TEXT,
                species TEXT,
                owner_id INTEGER,
                FOREIGN KEY(owner_id) REFERENCES Owners(id)
            )
        ";
        CreatePets.ExecuteNonQuery();

    }

    public void AddOwner(int id, string name, int phoneNumber)
    {

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var AddOwnerCommand = Connection.CreateCommand();
        AddOwnerCommand.CommandText = @"
            INSERT INTO Owners (id,name,phone_number) VALUES ($id,$name,$phoneNumber)
        ";

        AddOwnerCommand.Parameters.AddWithValue("$id",id);
        AddOwnerCommand.Parameters.AddWithValue("$name",name);
        AddOwnerCommand.Parameters.AddWithValue("$phoneNumber",phoneNumber);

        AddOwnerCommand.ExecuteNonQuery();

    }

    public void AddPet(int id, string name, string species, int owner_id)
    {

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var AddPetCommand = Connection.CreateCommand();
        AddPetCommand.CommandText = @"
            INSERT INTO Pets (id,name,species,owner_id) VALUES ($id,$name,$species,$owner_id)
        ";

        AddPetCommand.Parameters.AddWithValue("$id",id);
        AddPetCommand.Parameters.AddWithValue("$name",name);
        AddPetCommand.Parameters.AddWithValue("$species",species);
        AddPetCommand.Parameters.AddWithValue("$owner_id",owner_id);

        AddPetCommand.ExecuteNonQuery();

    }

    public void ChangePhoneNumber(int id, int NewNumber)
    {

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var ChangeNumber = Connection.CreateCommand();
        ChangeNumber.CommandText = @"
            UPDATE Owners SET phone_number=$NewNumber WHERE id=$id
        ";

        ChangeNumber.Parameters.AddWithValue("$NewNumber",NewNumber);
        ChangeNumber.Parameters.AddWithValue("$id",id);

        ChangeNumber.ExecuteNonQuery();

    }

    public List<OwnerArray> ReturnOwnerList()
    {

        List<OwnerArray> OwnerList = new List<OwnerArray>();

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var GiveList = Connection.CreateCommand();
        GiveList.CommandText = @"
            SELECT id, name, phone_number FROM Owners
        ";
        
        SqliteDataReader reader = GiveList.ExecuteReader();

        while(reader.Read())
        {

            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            int phone_number = reader.GetInt32(2);

            OwnerArray ownerArray = new OwnerArray();
            ownerArray.id = id;
            ownerArray.name = name;
            ownerArray.phone_number = phone_number;
            OwnerList.Add(ownerArray);

        }

        return OwnerList;

    }

    public List<PetArray> ReturnPetList()
    {

        List<PetArray> PetList = new List<PetArray>();

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var GiveList = Connection.CreateCommand();
        GiveList.CommandText = @"
            SELECT id, name, species, owner_id FROM Pets
        ";
        
        SqliteDataReader reader = GiveList.ExecuteReader();

        while(reader.Read())
        {

            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string species = reader.GetString(2);
            int owner_id = reader.GetInt32(3);

            PetArray petArray = new PetArray();
            petArray.id = id;
            petArray.name = name;
            petArray.species = species;
            petArray.owner_id = owner_id;
            PetList.Add(petArray);

        }

        return PetList;

    }

    public bool IDIsUnique(int id)
    {

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var CheckID = Connection.CreateCommand();
        CheckID.CommandText = @"
            SELECT COUNT(1) FROM Owners WHERE id = @id
        ";

        CheckID.Parameters.AddWithValue("@id",id);

        return Convert.ToInt32(CheckID.ExecuteScalar()) <= 0;
        
    }

    public bool PhoneNumberIsUnique(int phone_number)
    {

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var CheckPhoneNumber = Connection.CreateCommand();
        CheckPhoneNumber.CommandText = @"
            SELECT COUNT(1) FROM Owners WHERE phone_number = @phone_number
        ";

        CheckPhoneNumber.Parameters.AddWithValue("@phone_number",phone_number);

        return Convert.ToInt32(CheckPhoneNumber.ExecuteScalar()) <= 0;
        
    }

    public bool PetIDIsUnique(int id)
    {

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var CheckID = Connection.CreateCommand();
        CheckID.CommandText = @"
            SELECT COUNT(1) FROM Pets WHERE id = @id
        ";

        CheckID.Parameters.AddWithValue("@id",id);

        return Convert.ToInt32(CheckID.ExecuteScalar()) <= 0;
        
    }

    public List<OwnerArray> ReturnOwnerListWithPetName(string petName)
    {

        List<OwnerArray> OwnerList = new List<OwnerArray>();

        var Connection = new SqliteConnection(ConnectionString);
        Connection.Open();

        var GiveList = Connection.CreateCommand();
        GiveList.CommandText = @"
            SELECT Owners.id, Owners.name, Owners.phone_number
            FROM Pets
            JOIN Owners ON Pets.owner_id = Owners.id
            WHERE Pets.name = @petName
        ";

        GiveList.Parameters.AddWithValue("@petName",petName);
        
        SqliteDataReader reader = GiveList.ExecuteReader();

        while(reader.Read())
        {

            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            int phone_number = reader.GetInt32(2);

            OwnerArray ownerArray = new OwnerArray();
            ownerArray.id = id;
            ownerArray.name = name;
            ownerArray.phone_number = phone_number;
            OwnerList.Add(ownerArray);

        }

        return OwnerList;

    }

}
