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
    public class AdminController : ApiController
    {
        IRepository<AdminInfo> _repository;
        public AdminController()
        {
            _repository = new Repository<AdminInfo>();
        }


        // GET api/get
        public IEnumerable<AdminInfo> Get()
        {
            return _repository.GetAll();
        }

        // GET api/get/1
        public AdminInfo Get(string id)
        {
            return _repository.Get(id);
        }

        // POST api/<controller>
        public void Post([FromBody] AdminInfo e)
        {

            _repository.Insert(e);
            _repository.Save();
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody] AdminInfo value)
        {
            _repository.Update(value);
            _repository.Save();
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}