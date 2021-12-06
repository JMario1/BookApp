using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly AppDbContext _dbContext;

        public AuthorController(ILogger<BookController> logger, AppDbContext dbContext){
            _logger = logger;
            _dbContext = dbContext;
        }

        
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id) 
        {
            Author? author = _dbContext.Authors.Find(id);
            if (author == null || id <= 0)
            {
               return  NotFound("No record");
            }
            return Ok(author);
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll() 
        {
            List<Author> authors = _dbContext.Authors.ToList();
            if (authors == null)
            {
               return NotFound("No record");
            }
            return Ok(authors);
        }

        [HttpPost]
        public ActionResult<List<Author>> Add(List<Author> authors)
        {
            ObjectResult response = Ok("");
            authors.ForEach(author => {
                var result = _dbContext.Authors.Where(dbAuthor => dbAuthor.Name == author.Name).ToList();
                if(result.Count != 0)
                {
                   response = Ok("Record already exist");
                }
                else
                {
                    _dbContext.Authors.Add(author);
                    _dbContext.SaveChanges();
                    response = Created("created", author);
                }
               
            });
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<Author> Update(int id, [FromBody]Author author)
        {
            Author? dbAuthor = _dbContext.Authors.Find(id);
            if (dbAuthor == null || id <= 0)
            {
               return  NotFound("No record");
            }
            dbAuthor.Age = author.Age;
            dbAuthor.Name = author.Name;
            _dbContext.Authors.Update(dbAuthor);
            _dbContext.SaveChanges();
            return Ok(dbAuthor);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Author? dbAuthor = _dbContext.Authors.Find(id);
            if (dbAuthor == null || id <= 0)
            {
               return  NotFound("No record");
            }
            _dbContext.Authors.Remove(dbAuthor);
            _dbContext.Books.RemoveRange(_dbContext.Books.Where(book => book.AuthorId == dbAuthor.Id));
            _dbContext.SaveChanges();
            return Ok("Author record with associated books successfully deleted");
        }    
    }
}