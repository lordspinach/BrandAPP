using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAPP.BLLayer.DTO
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SizeDTO> Sizes { get; set; }
    }
}
