using Microsoft.AspNet.SignalR;
using PruebaMoraviaWebService.Hubs;
using PruebaMoraviaWebService.Models.Entities;
using PruebaMoraviaWebService.Models.Repositories;
using PruebaMoraviaWebService.ViewsModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaMoraviaWebService.Controllers
{
    public class CommentsController : ApiController
    {
        // GET: api/Comments
        [System.Web.Http.Authorize]
        public IEnumerable<object> Get()
        {
            CommentRepository rep = new CommentRepository();

            List<Comment> list = rep.GetAll();

            List<CommentViewModel> model = new List<CommentViewModel>();

            CommentViewModel vm;

            list.ForEach(item => { vm = new CommentViewModel(); vm.comment = item; model.Add(vm); });

            return model.Select(c => new { c.Fecha, c.TimeAgo, c.CommentDescription, c.UserName }).OrderByDescending(c=> c.Fecha).ToList();
        }

        // GET: api/Comments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comments
        public IHttpActionResult Post([FromBody]Comment comment)
        {
            comment.Fecha = DateTime.Now;

            CommentRepository rep = new CommentRepository();

            rep.Create(comment);
                           
            return Ok();
        }

        // PUT: api/Comments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comments/5
        public void Delete(int id)
        {
        }
    }
}
