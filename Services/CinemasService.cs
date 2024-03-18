using eTikects.Data;
using eTikects.Data.Base;
using eTikects.Models;

namespace eTikects.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {

        }
    }
}
