using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModulusCheckingBL;

[ServiceContract]
public interface IModulusCheckingService
{

	[OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    SortCodeModulus GetCheckModulus(string sortCode, string accountNumber);

}

