using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using APIforVisualRiders.Data.Context;
using APIforVisualRiders.Data.Models;

namespace APIforVisualRiders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly APIForVisualRidersContext _context;
        public BranchController(APIForVisualRidersContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBranch")]
        public IEnumerable<Branch> GetBranchList()
        {
            return (IEnumerable<Branch>)NoContent();
        }
    }
}