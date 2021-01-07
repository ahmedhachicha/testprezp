using testprezp.Models;
using testprezp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testprezp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly IRequest request;
        public RequestController(IRequest request)
        {
            this.request = request;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Request>> Getrequest(int rid)
        {
            try
            {
                var result = await request.Getrequest(rid);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetAllRequests()
        {
            try
            {
                return Ok(await request.GetAllRequests());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Request>> CreateRequest([FromBody] Request requestt)
        {
            try
            {
                if (requestt == null)
                    return BadRequest();
                var createdRequest = await request.Addreq(requestt);
                return CreatedAtAction(nameof(Getrequest),
                new { id = createdRequest.rId }, createdRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
            }
        }
    }
}
