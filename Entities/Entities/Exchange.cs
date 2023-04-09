using Entities.Common;

namespace Entities.Entities
{
    public class Exchange : IEntity
    { 
        public string DovizId { get; set; }
        public ICollection<ExchangeRate> ExchangeRates { get; set; }
    }
}
