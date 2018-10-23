using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModuleCheckingTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var checkingServiceClient = new ServiceReference1.ModulusCheckingServiceClient())
            {
                var modulusCheck =  checkingServiceClient.GetCheckModulus("089999", "66374958");
            }
            
        }
    }
}
