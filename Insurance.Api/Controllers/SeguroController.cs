using System;
using System.Web.Http;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Services;
using Microsoft.Practices.Unity;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("api/seguro")]
    public class SeguroController : ApiController
    {
        [Dependency]
        public ISeguroService _service { get; set; }

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

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(long id)
        {
            try
            {
                var seguro = _service.Get(id);

                if (seguro == null)
                {
                    throw new Exception("Não existe seguro com esse id");
                }
                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("searchPlaca/{placa}")]
        public IHttpActionResult SearchPlaca(string placa)
        {
            try
            {
                var seguros = _service.SearchPlaca(placa);
                return Ok(seguros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(Seguro seguro)
        {
            try
            {
                _service.Add(seguro);
                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(Seguro seguro)
        {
            try
            {
                _service.Update(seguro);
                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                var seguro = _service.Get(id);

                if (seguro == null)
                {
                    throw new Exception("Não existe seguro para deletar");
                }

                _service.Delete(seguro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}