using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ConsultaActivoAPIController : ApiController
    {
        ExamenEntities bd = new ExamenEntities();

        public IHttpActionResult getConsultaActivo()
        {
            List<CURSO> lcurso = bd.CURSO.ToList();
            List<catedratico> lCATEDRATICO = bd.catedratico.ToList();



            var query = from c in lcurso
                        join a in lCATEDRATICO on c.ID_CATEDRATICO equals a.ID into t1
                        from a in t1.Where(x => x.ACTIVO.StartsWith("ACTIVO"))

                        select new CatedraticosActClass { getcurso = c, getCATEDRATICO = a };
            return Ok(query);
        }
    }
}
