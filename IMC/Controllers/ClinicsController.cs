using IMC.Domain.DomainModels;
using IMC.Domain.Interfaces;
using IMC.Domain.Repositries;
using IMC.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IMC.Controllers
{
    public class ClinicsController : Controller
    {

        private UnitOfWork<IMCDbContext> unitOfWork = new UnitOfWork<IMCDbContext>();
        //private GenericRepository<Clinic> repository;
        private IClinicRepositry clinicRepository;
        public ClinicsController()
        {
            //If you want to use Generic Repository with Unit of work
            //repository = new GenericRepository<Clinic>(unitOfWork);
            //If you want to use Specific Repository with Unit of work
            clinicRepository = new ClinicRepositry(unitOfWork);
        }

        // GET: Clinics
        public ActionResult Index()
        {
            var result = clinicRepository.GetAll();
            return View(result);
        }

        // GET: Clinics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = clinicRepository.GetById(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // GET: Clinics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FlowerNumber")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.CreateTransaction();
                    clinicRepository.Insert(clinic);
                    unitOfWork.Save();
                    unitOfWork.Commit();

                }catch(Exception e)
                {
                    unitOfWork.Rollback();
                }
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: Clinics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = clinicRepository.GetById(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FlowerNumber")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.CreateTransaction();
                    clinicRepository.Update(clinic);
                    unitOfWork.Save();
                    unitOfWork.Commit();

                }catch(Exception e)
                {
                    unitOfWork.Rollback();
                }
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: Clinics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = clinicRepository.GetById(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                unitOfWork.CreateTransaction();
                Clinic clinic=clinicRepository.GetById(id);
                if (clinic == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                clinicRepository.Delete(clinic);
                unitOfWork.Save();
                unitOfWork.Commit();
            }catch(Exception e)
            {
                unitOfWork.Rollback();
            }
            return RedirectToAction("Index");
        }

        
    }
}
