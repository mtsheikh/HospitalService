using System.Collections.Generic;
using HospitalService.Models;

namespace HospitalService.Abstractions
{
    public interface IHospitalRepository
    {
        hospital GetHospital(int hospitalId);
        IEnumerable<hospital> GetHospitals();
        void AddHospital(hospital hospital);
        bool DeleteHospital(int hospitalId);
        bool UpdateHospital(int hospitalId, hospital hospital);
    }
}
