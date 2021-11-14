using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class CursoAPIController : ApiController
    {

        ExamenEntities bd = new ExamenEntities();

        public IHttpActionResult getCurso()
        {
            var result = bd.P_CURSO(0, 0, "","","Get").ToList();
            return Ok(result);
        }


        public IHttpActionResult InsertCurso(CURSO cu)
        {
            var insertCli = bd.P_CURSO(0, cu.ID_CATEDRATICO, cu.NOMBRE, cu.APROVADO, "Insert").ToList();
            return Ok(insertCli);
        }

        public IHttpActionResult getCursoId(int id)
        {
            var aldetail = bd.P_CURSO(id, 0 , "", "", "GetId").Select(x => new CursoClass()
            {
                Id = x.ID,
                ID_CATEDRATICO = Convert.ToInt32(x.ID_CATEDRATICO),
                Nombre = x.NOMBRE,
                APROVADO = x.APROVADO
                
            }).FirstOrDefault<CursoClass>();
            return Ok(aldetail);
        }

        public IHttpActionResult Put(CursoClass CU)
        {
            var updateal = bd.P_CURSO(CU.Id, CU.ID_CATEDRATICO, CU.Nombre, CU.APROVADO, "Update").ToList();
            return Ok(updateal);
        }
        
    }
}
