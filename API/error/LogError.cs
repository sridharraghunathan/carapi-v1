using System.Threading.Tasks;
using Infrastructure.CarModels;

namespace API.error
{
    public class LogError
    {
        private readonly CarStoresDBContext _context;
        public LogError(CarStoresDBContext context)
        
        {
            _context = context;

        }
        public static Task LogToDB()
        {
            // Add the code to Database to Log the error 
            // Id, statuscode ,message,staketrace,errors,createTS
            return Task.Run(() => null);
        }

    }
}