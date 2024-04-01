using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repository;


namespace BuiHuuPhuc.Controllers
{
    public class SinhVienController : Controller
    {
        AllRepository<SinhVien> repo;
        HuhuContext context;
        public SinhVienController()
        {
            context = new HuhuContext();
            repo = new AllRepository<SinhVien>(context, context.SinhViens);
        }
        public IActionResult Index()
        {
            var a = repo.GetAll();
            return View(a);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SinhVien singVien)
        {
            singVien.Id = Guid.NewGuid();
            repo.CreateObj(singVien);
            return RedirectToAction("Index");
        }
        public IActionResult Update(Guid id)
        {
            var singVien = repo.GetByID(id);
            return View(singVien);
        }
        [HttpPost]
        public IActionResult Update(SinhVien singVien)
        {
            repo.UpdateObj(singVien);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var singVien = repo.GetByID(id);
            repo.DeleteObj(singVien);
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            var singVien = repo.GetByID(id);
            return View(singVien);
        }

    }
}
