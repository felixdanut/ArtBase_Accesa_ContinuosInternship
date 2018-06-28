using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ArtBase.WebAPI.Controllers
{
    [Authorize]
    public class TagsController : ApiController
    {
        private readonly ITagManager _tagManager;

        public TagsController(ITagManager tagManager) => _tagManager = tagManager;

        [Route("api/GetAllTags")]
        [HttpGet]
        public IEnumerable<TagDTO> GetAllTags()
        {
            return _tagManager.GetAll();
        }

        [ResponseType(typeof(TagDTO))]
        [Route("api/GetTag/{Id}")]
        [HttpGet]
        public IHttpActionResult GetTag(int Id)
        {
            TagDTO tag = _tagManager.GetById(Id);

            if (tag != null)
            {
                return Ok(tag);
            }

            return NotFound();
        }

        [ResponseType(typeof(TagDTO))]
        [Route("api/AddTag", Name = "TagAdded")]
        [HttpPost]
        public IHttpActionResult AddTag(TagDTO tag)
        {
            if (tag != null)
            {
                TagDTO tagDTO = _tagManager.Add(tag);

                if (tagDTO == null)
                {
                    return BadRequest(ModelState);
                }

                return CreatedAtRoute("TagAdded", new { id = tag.Id }, tagDTO);
            }

            return BadRequest(ModelState);
        }

        [ResponseType(typeof(TagDTO))]
        [Route("api/DeleteTag/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTag(int Id)
        {
            bool check = _tagManager.Delete(Id);

            if (!check)
            {
                return NotFound();
            }

            return Ok(check);
        }

        [ResponseType(typeof(void))]
        [Route("api/UpdateTag")]
        [HttpPut]
        public IHttpActionResult UpdateTag(TagDTO tag)
        {
            if (tag == null)
            {
                return BadRequest();
            }

            TagDTO tagDTO = _tagManager.Update(tag);

            if (tagDTO != null)
            {
                return Ok(tagDTO);
            }

            return BadRequest();
        }
    }
}