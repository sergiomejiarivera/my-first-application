﻿using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class AlumnoController : Controller
    {
        private object db;

        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                using (var db = new alumnosdbContext())
                {
                    //List<alumno> lista = db.alumno.Where(a => a.Edad > 18).ToList();
                    //return View((from alumnos in db.alumno
                    //    select new AlumnosCE()
                    //    {
                    //        Id = alumnos.Id,
                    //        Nombre = alumnos.Nombre,
                    //        Edad = alumnos.Edad,
                    //        Sexo = alumnos.Sexo,
                    //        CodCiudad = alumnos.CodCiudad,
                    //        FechaRegistro = alumnos.FechaRegistro

                    //    }).ToList());

                    return View(db.alumno.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(alumno a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new alumnosdbContext())
                {
                    a.FechaRegistro = DateTime.Now;
                    db.alumno.Add(a);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar Alumno.     " + ex.Message);
                return View();
            }
        }

        public ActionResult Agregar2()
        {
            return View();
        }

        public ActionResult ListaCiudades()
        {
            using (var db = new alumnosdbContext())
            {
                return PartialView(db.Ciudades.ToList());

            }
        }


        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new alumnosdbContext())
                {
                    //alumno al = db.alumno.Where(a => a.Id == id).FirstOrDefault();
                    alumno alu = db.alumno.Find(id);
                    return View(alu);
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(alumno a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new alumnosdbContext())
                {
                    alumno al = db.alumno.Find(a.Id);
                    al.Nombre = a.Nombre;
                    al.Apellido = a.Apellido;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;

                    al.CodCiudad = a.CodCiudad;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                throw;
            }


        }


        public ActionResult Detalles(int id)
        {
            using (var db = new alumnosdbContext())
            {
                alumno alu = db.alumno.Find(id);
                //var alu = from alumnos in db.alumno
                //          join Ciudad in db.Ciudades on alumnos.CodCiudad equals Ciudad.Id
                //          select new AlumnosCE()
                //          {
                //              Id = alumnos.Id,
                //              Nombre = alumnos.Nombre,
                //              Edad = alumnos.Edad,
                //              Sexo = alumnos.Sexo,
                //              NombreCiudad = Ciudad.Nombre

                //          };

                return View(alu);
            }

        }

        public ActionResult Eliminaralumno(int id)
        {
            using (var db = new alumnosdbContext())
            {
                alumno alu = db.alumno.Find(id);
                db.alumno.Remove(alu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public static string NombreCiudad(int Codciudad)
        {
            using (var db = new alumnosdbContext())
            {
                return db.Ciudades.Find(Codciudad).Nombre;
            }
        }




    }



}
