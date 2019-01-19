using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomersAPIServcies.Models;

namespace CustomersAPIServcies.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OwnerController : Controller
    {
        [ApiVersion("2.0")]
        // GET api/values
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            List<Owner> lstOwner = GetOnwers();
            return lstOwner;
        }

        private static List<Owner> GetOnwers()
        {
            List<Owner> lstOwner = new List<Owner>();
            lstOwner.Add(new Owner() { id = "1", name = "Gaurav", dateOfBirth = DateTime.Now, address = "BanerAuth" });
            lstOwner.Add(new Owner() { id = "2", name = "Trupti", dateOfBirth = DateTime.Now, address = "Auth2" });
            lstOwner.Add(new Owner() { id = "3", name = "Aaaru", dateOfBirth = DateTime.Now, address = "Auth3" });
            lstOwner.Add(new Owner() { id = "4", name = "Riyu", dateOfBirth = DateTime.Now, address = "Auth4" });
            lstOwner.Add(new Owner() { id = "5", name = "Pappa", dateOfBirth = DateTime.Now, address = "Auth5" });
            return lstOwner;
        }

        [HttpGet]
        [Route("{id}/{account}")]
        public Owner Get(int id,string account)
        {
            Owner onwer = GetOnwers().Where(i => i.id == id.ToString()).FirstOrDefault();
            onwer.accounts = new List<Account>();
            onwer.accounts.Add(new Account() {accountType = "Domestic", dateCreated = DateTime.Now , id ="1",ownerId="1" });
            onwer.accounts.Add(new Account() { accountType = "International", dateCreated = DateTime.Now, id = "1", ownerId = "1" });
            onwer.accounts.Add(new Account() { accountType = "Saving", dateCreated = DateTime.Now, id = "1", ownerId = "1" });

            return onwer;
        }

        [HttpGet]
        [Route("{id}")]
        public Owner Get(int id)
        {
            Owner onwer = GetOnwers().Where(i => i.id == id.ToString()).FirstOrDefault();
            onwer.accounts = new List<Account>();
            onwer.accounts.Add(new Account() { accountType = "Domestic", dateCreated = DateTime.Now, id = "1", ownerId = "1" });
            onwer.accounts.Add(new Account() { accountType = "International", dateCreated = DateTime.Now, id = "1", ownerId = "1" });
            onwer.accounts.Add(new Account() { accountType = "Saving", dateCreated = DateTime.Now, id = "1", ownerId = "1" });

            return onwer;
        }

        [HttpPost, Authorize]
        public IActionResult Post([FromBody]Owner obj)
        {
            return Ok();
        }
        
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id,[FromBody]Owner obj)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}