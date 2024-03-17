using System.Security.Permissions;

namespace Pharamcy.Domain.Models
{
    public class Medicine : BaseMedicine
    {
        public virtual List<MedicineTracking> Tracking { get; set; } = new(); 
    }
}
