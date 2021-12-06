using System.Collections.Generic;

namespace BrandAPP.API.Models.Responses
{
    public class BrandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SizeResponse> Sizes { get; set; }
    }
}
