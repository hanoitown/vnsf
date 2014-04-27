using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.CRM;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities
{
    public class Proposal
    {
        public Guid ProposalId { get; set; }
        public Guid SpecializationId { get; set; }
        public int Duration { get; set; }
        public int NumberOfResearcher { get; set; }
        public decimal TotalFund { get; set; }
        public decimal RequestGrant { get; set; }
        public string OtherGrant { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Result> Results { get; set; }
    }

    public class Member
    {
        public Guid ProposalId { get; set; }
        public Guid ProfileId { get; set; }
        public Position Position { get; set; }
    }


    public class Result
    {
        public Guid Id { get; set; }
        public ResultType ResultType { get; set; }

    }

    public class ResultLocalization
    {
        public Guid ResultId { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Result Result { get; set; }
        public Culture Culture { get; set; }

    }

    public enum ResultType
    {
        IsiPublication = 1,
        NonIsiPublication = 2,
        ConferencePublication = 3,
        NationalMagazine = 4,
        Book = 5,
        Other = 9

    }

    public enum ProjectType
    {
        Theory = 1,
        Practice = 2
    }

    public enum ProposalType
    {
        Discovery = 1,
        Continue = 2
    }

    public class ProposalLocalized
    {
        public Guid ProposalId { get; set; }
        public int CultureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Proposal Proposal { get; set; }
        public Culture Culture { get; set; }
    }
}
