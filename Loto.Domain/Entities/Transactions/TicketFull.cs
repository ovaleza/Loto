namespace Loto.Domain.Entities.Transactions
{
    public class TicketFull : Ticket
    {
        public System.Collections.Generic.List<TicketD>? TicketDetail { get; set; }
    }

}
