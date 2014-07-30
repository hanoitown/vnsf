using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ProposalProduct
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public virtual PublicationKind Kind { get; set; }
    }

    public enum PublicationKind
    {
        Book,
        BookChapter,
        Invention,
        Journal,
        Patient,
        Thesis,
        Website
    }
}
