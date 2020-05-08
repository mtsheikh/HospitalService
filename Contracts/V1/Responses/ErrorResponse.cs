using System.Collections.Generic;

namespace HospitalService.Contracts.V1.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; }
    }
}