using Domain.DTO.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITicketRepository :IGenericRepository<Ticket>
    {
        List<Ticket> GetTickets(GetTicketsRequest request);
    }
}
