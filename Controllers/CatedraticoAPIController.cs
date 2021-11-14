using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class CatedraticoAPIController : ApiController
    {
        ExamenEntities bd = new ExamenEntities();

        public IHttpActionResult getCatedratico()
        {
            var result = bd.P_CATEDRATICO(0,"","","","","Get").ToList();
            return Ok(result);
        }


        public IHttpActionResult InsertCatedratico(catedratico ca)
        {
            var insertCli = bd.P_CATEDRATICO(0,ca.NOMBRE,ca.APELLIDOS,ca.DPI,ca.ACTIVO, "Insert").ToList();
            return Ok(insertCli);
        }

        public IHttpActionResult getCatedraticoId(int id)
        {
            var aldetail = bd.P_CATEDRATICO(id, "", "", "","", "GetId").Select(x => new CatedraticoClass()
            {
                Id = x.ID,
                Nombre = x.NOMBRE,
                Apellidos = x.APELLIDOS,
                Dpi = x.DPI,
                Activo = x.ACTIVO
            }).FirstOrDefault<CatedraticoClass>();
            return Ok(aldetail);
        }

        public IHttpActionResult Put(CatedraticoClass al)
        {
            var updateal = bd.P_CATEDRATICO(al.Id, al.Nombre, al.Apellidos, al.Dpi, al.Activo, "Update").ToList();
            return Ok(updateal);
        }
        public IHttpActionResult Delete(int id)
        {
            var deletetemp = bd.P_CATEDRATICO(id, "", "", "","", "Delete").Select(x => new CatedraticoClass()
            {
                Id = x.ID,
                Nombre = x.NOMBRE,
                Apellidos = x.APELLIDOS,
                Dpi = x.DPI,
                Activo = x.ACTIVO

            }).FirstOrDefault<CatedraticoClass>();

            bd.SaveChanges();
            return Ok();
        }
    }
}
