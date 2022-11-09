using DAL.Repository;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTAWebAPI.Controllers
{
    public class BlogController : ApiController
    {


        //Loose Coupling

        IRepository<BlogInfo> _repository;
        public BlogController()
        {
            _repository = new Repository<BlogInfo>();
        }


        // GET api/get
        public IEnumerable<BlogInfo> Get()
        {
            return _repository.GetAll();
        }

        // GET api/get/1
        public BlogInfo Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/<controller>
        public void Post([FromBody] BlogInfo e)
        {

            _repository.Insert(e);
            _repository.Save();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] BlogInfo value)
        {
            _repository.Update(value);
            _repository.Save();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}