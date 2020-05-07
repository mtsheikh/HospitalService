using System.Collections.Generic;
using System.Linq;
using HospitalService.Abstractions;
using HospitalService.Models;

namespace HospitalService.Services
{
    public class MockHospitalService : IHospitalRepository
    {
        private List<hospital> _hospitals = new List<hospital>();
        public hospital GetHospital(int hospitalId)
        {
            return _hospitals.FirstOrDefault<hospital>(h => h.Id == hospitalId);
        }

        public IEnumerable<hospital> GetHospitals()
        {
            return _hospitals;
        }

        public void AddHospital(hospital hospital)
        {
            _hospitals.Add(hospital);
        }

        public bool DeleteHospital(int hospitalId)
        {
            var hospitalToRemove = _hospitals.FirstOrDefault<hospital>(h => h.Id == hospitalId);

            if (hospitalToRemove == null) return false;
            _hospitals.Remove(hospitalToRemove);
            return true;
        }

        public bool UpdateHospital(int hospitalId, hospital hospital)
        {
            var hospitalToUpdate = _hospitals.FirstOrDefault<hospital>(h => h.Id == hospitalId);
            if (hospitalToUpdate == null) return false;
            _hospitals[_hospitals.IndexOf(hospitalToUpdate)] = hospital;
            return true;
        }
    }
}