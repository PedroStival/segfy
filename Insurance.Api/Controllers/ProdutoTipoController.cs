using System;
using System.Web.Http;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Services;
using Microsoft.Practices.Unity;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/produtotipo")]
    public class ProdutoTipoController : ApiController
    {
        [Dependency]
        public IProdutoTipoService _service { get; set; }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var seguros = _service.All();
                return Ok(seguros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

   
    }
}