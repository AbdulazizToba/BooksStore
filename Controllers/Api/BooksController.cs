using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Books.Controllers.Api
{

    public class BooksController : ApiController
    {
        private readonly ApplicationDbContect _Context;
        public BooksController()
        {
            _Context = new ApplicationDbContect();
        }
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = _Context.Books.Find(id);
            if (book == null)
                return NotFound();
            _Context.Books.Remove(book);
            _Context.SaveChanges();
            return Ok();
        }
    }
}
 