using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;
using Extensions.Base;
using Microsoft.AspNetCore.Authorization;
using PersonRecommendedDietaryIntake = DAL.App.DTO.PersonRecommendedDietaryIntake;

namespace WebApp.Controllers
{
    [Authorize(Roles = "customer" )]
    public class PersonRecommendedDietaryIntakeController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PersonRecommendedDietaryIntakeController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PersonRecommendedDietaryIntake
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PersonRecommendedDietaryIntake.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: PersonRecommendedDietaryIntake/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personRecommendedDietaryIntake = await _uow.PersonRecommendedDietaryIntake.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personRecommendedDietaryIntake == null)
            {
                return NotFound();
            }

            return View(personRecommendedDietaryIntake);
        }

        // GET: PersonRecommendedDietaryIntake/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            ViewData["HealthSpecificationNutrientId"] = new SelectList(await _uow.HealthSpecificationNutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Comment");
            ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            ViewData["RecommendedDietaryIntakeId"] = new SelectList(await _uow.RecommendedDietaryIntake.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            return View();
        }

        // POST: PersonRecommendedDietaryIntake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DAL.App.DTO.PersonRecommendedDietaryIntake personRecommendedDietaryIntake)
        {
            if (ModelState.IsValid)
            {
                _uow.PersonRecommendedDietaryIntake.Add(personRecommendedDietaryIntake);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", personRecommendedDietaryIntake.AppUserId);
            ViewData["HealthSpecificationNutrientId"] = new SelectList(await _uow.HealthSpecificationNutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Comment");
            ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            ViewData["RecommendedDietaryIntakeId"] = new SelectList(await _uow.RecommendedDietaryIntake.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            return View(personRecommendedDietaryIntake);
        }

        // GET: PersonRecommendedDietaryIntake/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personRecommendedDietaryIntake = await _uow.PersonRecommendedDietaryIntake.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);
            if (personRecommendedDietaryIntake == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", personRecommendedDietaryIntake.AppUserId);
            ViewData["HealthSpecificationNutrientId"] = new SelectList(await _uow.HealthSpecificationNutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Comment");
            ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            ViewData["RecommendedDietaryIntakeId"] = new SelectList(await _uow.RecommendedDietaryIntake.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            return View(personRecommendedDietaryIntake);
        }

        // POST: PersonRecommendedDietaryIntake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PersonRecommendedDietaryIntake personRecommendedDietaryIntake)
        {
            if (id != personRecommendedDietaryIntake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.PersonRecommendedDietaryIntake.Update(personRecommendedDietaryIntake);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await PersonRecommendedDietaryIntakeExists(personRecommendedDietaryIntake.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", personRecommendedDietaryIntake.AppUserId);
            ViewData["HealthSpecificationNutrientId"] = new SelectList(await _uow.HealthSpecificationNutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Comment");
            ViewData["NutrientId"] = new SelectList(await _uow.Nutrients.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            ViewData["RecommendedDietaryIntakeId"] = new SelectList(await _uow.RecommendedDietaryIntake.GetAllAsync(User.GetUserId()!.Value), "Id", "Id");
            return View(personRecommendedDietaryIntake);
        }

        // GET: PersonRecommendedDietaryIntake/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personRecommendedDietaryIntake = await _uow.PersonRecommendedDietaryIntake.FirstOrDefaultAsync(id.Value,User.GetUserId()!.Value);

            if (personRecommendedDietaryIntake == null)
            {
                return NotFound();
            }

            return View(personRecommendedDietaryIntake);
        }

        // POST: PersonRecommendedDietaryIntake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PersonRecommendedDietaryIntake.RemoveAsync(id,User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonRecommendedDietaryIntakeExists(Guid id)
        {
            return await _uow.PersonRecommendedDietaryIntake.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
