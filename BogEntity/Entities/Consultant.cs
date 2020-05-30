using System;
using System.Collections.Generic;

namespace BogEntity.Entities
{
    public partial class Consultant
    {      
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public int? RecommendatorId { get; set; }

        public Consultant Recommendator { get; set; }
        public ICollection<Consultant> InverseRecommendator { get; set; }
        public ICollection<Sale> Sale { get; set; }
    }
}
