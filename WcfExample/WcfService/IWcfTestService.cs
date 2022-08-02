using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface IWcfTestService
    {
        [OperationContract]
        object TestService(object param);

    }
}
