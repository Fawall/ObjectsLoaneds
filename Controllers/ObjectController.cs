using Microsoft.AspNetCore.Mvc;
using ObjectsLoaneds.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using ObjectsLoaneds.Models;
using ObjectsLoaneds.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ObjectsLoaneds.Controllers
{
    public class ObjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        public ObjectController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var UserLogged =  User.FindFirstValue(ClaimTypes.NameIdentifier);
                       
            return View(await _context.ObjectsLoaneds.Where(x => x.UserId.Contains(UserLogged)).ToListAsync());            
        }
        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ObjectsLoanedModel objectsLoaneds) 
        {
            var currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            objectsLoaneds = new ObjectsLoanedModel 
            { 
              NameObjectLoaned = objectsLoaneds.NameObjectLoaned,
              NamePeopleLoaned = objectsLoaneds.NamePeopleLoaned,
              DateLoanedObject = objectsLoaneds.DateLoanedObject,
              LimitDate = objectsLoaneds.LimitDate,
              UserId = currentUser,

            };

            if (ModelState.IsValid) 
            {
                await _context.ObjectsLoaneds.AddAsync(objectsLoaneds);
                await _context.SaveChangesAsync();

                TempData["Sucesso"] = "O objeto foi adicionado com exito";

                return RedirectToAction("Index");           
            }
            return View(objectsLoaneds);
               
        }
        [Authorize]
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null) 
            { 
                return NotFound();
            }

            var objects = await _context.ObjectsLoaneds.FirstOrDefaultAsync(x => x.ObjectId == id);

            if (objects == null)
            {
                return NotFound();
            }

            return View(objects);             
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> DeleteConfirmed(int id) 
        { 
            var objectDelete = await _context.ObjectsLoaneds.FindAsync(id);

            _context.ObjectsLoaneds.Remove(objectDelete);           
            await _context.SaveChangesAsync();
                        
            return RedirectToAction("Index");
     
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? Id) 
        {
            if(Id == null) 
            {
                return NotFound();
            }

            var editObjects = await _context.ObjectsLoaneds.FirstOrDefaultAsync(x => x.ObjectId == Id);

            if(editObjects == null) 
            {
                return NotFound();
            }
            
            return View(editObjects);
                   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ObjectId, NamePeopleLoaned, NameObjectLoaned, DateLoanedObject, LimitDate, UserId")]
        ObjectsLoanedModel objectsLoaneds)
        {
            var currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            objectsLoaneds.UserId = currentUser;

            if (id != objectsLoaneds.ObjectId) 
            {
                return NotFound();
            }
            if (ModelState.IsValid) 
            { 
               
                _context.Update(objectsLoaneds);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("Index");

        }


    }
}
