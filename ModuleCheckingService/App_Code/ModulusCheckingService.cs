using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using ModulusCheckingBL;

public class ModulusCheckingService : IModulusCheckingService
{
	public SortCodeModulus GetCheckModulus(string sortCode, string accountNumber)
    {
        return SortCodeModulus.Get(sortCode, accountNumber);
	}

}
