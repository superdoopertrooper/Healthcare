using JokeCategory;
using Hospital.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hospital.WebAPI.Controllers
{
    public class ClinicController : ApiController
    {

        /// <summary>
        /// OkResult
        /// NotFoundResult
        /// ExceptionResult
        /// UnauthorizedResult
        /// BadRequestResult
        /// ConflictResult
        /// REdirectResult
        /// InvalidModelStateResult
        /// </summary>


        ClinicService clinicService = new  ClinicService();
        ClinicRepository _clinicRepository = new ClinicRepository();

        public IHttpActionResult Get()
        {

            
            ClinicViewModel clinicViewModel = new ClinicViewModel() { Id=4, Name= "Bright Smiles" } ;
            

            return Ok(clinicViewModel);
        }


        public IHttpActionResult Get(int id)
        {
            var clinic = true; //_clinicRepository.FindOneById(id);

            if (clinic==false)
            {
                return NotFound();
            }
            else
            {
                ClinicViewModel clinicViewModel = new ClinicViewModel() { Id = id, Name = "Bright Smiles" };
                
                return Ok(clinicViewModel);
            }
        }

        /// <summary>
        /// Lists Employees
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/clinic/{id}/employees")]
        public IHttpActionResult GetEmployees(int id)
        {
            var clinic = true; //_clinicRepository.FindOneById(id);

            if (clinic == false)
            {
                return NotFound();
            }
            else
            {
                Employee employee = new Employee() {  Id=69, Name="Employee1" };

                return Ok(employee);
            }
        }


        /// <summary>
        ///    content-type: application/json
        ///    {        "Id": 1,"Name": "2"
        ///    </summary>
        /// <param name="clinicViewModel"></param>
        /// <returns></returns>
        public IHttpActionResult Post(ClinicViewModel clinicViewModel)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }

        public IHttpActionResult Put()
        {
            return Ok();
        }
        public IHttpActionResult Delete()
        {
            return Ok();
        }

    }
}
