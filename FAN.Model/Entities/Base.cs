
namespace FAN.Model.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CreatedBy { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; } = null;
        public DateTime? ModifiedAt { get; set; } = null;
    }
}
