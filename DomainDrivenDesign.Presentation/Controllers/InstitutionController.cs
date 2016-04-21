using AutoMapper;
using DomainDrivenDesign.Application.Interfaces;
using DomainDrivenDesign.Domain.Models;
using DomainDrivenDesign.Presentation.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DomainDrivenDesign.Presentation.Controllers
{
    public class InstitutionController : BaseController
    {
        private readonly IInstitutionAppService institutionAppService;

        public InstitutionController(IInstitutionAppService institutionAppService)
        {
            this.institutionAppService = institutionAppService;
        }

        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<InstitutionViewModel>>(institutionAppService.GetAll()));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstitutionViewModel institution)
        {
            if (ModelState.IsValid)
            {
                institutionAppService.Save(Mapper.Map<InstitutionModel>(institution));

                return RedirectToAction("Index");
            }

            return View(institution);
        }

        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<InstitutionViewModel>(institutionAppService.GetById(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstitutionViewModel institution)
        {
            if (ModelState.IsValid)
            {
                institutionAppService.Update(Mapper.Map<InstitutionModel>(institution));

                return RedirectToAction("Index");
            }

            return View(institution);
        }

        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<InstitutionViewModel>(institutionAppService.GetById(id)));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            institutionAppService.Delete(institutionAppService.GetById(id));

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(Mapper.Map<InstitutionViewModel>(institutionAppService.GetById(id)));
        }
    }
}