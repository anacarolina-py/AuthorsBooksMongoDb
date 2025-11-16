using MongoDB.Driver;

//Conexão com o banco de dados

var client = new MongoClient("mongodb://localhost:27017");

var database = client.GetDatabase("AuthorsAndBooks");

var collectionAuthors = database.GetCollection<Author>("Authors");

var collectionBooks = database.GetCollection<Book>("Books");

//CRUD banco de dados

//CREATE

//autor e livro 1
var author = new Author("Machado de Assis", "Machado de Assis");

await collectionAuthors.InsertOneAsync(author);
Console.WriteLine($"Autor {author.Name} inserido.");

var book = new Book("Dom Casmurro", 1899, author.Id);
await collectionBooks.InsertOneAsync(book);
Console.WriteLine($"Livro {book.Title} inserido.");

//autor e livro 2
var author1 = new Author("Jane Austen", "Reino Unido");

await collectionAuthors.InsertOneAsync(author1);
Console.WriteLine($"Autor {author1.Name} inserido.");

var book1 = new Book("Orgulho e Preconceito", 1813, author1.Id);
await collectionBooks.InsertOneAsync(book1);
Console.WriteLine($"Livro {book1.Title} inserido.");

//autor e livro 3

var author2 = new Author("Clarice Lispector", "Brasil");

await collectionAuthors.InsertOneAsync(author2);
Console.WriteLine($"Autor {author2.Name} inserido.");

var book2 = new Book("A Hora da Estrela", 1977, author2.Id);
await collectionBooks.InsertOneAsync(book2);
Console.WriteLine($"Livro {book2.Title} inserido.");

//READ

//Lista de autores
Console.WriteLine("Lista de autores");

var authors = await collectionAuthors.Find(_ => true).ToListAsync();

foreach (var a in authors)
{
    Console.WriteLine(a);
    Console.WriteLine("----------------------");
}

//Lista de livros com seus autores
Console.WriteLine("Lista de livros");

var books = await collectionBooks.Find(_ => true).ToListAsync();

foreach (var b in books)
{
    var authorBook = await collectionAuthors.Find(a => a.Id == b.AuthorId).FirstOrDefaultAsync();
    Console.WriteLine(
        $"\nIdLivro: {b.Id}" +
        $"\nLivro: {b.Title}" +
        $"\nAno: {b.Year}" +
        $"\nAutor: {authorBook.Name}");
    Console.WriteLine("\n-------------------------------");
}



//UPDATE
//Atualizar país de um autor
Console.WriteLine("Atualização de país");


var update = Builders<Author>.Update.Set(a => a.Country, "Ucrânia");

var updated = await collectionAuthors.UpdateOneAsync(a => a.Name == "Clarice Lispector", update);

Console.WriteLine(updated.ModifiedCount > 0
    ? $"Autor atualizado."
    : "Autor não encontrado.");

//DELETE
//deletar autor
Console.WriteLine("Exclusão de autor");

var deletedAuthor = await collectionAuthors.DeleteOneAsync(a => a.Name == "Machado de Assis");

Console.WriteLine(deletedAuthor.DeletedCount > 0
    ? "Autor removido."
    : "Autor não encontrado.");



//deletar livro
Console.WriteLine("Exclusão de livro");

var deletedBook = await collectionBooks.DeleteOneAsync(b => b.Title == "Dom Casmurro");

Console.WriteLine(deletedBook.DeletedCount > 0
    ? "Livro removido."
    : "Livro não encontrado.");