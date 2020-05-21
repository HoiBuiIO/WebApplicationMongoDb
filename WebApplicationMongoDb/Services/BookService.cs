﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMongoDb.Constract;
using WebApplicationMongoDb.Models;

namespace WebApplicationMongoDb.Services
{
	public class BookService
	{
		private readonly IMongoCollection<Book> _books;

		public BookService(IBookstoreDatabaseSettings bookstoreDatabaseSettings)
		{
			var client = new MongoClient(bookstoreDatabaseSettings.ConnectionString);

			var database = client.GetDatabase(bookstoreDatabaseSettings.DatabaseName);

			_books = database.GetCollection<Book>(bookstoreDatabaseSettings.BooksCollectionName);
		}

		public List<Book> Get() => _books.Find(book => true).ToList();

		public Book Get(string id) => _books.Find<Book>(book=> book.Id == id).FirstOrDefault();

		public Book Create(Book book)
		{
			_books.InsertOne(book);
			return book;
		}

		public void Update(string id, Book bookIn) =>
			_books.ReplaceOne(book => book.Id == id, bookIn);

		public void Remove(Book bookIn) =>
			_books.DeleteOne(book => book.Id == bookIn.Id);

		public void Remove(string id) =>
			_books.DeleteOne(book => book.Id == id);
	}
}
