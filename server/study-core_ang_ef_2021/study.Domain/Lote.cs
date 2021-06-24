using System;

namespace study.Domain
{
    public class Lote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public DateTime? DateInit { get; set; }
        public DateTime? DateEnd { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
