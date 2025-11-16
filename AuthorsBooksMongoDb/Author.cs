using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Author
{
    public Author(string name, string country)
    {
        Name = name;
        Country = country;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} \nNome do Autor: {Name} \nPaís de Origem: {Country}";
    }
}