using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ArtBase.WebAPI.Controllers
{
    [Authorize]
    public class ClapsController : ApiController
    {
        private readonly IClapsManager _clapsManager;

        public ClapsController(IClapsManager clapsManager) => _clapsManager = clapsManager;

        [Route("api/GetAllClaps")]
        [HttpGet]
        public IEnumerable<ClapsDTO> GetClaps()
        {
            return _clapsManager.GetAll();
        }

        [ResponseType(typeof(ClapsDTO))]
        [Route("api/GetClap/{Id}")]
        [HttpGet]
        public IHttpActionResult GetClap(int Id)
        {
            ClapsDTO clap = _clapsManager.GetById(Id);

            if (clap != null)
            {
                return Ok(clap);
            }

            return NotFound();
        }

        [Route("api/Claps/User/{userId}")]
        [HttpGet]
        public IHttpActionResult GetClapsByUser(string userId)
        {
            IEnumerable<ClapsDTO> claps = _clapsManager.GetByUser(userId);

            if (claps != null)
            {
                return Ok(claps);
            }

            return NotFound();
        }

        [Route("api/Claps/Bookmark/{bookmarkId}")]
        [HttpGet]
        public IHttpActionResult GetClapsByBookmark(int bookmarkId)
        {
            IEnumerable<ClapsDTO> claps = _clapsManager.GetByBookmark(bookmarkId);

            if (claps == null)
            {
                return Ok(claps);
            }

            return NotFound();
        }

        [ResponseType(typeof(ClapsDTO))]
        [Route("api/AddClap", Name = "ClapAdded")]
        [HttpPost]
        public IHttpActionResult AddClap(ClapsDTO clap)
        {
            if (clap != null)
            {
                clap.User.Id = User.Identity.GetUserId();
                clap.User.Name = User.Identity.GetUserName();

                ClapsDTO clapDTO = _clapsManager.Add(clap);

                if (clapDTO == null)
                {
                    return BadRequest(ModelState);
                }

                return CreatedAtRoute("ClapAdded", new { id = clap.Id }, clapDTO);
            }

            return BadRequest(ModelState);
        }

        [ResponseType(typeof(ClapsDTO))]
        [Route("api/DeleteClap/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteClap(int Id)
        {
            bool check = _clapsManager.Delete(Id);

            if (!check)
            {
                return Ok(check);
            }

            return NotFound();
        }

        [ResponseType(typeof(void))]
        [Route("api/UpdateClap")]
        [HttpPut]
        public IHttpActionResult UpdateClap(ClapsDTO clap)
        {
            if (clap == null)
            {
                return BadRequest();
            }

            ClapsDTO clapDTO = _clapsManager.Update(clap);

            if (clapDTO == null)
            {
                return Ok(clapDTO);
            }

            return BadRequest();
        }
    }
}
