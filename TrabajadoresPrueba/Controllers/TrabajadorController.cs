using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabajadoresPrueba.Models;
using TrabajadoresPrueba.Repositories.Abstract;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly ITrabajadorService _trabajadorService;
        private readonly ILocationService _locationService;

        public TrabajadorController(ITrabajadorService trabajadorService, ILocationService locationService)
        {
            _trabajadorService = trabajadorService;
            _locationService = locationService;
        }

        public async Task<IActionResult> TrabajadorList(string gender)
        {
            var trabajadores = await _trabajadorService.GetList(gender);
            return View(trabajadores);
        }

        public async Task<IActionResult> FilterByGender(string gender)
        {
            var productos = await _trabajadorService.GetList(gender);
            return Ok(productos);
        }

        public async Task<IActionResult> Add()
        {
            var trabajador = new TrabajadorModel();

            var departamentos = await _locationService.DepartamentoList();
            ViewBag.departamentos = departamentos
                .Select(c => new SelectListItem { Text = c.NombreDepartamento, Value = c.Id.ToString() });

            var provincias = await _locationService.ProvinciaList();
            ViewBag.provincias = provincias
                .Select(c => new SelectListItem { Text = c.NombreProvincia, Value = c.Id.ToString() });

            var distritos = await _locationService.DistritoList();
            ViewBag.distritos = distritos
                .Select(c => new SelectListItem { Text = c.NombreDistrito, Value = c.Id.ToString() });

            return PartialView("_AddTrabajador", trabajador);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TrabajadorModel entity)
        {
            var departamentos = await _locationService.DepartamentoList();
            ViewBag.departamentos = departamentos
                .Select(c => new SelectListItem { Text = c.NombreDepartamento, Value = c.Id.ToString() });

            var provincias = await _locationService.ProvinciaList();
            ViewBag.provincias = provincias
                .Select(c => new SelectListItem { Text = c.NombreProvincia, Value = c.Id.ToString() });

            var distritos = await _locationService.DistritoList();
            ViewBag.distritos = distritos
                .Select(c => new SelectListItem { Text = c.NombreDistrito, Value = c.Id.ToString() });

            if (!ModelState.IsValid)
            {
                return PartialView("_AddTrabajador", entity);
            }

            var result = await _trabajadorService.Add(entity);
            if (result > 0)
            {
                TempData["msg"] = "Se agrego el trabajador exitosamente";
                return Json(new { success = true });
                return RedirectToAction(nameof(TrabajadorList));
            }

            TempData["msg"] = "Errores guardando el trabajador";
            return PartialView("_AddTrabajador", entity);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var trabajador = await _trabajadorService.GetById(id);
            var departamentos = await _locationService.DepartamentoList();
            ViewBag.departamentos = departamentos
                .Select(c => new SelectListItem { Text = c.NombreDepartamento, Value = c.Id.ToString(), Selected= (c.Id == trabajador.IdDepartamento) });

            var provincias = await _locationService.ProvinciaList();
            ViewBag.provincias = provincias
                .Select(c => new SelectListItem { Text = c.NombreProvincia, Value = c.Id.ToString(), Selected = (c.Id == trabajador.IdProvincia) });

            var distritos = await _locationService.DistritoList();
            ViewBag.distritos = distritos
                .Select(c => new SelectListItem { Text = c.NombreDistrito, Value = c.Id.ToString(), Selected = (c.Id == trabajador.IdDistrito) });

            return PartialView("_EditTrabajador", trabajador);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TrabajadorModel entity)
        {
            var departamentos = await _locationService.DepartamentoList();
            ViewBag.departamentos = departamentos
                .Select(c => new SelectListItem { Text = c.NombreDepartamento, Value = c.Id.ToString(), Selected = (c.Id == entity.IdDepartamento) });

            var provincias = await _locationService.ProvinciaList();
            ViewBag.provincias = provincias
                .Select(c => new SelectListItem { Text = c.NombreProvincia, Value = c.Id.ToString(), Selected = (c.Id == entity.IdProvincia) });

            var distritos = await _locationService.DistritoList();
            ViewBag.distritos = distritos
                .Select(c => new SelectListItem { Text = c.NombreDistrito, Value = c.Id.ToString(), Selected = (c.Id == entity.IdDistrito) });

            if (!ModelState.IsValid)
            {
                return PartialView("_EditTrabajador", entity);
            }

            var result = await _trabajadorService.Update(entity);
            if (result > 0)
            {
                TempData["msg"] = "Se actualizo exitosamente el trabajador";
                return RedirectToAction(nameof(TrabajadorList));
            }

            TempData["msg"] = "Errores, no se pudo actualizar el trabajador";
            return PartialView("_EditTrabajador", entity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _trabajadorService.Delete(id);
            return RedirectToAction(nameof(TrabajadorList));
        }
    }
}
