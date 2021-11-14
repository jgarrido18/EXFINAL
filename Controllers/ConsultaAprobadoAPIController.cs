using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ConsultaAprobadoAPIController : ApiController
    {
        ExamenEntities bd = new ExamenEntities();

        public IHttpActionResult getConsultaActivo()
        {
            List<CURSO> lcurso = bd.CURSO.ToList();
            List<catedratico> lCATEDRATICO = bd.catedratico.ToList();



            var query = from c in lcurso
                        join a in lcurso on c.ID equals a.ID_CATEDRATICO into t1
                        from a in t1.Where(x => x.APROVADO.StartsWith("S"))

                        select new AprobadoClass { getCURSO = a, };
            return Ok(query);
        }
    }
}
