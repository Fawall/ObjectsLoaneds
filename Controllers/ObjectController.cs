using Microsoft.AspNetCore.Mvc;
using ObjectsLoaneds.Data;
using Microsoft.EntityFrameworkCore;
using ObjectsLoaneds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectsLoaneds.Controllers
{
    public class ObjectController : Controller
    {
        private readonly Context _context;
        public ObjectController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ObjectsLoaneds.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ObjectsLoanedsModel objectsLoaneds) 
        {
            if (ModelState.IsValid) 
            {
                await _context.ObjectsLoaneds.AddAsync(objectsLoaneds);
                await _context.SaveChangesAsync();

                TempData["Sucesso"] = "O objeto foi adicionado com exito";

                return RedirectToAction("Index");           
            }
            return View(objectsLoaneds);
        
        
        }

    }
}
