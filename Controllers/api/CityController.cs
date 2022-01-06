using LinqToSql_CityApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LinqToSql_CityApplication.Controllers.api
{
    public class CityController : ApiController
    {
        static string connectionString = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=CityDB;Integrated Security=True;Pooling=False";
        static CityClassesDataContext context = new CityClassesDataContext(connectionString);
        // GET: api/City
        public IHttpActionResult Get()
        {
            try
            {
                List<Citizen> citizensList = new List<Citizen>();
                foreach(var item in context.Citizens)
                {
                   Citizen citizen = new Citizen();
                   citizen.Id = item.Id;
                   citizen.FirstName = item.FirstName;
                   citizen.LastName = item.LastName;
                   citizen.DateOfBirth = item.DateOfBirth;
                   citizen.Address = item.Address;
                   citizen.SeniorityInCity = item.SeniorityInCity;
                  citizensList.Add(citizen);
                }
                return Ok(citizensList);
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        // GET: api/City/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(context.Citizens.First(item => item.Id == id));
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception)
            {
                return Ok("not exist in system");
            }

        }

        // POST: api/City
        public IHttpActionResult Post([FromBody]Citizen citizen)
        {
            try
            {
                context.Citizens.InsertOnSubmit(citizen);
                context.SubmitChanges();
                return Ok(citizen);
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        // PUT: api/City/5
        public IHttpActionResult Put(int id, [FromBody]Citizen citizen)
        {
            try
            {
                 Citizen GetById = context.Citizens.First(item => item.Id == id);
                 GetById.FirstName = citizen.FirstName;
                 GetById.LastName = citizen.LastName;
                 GetById.DateOfBirth = citizen.DateOfBirth;
                 GetById.Address = citizen.Address;
                 GetById.SeniorityInCity = citizen.SeniorityInCity;
                 context.SubmitChanges();
                 return Ok(GetById);
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception)
            {
                return Ok("not exist in system");
            }
        }

        // DELETE: api/City/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Citizen citizen = context.Citizens.First(item => item.Id == id);
                context.Citizens.DeleteOnSubmit(citizen);
                context.SubmitChanges();
                return Ok(citizen);
            }
            catch(SqlException ex)
            {
                return Ok(ex.Message);
            })
            {
                return Ok("not exist in system");
            }
        }
    }
}
