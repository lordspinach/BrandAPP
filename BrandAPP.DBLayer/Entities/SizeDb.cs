
namespace BrandAPP.DBLayer.Entities
{
    public class SizeDb
    {
        public int Id { get; set; }
        public float RFSize { get; set; }
        public float BrandSize { get; set; }
        public virtual BrandDb Brand { get; set; }
    }
}
