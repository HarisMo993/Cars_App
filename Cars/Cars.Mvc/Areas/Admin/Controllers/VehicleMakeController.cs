using AutoMapper;
using Cars.Application.ViewModels;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleMakeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleMakeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: VehicleMakeController
        public async Task<ActionResult> Index()
        {
            var vehicleMakes = await _unitOfWork.VehicleMake.FindAll();

            var model = _mapper.Map<List<VehicleMake>, List<VehicleMakeViewModel>>(vehicleMakes.ToList());
            return View(model);
        }

        // GET: VehicleMakeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.VehicleMake.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }

            var vehicleMake = await _unitOfWork.VehicleMake.Find(q => q.Id == id);

            var model = _mapper.Map<VehicleMakeViewModel>(vehicleMake);
            return View(model);
        }

        // GET: VehicleMakeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleMakeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var vehicleMake = _mapper.Map<VehicleMake>(model);
                await _unitOfWork.VehicleMake.Create(vehicleMake);
                await _unitOfWork.Save();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: VehicleMakeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.VehicleMake.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }

            var vehicleMake = await _unitOfWork.VehicleMake.Find(q => q.Id == id);
            var model = _mapper.Map<VehicleMakeViewModel>(vehicleMake);
            return View(model);
        }

        // POST: VehicleMakeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VehicleMakeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var vehicleMake = _mapper.Map<VehicleMake>(model);

                _unitOfWork.VehicleMake.Update(vehicleMake);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View();
            }
        }

        // GET: VehicleMakeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var vehicleMake = await _unitOfWork.VehicleMake.Find(q => q.Id == id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            _unitOfWork.VehicleMake.Delete(vehicleMake);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        // POST: VehicleMakeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, VehicleMakeViewModel model)
        {
            try
            {
                var vehicleMake = await _unitOfWork.VehicleMake.Find(q => q.Id == id);

                if (vehicleMake == null)
                {
                    return NotFound();
                }

                _unitOfWork.VehicleMake.Delete(vehicleMake);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
