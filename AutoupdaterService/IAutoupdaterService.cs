using System;
using System.ServiceModel;
using AutoupdaterService.Entities;

namespace AutoupdaterService
{
    [ServiceContract]
    public interface IAutoupdaterService
    {
        [OperationContract]
        UpdateResponse UpdateApplication(string applicationId);

        [OperationContract]
        bool HasUpdates(string applicationId, Version version);
    }
}