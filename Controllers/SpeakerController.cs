using Microsoft.AspNet.Mvc;
using MongoMvc.Models;
using System.Collections.Generic;
using MongoDB.Bson;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoMvc.Controllers
{
    [Route("api/[controller]")]
    public class SpeakerController : Controller
    {

        readonly ISpeakerRespository _speakerRepository;
        public SpeakerController(ISpeakerRespository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        [HttpGet]
        public IEnumerable<Speaker> GetAll()
        {
            var speakers = _speakerRepository.AllSpeakers();
            return speakers;
 
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdRoute")]
        public IActionResult GetById(string id)
        {
            var item = _speakerRepository.GetById(new ObjectId(id));
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public void CreateSpeaker([FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _speakerRepository.Add(speaker);

                string url = Url.RouteUrl("GetByIdRoute", new { id = speaker.Id.ToString() }, Request.Scheme, Request.Host.ToUriComponent());
                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteSpeaker(string id)
        {
            if (_speakerRepository.Remove(new ObjectId(id)))
            {
                return new HttpStatusCodeResult(204); // 201 No Content
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
