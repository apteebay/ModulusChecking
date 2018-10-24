
using ModulusCheckingBL;

public class ModulusCheckingService : IModulusCheckingService
{
	public SortCodeModulus GetCheckModulus(string sortCode, string accountNumber)
    {
        return SortCodeModulus.Get(sortCode, accountNumber);
	}

}
