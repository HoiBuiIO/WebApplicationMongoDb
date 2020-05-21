using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMongoDb.Constract;

namespace WebApplicationMongoDb.Models
{
	public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
	{
		public string BooksCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
