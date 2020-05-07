using System.Collections.Generic;
using System.Data;
using Dapper.FastCrud;
using HospitalService.Abstractions;
using HospitalService.Models;

namespace HospitalService.Services
{
    public class HospitalRepository : IHospitalRepository
    {
        private IDbConnection _dbConnection;

        public HospitalRepository(IDbConnection dbConnection) => 
            _dbConnection = dbConnection;

        public hospital GetHospital(int hospitalId) => 
            _dbConnection.Get(new hospital { Id = hospitalId });

        public IEnumerable<hospital> GetHospitals() => 
            _dbConnection.Find<hospital>();

        public void AddHospital(hospital hospital) => 
            _dbConnection.Insert(hospital);

        public bool DeleteHospital(int hospitalId) =>
            _dbConnection.Get(new hospital {Id = hospitalId}) != null &&
            _dbConnection.Delete(entityToDelete: new hospital() {Id = hospitalId});

        public bool UpdateHospital(int hospitalId, hospital hospital) =>
            _dbConnection.Get(new hospital {Id = hospitalId}) != null &&
            _dbConnection.Update(hospital);
    }
}