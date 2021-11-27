using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSICMS.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastModified { get; set; }

    }
}
