using MyDailyDairy.Data.EF;
using MyDailyDiary.Repository.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Uow.Package.Data;
using Uow.Package.Data.Repositories;

namespace MyDailyDairy.UI.Controllers
{
    public class RoleModel
    {
        public string RoleName { get; set; }
    }
    public class MyDiaryController : ApiController
    {
        private IUnitOfWork _unit;

        public MyDiaryController()
        {
            _unit = new UnitOfWork();
        }

        public object Get()
        {
            return _unit.Roles.GetAll().Select(x => new { x.RoleName, x.IsActive });
        }


        // POST api/values
        public HttpResponseMessage Post([FromBody]RoleModel role)
        {
            try 
            {
                var objNewRole = new Role();

                if(!string.IsNullOrWhiteSpace(role.RoleName))
                {
                    objNewRole.RoleName = role.RoleName;
                    _unit.Roles.Create(objNewRole);
                    _unit.Commit();
                }

                return Request.CreateResponse(HttpStatusCode.Created,role);
            
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }


    }
}
