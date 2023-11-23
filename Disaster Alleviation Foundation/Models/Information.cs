using Disaster_Alleviation_Foundation.Models;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class Information
    {
        public decimal TotalMonetary { get; set; }
        public int TotalGoods { get; set; }
        public ICollection<MoneyAllocations> MoneyAllocations { get; set; }
        public ICollection<GoodsAllocation> GoodsAllocation { get; set; }
        public List<Disaster> IsDisaster { get; set; }
    }
}
