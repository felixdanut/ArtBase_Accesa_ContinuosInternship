using ArtBase.Interfaces;
using ArtBase.Contracts.DTOs;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ArtBase.WebAPI.Controllers
{
    [Authorize]
    public class ViewsController : ApiController
    {
        private readonly IViewsManager _viewsManager;

        public ViewsController(IViewsManager viewsManager) => _viewsManager = viewsManager;

        [Route("api/GetAllViews")]
        [HttpGet]
        public IEnumerable<ViewsDTO> GetAllViews()
        {
            return _viewsManager.GetAll();
        }

        [ResponseType(typeof(ViewsDTO))]
        [Route("api/GetView/{Id}")]
        [HttpGet]
        public IHttpActionResult GetView(int Id)
        {
            ViewsDTO view = _viewsManager.GetById(Id);

            if (view != null)
            {
                return Ok(view);
            }

            return NotFound();
        }

        [Route("api/Views/User/{UserId}")]
        [HttpGet]
        public IHttpActionResult GetViewsByUser(string userId)
        {
            IEnumerable<ViewsDTO> views = _viewsManager.GetByUser(userId);

            if (views != null)
            {
                return Ok(views);
            }

            return NotFound();
        }

        [Route("api/Views/Bookmark/{BookmarkId}")]
        [HttpGet]
        public IHttpActionResult GetViewsByBookmark(int bookmarkId)
        {
            IEnumerable<ViewsDTO> views = _viewsManager.GetByBookmark(bookmarkId);

            if (views != null)
            {
                return Ok(views);
            }

            return NotFound();
        }

        [ResponseType(typeof(ViewsDTO))]
        [Route("api/AddView", Name = "ViewAdded")]
        [HttpPost]
        public IHttpActionResult AddView(ViewsDTO view)
        {
            if (view != null)
            {
                view.User.Id = User.Identity.GetUserId();
                view.User.Name = User.Identity.GetUserName();

                ViewsDTO viewDTO = _viewsManager.Add(view);

                if (viewDTO == null)
                {
                    return BadRequest(ModelState);
                }

                return CreatedAtRoute("ViewAdded", new { id = view.Id }, viewDTO);
            }

            return BadRequest(ModelState);
        }

        [ResponseType(typeof(ViewsDTO))]
        [Route("api/DeleteView/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteView(int Id)
        {
            bool check = _viewsManager.Delete(Id);

            if (check)
            {
                return Ok(check);
            }

            return NotFound();
        }
    }
}
