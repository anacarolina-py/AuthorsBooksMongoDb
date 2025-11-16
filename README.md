Exercício: CRUD básico em MongoDB usando C# em Console Application

Objetivo

Este exercício visa consolidar seu conhecimento sobre operações básicas de banco de dados MongoDB (CRUD: Create, Read, Update, Delete) utilizando a linguagem C# em um aplicativo do tipo Console Application. Além disso, você irá trabalhar com duas collections relacionadas, exercitando a modelagem simples de dados e consultas entre elas.

Contexto

Você deverá desenvolver uma aplicação que manipule dados sobre autores de livros e os próprios livros. Para isso, utilize duas collections no MongoDB: uma chamada Authors para armazenar informações dos autores, e outra chamada Books para armazenar os livros associados a esses autores.

--------------------------------------------------------------------------------------------------------------------------------------------------------------
- Foi utilizado o Visual Studio e o MongoDBCompass, para o bom funcionamento do código é necessário ter uma conexão com o MongoDB.
- Primeiro, é necessário baixar o pacote MongoDb.Driver nos pacotes Nuget do Visual Studio para o funcionamento do código com a conexão com o banco.
- Clone o repositório e verifique o local da conexão do banco e altere se necessário.
Se tudo ocorrer bem, você verá:
- Inserção de autores
- Inserção de livros
- Listagem dos livros e seus autores
- Atualização do autor
- Remoção de dados do banco
Esse é o exemplo de CRUD feito com dados persistidos em bancos de dados MongoDB.
