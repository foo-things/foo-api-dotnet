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
    [Route("tots")]
    [ApiController]
    public class ThingsAndOtherThingsController : ControllerBase
    {
        private FooDbContext context;
        private ILogger logger;

        public ThingsAndOtherThingsController(FooDbContext context, ILogger<ThingsAndOtherThingsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET tots
        [HttpGet]
        public ActionResult<IEnumerable<Object>> Get()
        {
            return Ok((
                from thing in this.context.Things
                from otherThing in this.context.OtherThings.Where(otherThingy => otherThingy.ThingID == thing.ID).DefaultIfEmpty()
                select new
                {
                    thingId = thing.ID,
                    thingName = thing.Name,
                    otherThingId = otherThing != null ? (int?)otherThing.ID : null,
                    otherThingName = otherThing != null ? otherThing.Name : null
                }
            ).AsEnumerable());

            /*
             * Inner join instead of left join
            return Ok((
                from thing in this.context.Things
                join otherThing in this.context.OtherThings on thing.ID equals otherThing.ThingID
                select new {
                    thingId = thing.ID,
                    thingName = thing.Name,
                    otherThingId = otherThing.ID,
                    otherThingName = otherThing.Name
                }
            ).AsEnumerable());
            */
        }
    }
}
