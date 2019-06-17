using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FooApi.Entities;
using FooApi.Services;
using Microsoft.Extensions.Logging;

namespace FooApi.Controllers
{
    [Route("things")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private FooDbContext context;
        private ILogger logger;

        public ThingsController(FooDbContext context, ILogger<ThingsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET things
        [HttpGet]
        public ActionResult<IEnumerable<Thing>> Get()
        {
            return Ok(this.context.Things);
        }

        // GET things/5
        [HttpGet("{id}")]
        public ActionResult<Thing> Get(int id)
        {
            var thing = this.context.Things.SingleOrDefault(x => x.ID == id);
            if (thing != null)
            {
                return Ok(thing);
            }
            return NotFound();
        }

        // POST things
        [HttpPost]
        public ActionResult<Thing> Post([FromBody] Thing thing)
        {
            this.context.Things.Add(thing);
            this.context.SaveChanges();
            return Ok(thing);
        }

        // PUT things/5
        [HttpPut("{id}")]
        public ActionResult<Thing> Put(int id, [FromBody] Thing putThing)
        {
            var thing = this.context.Things.SingleOrDefault(x => x.ID == id);
            if (thing != null)
            {
                thing.Name = putThing.Name;
                this.context.SaveChanges();
                return Ok(thing);
            }
            return NotFound();
        }

        // DELETE things/5
        [HttpDelete("{id}")]
        public ActionResult<Thing> Delete(int id)
        {
            var thing = this.context.Things.SingleOrDefault(x => x.ID == id);
            if (thing != null)
            {
                this.context.Remove(thing);
                this.context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
