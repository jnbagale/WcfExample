using System.ServiceModel;

namespace WcfService
{
    //[ServiceContract(CallbackContract = typeof(IContractCallback))]
    [ServiceContract]
    public interface IWcfTestService
    {
        [OperationContract]
        object TestService(object param); // Used to test if the wcf service is ready

    }

    //public interface IContractCallback
    //{

    //}

}
