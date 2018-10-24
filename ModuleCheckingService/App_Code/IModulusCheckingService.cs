using System.ServiceModel;
using System.ServiceModel.Web;

using ModulusCheckingBL;

[ServiceContract]
public interface IModulusCheckingService
{

	[OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    SortCodeModulus GetCheckModulus(string sortCode, string accountNumber);

}

