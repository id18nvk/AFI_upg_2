﻿using Microsoft.AspNetCore.Mvc;
using PrenumerantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFI_upg_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1kzdksdnkkkskn", "value2" };
        }

        //--------------- GET PRENUMERANT -----------------
        // get api/<valuescontroller>/5
        [HttpGet("{id}")]
        public PrenumerantDetails getPrenumerant(int id)
        {
            _ = new PrenumerantDetails();
            PrenumerantMethods pm = new PrenumerantMethods();

            PrenumerantDetails pd = pm.GetPrenumerant(id, out string errormsg);


            return pd;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //--------------- UPDATE PRENUMERANT -----------------
        // PUT api/<ValuesController>
        [HttpPut]
        public void Put([FromBody] PrenumerantDetails pd)
        {
            PrenumerantMethods pm = new PrenumerantMethods();
            pm.UpdatePrenumerant(pd, out string errormsg);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
