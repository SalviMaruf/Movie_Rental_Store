using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace WebApplication1.Models
{
    public class MembershipType
    {
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public byte Id { get; set; }
        public static readonly byte Unknown=0;
        public static readonly byte PayAsYouGo = 1;

    }
}