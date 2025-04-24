using Domain.Repositories;
using Domain.Entities;
using Domain.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDBContext dbContext) : base(dbContext)
        {
        }

        public List<Ticket> GetTickets(GetTicketsRequest request)
        {
            IQueryable<Ticket> query = dbContext.Set<Ticket>().Include(x => x.Category).Include(x => x.Priority).Include(x => x.Product).Include(x => x.User).Include(x => x.AssignedTo);
            if (request == null)
                return query.ToList();

            if (!string.IsNullOrEmpty(request.Summary))
            {
                query = query.Where(x => EF.Functions.Like(x.Summary, $"%{request.Summary}%"));
            }

            if (request.ProductId != null && request.ProductId.Count() > 0)
            {
                query = query.Where(x => request.ProductId.Contains(x.ProductId));
            }

            if (request.CategoryId != null && request.CategoryId.Count() > 0)
            {
                query = query.Where(x => request.CategoryId.Contains(x.CategoryId));
            }

            if (request.PriorityId != null && request.PriorityId.Count() > 0)
            {
                query = query.Where(x => request.PriorityId.Contains(x.PriorityId));
            }

            if (request.Status != null && request.Status.Count() > 0)
            {
                query = query.Where(x => request.Status.Contains(x.Status));
            }

            if (request.RaisedBy != null && request.RaisedBy.Count() > 0)
            {
                query = query.Where(x => request.RaisedBy.Contains(x.RaisedBy));
            }

            return query.OrderByDescending(x => x.RaisedDate).ToList();

        }
    }
}
