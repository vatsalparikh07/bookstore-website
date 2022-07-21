using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Respositary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("publisher")]
    public class PublisherController : Controller
    {
        PublisherRepository _publisherRepository = new PublisherRepository();

        [Route("list")]
        [HttpGet]
        public IActionResult GetCatogires(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var publishers = _publisherRepository.GetPublishers(pageIndex, pageSize, keyword);
            ListResponse<PublisherModel> listResponse = new ListResponse<PublisherModel>()
            {
                Results = publishers.Results.Select(c => new PublisherModel(c)),
                TotalRecords = publishers.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetPublisher(int id)
        {
            var publisher = _publisherRepository.GetPublisher(id);
            PublisherModel publisherModel = new PublisherModel(publisher);

            return Ok(publisherModel);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddPublisher(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
                Address  = model.Address,
                Contact = model.Contact,
            };
            var response = _publisherRepository.AddPublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdatePublisher(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Contact = model.Contact,
            };

            var response = _publisherRepository.UpdatePublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeletePublisher(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _publisherRepository.DeletePublisher(id);
            return Ok(response);
        }
    }
}
