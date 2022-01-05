using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> getUsers(){
            return await _context.Users.ToListAsync();
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<AppUser>> GetUsers(){
        //     return _context.Users.ToList();
        // }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> getUser(int id){
            return await _context.Users.FindAsync(id);
        }

        // [HttpGet("{id}")]
        // public ActionResult<AppUser> GetUser(int id){
        //     return _context.Users.Find(id);
        // }
    }
}
