using DAL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTAWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        //Loose Coupling

        IRepository<EmpInfo> _repository;
        public EmployeeController()
        {
            _repository = new Repository<EmpInfo>();    
        }


        // GET api/get
        public IEnumerable<EmpInfo> Get()
        {
            return _repository.GetAll();
        }

        // GET api/get/1
        public EmpInfo Get(string id)
        {
            return _repository.Get(id);
        }

        // POST api/<controller>
        public void Post([FromBody] EmpInfo e)
        {

            _repository.Insert(e);
            _repository.Save();
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody] EmpInfo value)
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