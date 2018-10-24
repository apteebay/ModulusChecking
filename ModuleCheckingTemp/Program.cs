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
