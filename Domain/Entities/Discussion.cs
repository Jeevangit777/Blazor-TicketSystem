using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Discussion
    {
        public Discussion()
        {
            Attachments = new HashSet<Attachment>();
        }

        [Key]
        public int DiscussionId { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(Ticket))]
        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
