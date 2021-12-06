using System.Collections.Generic;

namespace BrandAPP.DBLayer.Entities
{
    public class BrandDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SizeDb> Sizes { get; set; }
    }
}
