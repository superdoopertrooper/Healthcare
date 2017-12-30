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

        public IHttpActionResult Get()
        {
            ClinicViewModel clinicViewModel = new ClinicViewModel();
            clinicViewModel.Id = 4;
            clinicViewModel.Name = "Bright Smiles";

            return Ok(clinicViewModel);
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
