using System.ServiceModel;
using AutoupdaterService.Entities;

namespace AutoupdaterService
{
    [ServiceContract]
    public interface IAutoupdaterService
    {
        [OperationContract]
        ServiceResponse UpdateApplication(string applicationId);
    }
}