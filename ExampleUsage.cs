using ValidationTool;
namespace ValidationExample
{
	public class ExampleUsage
	{
        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            ExampleDTO exampleDTO = new ExampleDTO();
            try
            {
                ValidationHelper.ValidateDTOIsNullOrEmpty(exampleDTO);
                
                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
            }
        }
    }
}

