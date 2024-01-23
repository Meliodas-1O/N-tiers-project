using JeBalance.API.Admin.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JeBalance.API.Admin.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private static List<Book> books = new List<Book>
		{
			new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
			new Book { Id = 2, Title = "Le Seigneur des Anneaux", Author = "J.R.R. Tolkien", Year = 1954 },
			new Book { Id = 3, Title = "Orgueil et Préjugés", Author = "Jane Austen", Year = 1813 },
			new Book { Id = 4, Title = "Cent ans de solitude", Author = "Gabriel García Márquez", Year = 1967 },
			new Book { Id = 5, Title = "L'Étranger", Author = "Albert Camus", Year = 1942 },
			new Book { Id = 6, Title = "Harry Potter à l'école des sorciers", Author = "J.K. Rowling", Year = 1997 },
			new Book { Id = 7, Title = "Les Misérables", Author = "Victor Hugo", Year = 1862 },
			new Book { Id = 8, Title = "Le Petit Prince", Author = "Antoine de Saint-Exupéry", Year = 1943 },
			new Book { Id = 9, Title = "Crime et Châtiment", Author = "Fiodor Dostoïevski", Year = 1866 },
			new Book { Id = 10, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 }
		};
		// GET: api/<BookController>
		[HttpGet]
		public ActionResult<IEnumerable<Book>> Get()
		{
			return Ok(books);
		}

		// GET api/<BookController>/5
		[HttpGet("{id}")]
		public ActionResult<Book> Get(int id)
		{
			var book = books.FirstOrDefault(b => b.Id == id);

			if (book == null)
				return NotFound();

			return Ok(book);
		}

		// POST api/<BookController>
		[HttpPost]
		public ActionResult<Book> Post([FromBody] Book newBook)
		{ 
				newBook.Id = books.Count + 1;
				books.Add(newBook);

				return CreatedAtAction(nameof(Get), new { id = newBook.Id}, newBook);
		}

		// PUT api/<BookController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Book updatedBook)
		{
			var existingBook = books.FirstOrDefault(b => b.Id == id);

			if (existingBook == null)
				return NotFound();

			existingBook.Title = updatedBook.Title;
			existingBook.Author = updatedBook.Author;
			existingBook.Year = updatedBook.Year;

			return NoContent();
		}

		// DELETE api/<BookController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			{
				var book = books.FirstOrDefault(b => b.Id == id);

				if (book == null)
					return NotFound();

				books.Remove(book);

				return NoContent();
			}
		}
	}
}
