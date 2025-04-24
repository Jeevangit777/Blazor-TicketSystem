using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public GetTicketResponse FindTicket(int ticketId)
        {
            var result = unitOfWork.Repository<Ticket>().GetByIdAsync(ticketId);
            if (result == null) return null;
            return new GetTicketResponse
            {
                TicketID = result.TicketId,
                Summary = result.Summary,
                Description = result.Description,
                ProductId = result.ProductId,
                PriorityId = result.PriorityId,
                CategoryId = result.CategoryId,
                Status = result.Status,
                RaisedBy = result.User?.Email,
                CreatedDate = result.RaisedDate,
                ExpectedDate = result.ExpectedDate
            };
        }

        public List<GetTicketResponse> GetTickets(GetTicketsRequest request)
        {
            var result = unitOfWork.TicketRepository.GetTickets(request);
            return result.Select(x => new GetTicketResponse
            {
                TicketID = x.TicketId,
                Summary = x.Summary,
                Product = x.Product?.ProductName,
                Category = x.Category?.CategoryName,
                Priority = x.Priority?.PriorityName,
                Status = x.Status,
                RaisedBy = x.User?.Email,
                CreatedDate = x.RaisedDate,
                ExpectedDate = x.ExpectedDate
            }).ToList();
        }
    }
}
