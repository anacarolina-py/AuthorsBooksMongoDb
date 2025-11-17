using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;


//Conexão com o banco de dados

var client = new MongoClient("mongodb://localhost:27017");

var database = client.GetDatabase("AuthorsAndBooks");

var collectionAuthors = database.GetCollection<Author>("Authors");

var collectionBooks = database.GetCollection<Book>("Books");

//Execução CRUD banco de dados

await CreateData(collectionAuthors, collectionBooks);
await ListAuthors(collectionAuthors);
await ListBooksWithAuthors(collectionBooks, collectionAuthors);
await UpdateAuthorCountry(collectionAuthors, "Clarice Lispector", "Ucrânia");
await DeleteAuthor(collectionAuthors, "Machado de Assis");
await DeleteBook(collectionBooks, "Dom Casmurro");


//CREATE

static async Task CreateData(
    IMongoCollection<Author> collectionAuthors,
    IMongoCollection<Book> collectionBooks)
{
    Console.WriteLine("Inserindo autores e livros...");

    // Autor 1 e livro 1
    var author = new Author("Machado de Assis", "Brasil");
    await collectionAuthors.InsertOneAsync(author);
    Console.WriteLine($"Autor {author.Name} inserido.");

    var book = new Book("Dom Casmurro", 1899, author.Id);
    await collectionBooks.InsertOneAsync(book);
    Console.WriteLine($"Livro {book.Title} inserido.");

    // Autor 2 e livro 2
    var author1 = new Author("Jane Austen", "Reino Unido");
    await collectionAuthors.InsertOneAsync(author1);
    Console.WriteLine($"Autor {author1.Name} inserido.");

    var book1 = new Book("Orgulho e Preconceito", 1813, author1.Id);
    await collectionBooks.InsertOneAsync(book1);
    Console.WriteLine($"Livro {book1.Title} inserido.");

    // Autor 3 e livro 3
    var author2 = new Author("Clarice Lispector", "Brasil");
    await collectionAuthors.InsertOneAsync(author2);
    Console.WriteLine($"Autor {author2.Name} inserido.");

    var book2 = new Book("A Hora da Estrela", 1977, author2.Id);
    await collectionBooks.InsertOneAsync(book2);
    Console.WriteLine($"Livro {book2.Title} inserido.");

    Console.WriteLine("Cadastro concluído.\n");
}



//READ
//lista de autores

static async Task ListAuthors(IMongoCollection<Author> collectionAuthors)
{
    Console.WriteLine("\nLista de autores");

    var authors = await collectionAuthors.Find(_ => true).ToListAsync();

    foreach (var a in authors)
    {
        Console.WriteLine(a);
        Console.WriteLine("----------------------");
    }
}



//Lista de livros com seus autores

static async Task ListBooksWithAuthors(
        IMongoCollection<Book> collectionBooks,
        IMongoCollection<Author> collectionAuthors)
{
    Console.WriteLine("\nLista de livros");

    var books = await collectionBooks.Find(_ => true).ToListAsync();

    foreach (var b in books)
    {
        var authorBook = await collectionAuthors.Find(a => a.Id == b.AuthorId).FirstOrDefaultAsync();

        Console.WriteLine(
            $"\nIdLivro: {b.Id}" +
            $"\nLivro: {b.Title}" +
            $"\nAno: {b.Year}" +
            $"\nAutor: {authorBook?.Name}"
        );
        Console.WriteLine("\n-------------------------------");
    }
}



//UPDATE
//Atualizar país de um autor

static async Task UpdateAuthorCountry(IMongoCollection<Author> collectionAuthors, string name, string newCountry)
{
    Console.WriteLine("\nAtualização de país");

    var update = Builders<Author>.Update.Set(a => a.Country, newCountry);

    var updated = await collectionAuthors.UpdateOneAsync(a => a.Name == name, update);

    Console.WriteLine(updated.ModifiedCount > 0
        ? $"Autor atualizado."
        : "Autor não encontrado.");
}



//DELETE
//deletar autor

static async Task DeleteAuthor(IMongoCollection<Author> collectionAuthors, string name)
{
    Console.WriteLine("\nExclusão de autor");

    var deleted = await collectionAuthors.DeleteOneAsync(a => a.Name == name);

    Console.WriteLine(deleted.DeletedCount > 0
        ? "Autor removido."
        : "Autor não encontrado.");
}



//deletar livro
static async Task DeleteBook(IMongoCollection<Book> collectionBooks, string title)
{
    Console.WriteLine("\nExclusão de livro");

    var deleted = await collectionBooks.DeleteOneAsync(b => b.Title == title);

    Console.WriteLine(deleted.DeletedCount > 0
        ? "Livro removido."
        : "Livro não encontrado."
        );
}