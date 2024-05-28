using eTikects.Data;
using eTikects.Data.Base;
using eTikects.Models;

namespace eTikects.Services
{
    public class ProducersService: EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) 
        {
        
        }

    }
}
