using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Web.UI.WebControls;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultPacientes = BL.Paciente.GetAll();
            ML.Paciente paciente = new ML.Paciente();
            if (resultPacientes.Correct)
            {
                paciente.Pacientes = resultPacientes.Objects;
                return View(paciente);
            }
            else
            {
                ViewBag.Message = "No hay pacientes en la lista";
                return View(paciente);
            }
        }

        [HttpGet]
        public ActionResult Form(int? idPaciente)
        {
            ML.Result resultTipos = BL.TipoSangre.GetAll();
            ML.Paciente paciente = new ML.Paciente();
            paciente.TipoSangre = new ML.TipoSangre();
            paciente.TipoSangre.TiposSangre = new List<object>();
            paciente.TipoSangre.TiposSangre = resultTipos.Objects;
            if (idPaciente == null)
            {
                ViewBag.Titulo = "Agregar nuevo empleado";
                ViewBag.Accion = "Agregar";
                return View(paciente);
            }
            else
            {
                ViewBag.Titulo = "Modificar nuevo empleado";
                ViewBag.Accion = "Modificar";
                ML.Result resultPaciente = BL.Paciente.GetById(idPaciente.Value);
                if (resultPaciente.Correct)
                {
                    paciente = ((ML.Paciente)resultPaciente.Object);
                    paciente.TipoSangre.TiposSangre = new List<object>();
                    paciente.TipoSangre.TiposSangre = resultTipos.Objects;
                    return View(paciente);
                }
                else
                {
                    ViewBag.Message = "Paciente no encontrado";
                    return View("Modal");
                }
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Paciente paciente)
        {
            if (paciente.IdPaciente == 0)
            {
                ML.Result result = BL.Paciente.Add(paciente);
                if (result.Correct)
                {
                    ViewBag.Titulo = "¡REGISTRADO!";
                    ViewBag.Message = "Paciente registrado";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Titulo = "¡ERROR!";
                    ViewBag.Message = "No se pudo registrar";
                    return View("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Paciente.Update(paciente);
                if (result.Correct)
                {
                    ViewBag.Titulo = "¡MODIFICADO!";
                    ViewBag.Message = "Paciente modificado";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Titulo = "¡ERROR!";
                    ViewBag.Message = "No se pudo modificar";
                    return View("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int idPaciente)
        {
            ML.Result result = BL.Paciente.Delete(idPaciente);
            if (result.Correct)
            {
                ViewBag.Titulo = "¡ELIMINADO!";
                ViewBag.Message = "Paciente eliminado";
                return View("Modal");
            }
            else
            {
                ViewBag.Titulo = "¡ERROR!";
                ViewBag.Message = "No se pudo eliminar";
                return View("Modal");
            }
        }
    }
}