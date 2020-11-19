using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;
using TesteSoftDesign.ViewModels;

namespace TesteSoftDesign.WebAPI.ControllersApi
{
    public abstract class AbstractController<TEntity, TEntityViewModel> : ApiController where TEntity : AbstractEntity where TEntityViewModel : AbstractViewModel
    {
        private readonly IService<TEntity> _service;
        private readonly IMapper _mapper;

        public AbstractController(IService<TEntity> service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public virtual IHttpActionResult GetAll()
        {
            var list = this._service.GetAll();
            var listVM = this._mapper.Map<List<TEntityViewModel>>(list);
            return Ok(listVM);
        }


        public IHttpActionResult GetById(int id)
        {
            var obj = this._service.GetById(id);
            var objVM = this._mapper.Map<TEntityViewModel>(obj);

            return Ok(objVM);
        }

        [HttpPost]
        public virtual IHttpActionResult Post(TEntity obj)
        {
            this._service.Add(obj);
            return Ok(new
            {
                message = "Inserido com sucesso"
            });
        }

        [HttpPut]
        public virtual IHttpActionResult Put([FromBody] TEntity obj)
        {
            var response = this._service.Update(obj);
            var responseVM = this._mapper.Map<TEntityViewModel>(response);
            return Ok(responseVM);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(int id)
        {
            try
            {
                this._service.Remove(id);
                return Ok(new
                {
                    message = "Removido com sucesso"
                });
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}