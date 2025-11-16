using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Book
{
    public Book(string title, int year, string authorId)
    {
        Title = title;
        Year = year;
        AuthorId = authorId;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }

    
    [BsonRepresentation(BsonType.ObjectId)]
    public string AuthorId { get; set; }

    public bool AnoValido(int ano)
    {
        int anoAtual = DateTime.Now.Year;
        return ano >= 1 && ano <= anoAtual;
    }

    public string ToString()
    {
        return $"Id: {Id} \nTítulo do Livro: {Title} \nAno de Publicação: {Year} \nAutor: {AuthorId}";
    }
}