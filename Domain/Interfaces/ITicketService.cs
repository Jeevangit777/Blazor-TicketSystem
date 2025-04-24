using Domain.DTO.Request;
using Domain.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketService
    {
        List<GetTicketResponse> GetTickets(GetTicketsRequest request);
        GetTicketResponse FindTicket(int ticketId);
    }
}
