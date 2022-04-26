using BizStreamContactFormBackend.DataTransferObjects.PersonContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizStreamContactFormBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        string addressPath = @$"{Environment.CurrentDirectory}\ContactUsList.txt";

        // GET: api/<PersonController>
        [HttpGet]
        public List<Person> GetAllPeople()
        {
            List<Person> result = null;
            using (PersonContext context = new PersonContext())
            {
                result = context.People.ToList();
            }

            return result;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person GetPersonById(int id)
        {
            List<Person> result = null;
            Person person = null;
            using (PersonContext context = new PersonContext())
            {
                result = context.People.ToList();
                person = result.Where(x => x.PersonId == id).FirstOrDefault();
            }

            return person;
        }

        // POST api/<PersonController>
        [HttpPost]
        public Person SaveUser(Person person)
        {
            using (PersonContext context = new PersonContext())
            {
                FileHelper.AddPersonToFile(addressPath, person);
                context.People.Add(person);
                context.SaveChanges();
            }
            return person;
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        // Removes a person from the database, using the person's Id.
        [HttpDelete("{id}")]
        public void RemovePersonById(int id)
        {
            Person person = new Person();
            using (PersonContext context = new PersonContext())
            {
                person = context.People.Where(x => x.PersonId == id).FirstOrDefault();
                context.People.Remove(person);
                context.SaveChanges();
            }
        }
    }
}
