using eTikects.Data;
using eTikects.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using eTikects.Services;
using Microsoft.ServiceFabric.Actors;
using eTikects.Data.Base;

namespace eTikects.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context) : base(context) { }


    }
}