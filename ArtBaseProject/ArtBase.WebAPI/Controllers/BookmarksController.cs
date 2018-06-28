using ArtBase.Interfaces;
using ArtBase.Contracts.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ArtBase.WebAPI.Controllers
{
    [Authorize]
    public class BookmarksController : ApiController
    {
        public IBookmarkManager _bookmarkManager;

        public BookmarksController(IBookmarkManager bookmarkManager) => _bookmarkManager = bookmarkManager;

        [Route("api/GetAllBookmarks")]
        [HttpGet]
        public IEnumerable<BookmarkDTO> GetBookmarks()
        {
            return _bookmarkManager.GetAll();
        }

        [Route("api/GetLastBookmarks/{numberOfBookmarks}")]
        [HttpGet]
        public IEnumerable<BookmarkDTO> GetLastBookmarks(int numberOfBookmarks)
        {
            return _bookmarkManager.GetLastBookmarks(numberOfBookmarks);
        }

        [Route("api/GetBookmarksBySearchQuery/{searchQuery}")]
        [HttpGet]
        public IEnumerable<BookmarkDTO> GetBookmarksBySearchQuery(string searchQuery)
        {
            return _bookmarkManager.GetBookmarksBySearchQuery(searchQuery);
        }

        [Route("api/CheckBookmarkExists")]
        [HttpPost]
        public BookmarkDTO CheckBookmarkExists(BookmarkDTO bookmark)
        {
            return _bookmarkManager.CheckBookmarkExists(bookmark.URL, User.Identity.GetUserId());
        }

        [ResponseType(typeof(BookmarkDTO))]
        [Route("api/GetBookmark/{Id}")]
        [HttpGet]
        public IHttpActionResult GetBookmark(int Id)
        {
            BookmarkDTO bookmark = _bookmarkManager.GetById(Id);

            if (bookmark != null)
            {
                return Ok(bookmark);
            }

            return Ok(bookmark);
        }

        [Route("api/Bookmarks/User/{userId}")]
        [HttpGet]
        public IHttpActionResult GetBookmarkByUser(string userId)
        {
            IEnumerable<BookmarkDTO> bookmarks = _bookmarkManager.GetBookmarksByUser(userId);

            if (bookmarks != null)
            {
                return Ok(bookmarks);
            }

            return Ok(bookmarks);
        }

        [ResponseType(typeof(BookmarkDTO))]
        [Route("api/AddBookmark", Name = "BookmarkAdded")]
        [HttpPost]
        public IHttpActionResult AddBookmark(BookmarkDTO bookmark)
        {
            if (bookmark != null)
            {
                bookmark.User.Id = User.Identity.GetUserId();
                bookmark.User.Name = User.Identity.GetUserName();
                bookmark.DateSaved = DateTime.Now;
                BookmarkDTO bookmarkDTO = _bookmarkManager.Add(bookmark);

                if (bookmarkDTO == null)
                {
                    return BadRequest(ModelState);
                }

                return CreatedAtRoute("BookmarkAdded", new { id = bookmarkDTO.Id }, bookmarkDTO);
            }

            return BadRequest(ModelState);
        }


        [ResponseType(typeof(BookmarkDTO))]
        [Route("api/DeleteBookmark/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBookmark(int Id)
        {
            bool check = _bookmarkManager.Delete(Id);

            if (check)
            {
                return Ok(check);
            }

            return NotFound();
        }

        [Route("api/UpdateBookmark", Name = "BookmarkUpdated")]
        [HttpPut]
        public IHttpActionResult UpdateBookmark(BookmarkDTO bookmark)
        {
            if (bookmark == null)
            {
                return BadRequest(ModelState);
            }

            bookmark.DateSaved = DateTime.Now;

            BookmarkDTO bookmarkDTO = _bookmarkManager.Update(bookmark);

            return Respond(bookmarkDTO, BadRequest);
        }

        private IHttpActionResult Respond(object obj, Func<IHttpActionResult> reject)
        {
            if(obj != null)
            {
                return Ok(obj);
            }
            return reject();
        }
    }
}