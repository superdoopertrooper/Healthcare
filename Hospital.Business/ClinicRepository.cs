using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeCategory
{
    public class ClinicRepository
    {
        public bool FindOneById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Clinic> GetAll()
        {
            Clinic clinic = new Clinic { Id=1, Name="Clinic1" };

            List<Clinic> clinics = new List<Clinic>();
            clinics.Add(clinic);

            return clinics;
            
        }
    }
}
