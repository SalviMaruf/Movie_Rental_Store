using System.Collections.Generic;

namespace WebApplication1.Controllers.Api
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}