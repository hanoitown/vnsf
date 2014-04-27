using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Anticorruption;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract.Service_Contracts;

namespace Vnsf.Service.Implementation
{
    public class InformationService : ServiceBase, IInformationService
    {
        OmsConnection oms;

        public InformationService(IUnitOfWork uow)
            : base(uow)
        {
            oms = new OmsConnection();
        }

        #region Grant

        public void CreateGrant(Grant grant)
        {
            grant.Created = DateTime.UtcNow;
            _uow.GrantRepo.Add(grant);
            _uow.Commit();
        }
        public List<Grant> GetAvailableGrants()
        {
            // find from oms db
            var program = new List<Grant>();
            try
            {
                program = oms.tbl_program_type.Select(p => new Grant
                                                           {
                                                               Name = p.T_NAME,
                                                               Code = p.T_SHORT,
                                                               Description = p.T_LONG
                                                           }).ToList();
            }
            catch
            {

            }

            // merge with local repository
            return _uow.GrantRepo.AllIncluding(g => g.Agency).ToList().Concat(program).ToList();
        }

        public Grant GetGrantDetailById(Guid id)
        {
            return _uow.GrantRepo.GetGrantDetailById(id);
        }

        public void PutGrantById(Guid id, Grant grant)
        {
            var item = _uow.GrantRepo.FindById(id);
            item.Code = grant.Code;
            item.Name = grant.Name;
            item.Description = grant.Description;
            item.Objective = grant.Objective;
            item.MaxAward = grant.MaxAward;
            item.MaxDuration = grant.MaxDuration;
            item.AgencyId = grant.AgencyId;
            item.Total = grant.Total;
            item.LastUpdated = DateTime.UtcNow;
            _uow.Commit();
        }

        public void AddOpportunityToGrand(Guid grantId, Opportunity opp)
        {
            var grant = _uow.GrantRepo.FindById(grantId);
            grant.Opportunities.Add(opp);
            _uow.Commit();
        }

        #endregion

        #region Opportunities
        public List<Opportunity> GetOpportunitiesByGrantId(Guid grantId)
        {
            return _uow.GrantRepo.GetOpportunityHistory(grantId).ToList();
        }

        public List<Opportunity> GetAvailableOpportunities()
        {
            return _uow.OpportunitiesRepo.GetAvailableOpportunities().ToList();
        }

        public Opportunity GetOpportunityById(Guid id)
        {
            return _uow.OpportunitiesRepo.FindById(id);
        }

        public void CreateOpportunity(Opportunity opportunity)
        {
            opportunity.Created = DateTime.UtcNow;
            //_uow.GrantRepo.FindById(opportunity.GrantId).Opportunities.Add(opportunity);
            _uow.OpportunitiesRepo.Add(opportunity);
            _uow.Commit();
        }

        public void PutOpportunityById(Guid id, Opportunity o)
        {
            var item = _uow.OpportunitiesRepo.FindById(id);
            item.Name = o.Name;
            item.Description = o.Description;
            item.MaxDuration = o.MaxDuration;
            item.EstimateTotal = o.EstimateTotal;
            item.AwardCeiling = o.AwardCeiling;
            item.AwardFloor = o.AwardFloor;
            item.StartDate = o.StartDate;
            item.Deadline = o.Deadline;
            item.GrantId = o.GrantId;
            item.LastUpdated = DateTime.UtcNow;
            _uow.Commit();

        }

        #endregion

        #region Announcement

        public void CreateAnnoucement(Announcement a)
        {
            _uow.AnnouncementRepo.Add(a);
            _uow.Commit();
        }

        public List<Announcement> GetAnnouncementsByGrandId(Guid? grantId)
        {
            return null;
        }
        public List<Announcement> GetAvailableAnnouncements()
        {
            return _uow.AnnouncementRepo.GetAvailableAnnouncement().ToList();
        }
        #endregion

        public List<Organization> GetAllOrganizations()
        {
            return _uow.Organizations.All.ToList();
        }



        public Announcement GetAnnouncementsById(Guid id)
        {
            return _uow.AnnouncementRepo.GetAnnouncementsById(id);
        }

        public void PutAnnoucement(Guid id, Announcement announcement)
        {
            var a = _uow.AnnouncementRepo.FindById(id);
            a.Name = announcement.Name;
            a.Content = announcement.Content;
            a.Description = announcement.Description;
            a.StartDate = announcement.StartDate;
            a.AwardCeiling = announcement.AwardCeiling;
            a.AwardFloor = announcement.AwardFloor;
            a.MaxDuration = announcement.MaxDuration;
            a.PostDate = announcement.PostDate;
            a.EstimateTotal = announcement.EstimateTotal;
            a.LastUpdated = DateTime.UtcNow;
            _uow.Commit();
        }

        public List<Classification> GetClassifications()
        {
            return _uow.ClassificationRepo.All.ToList();
        }

        public Classification GetClassificationById(Guid classificationId)
        {
            return _uow.ClassificationRepo.GetClassificationById(classificationId);
        }
        public void AddCategoryToClassifcation(Guid classificationId, Category categoryToAdd)
        {
            var classification = _uow.ClassificationRepo.FindById(classificationId);
            classification.AddCategory(categoryToAdd);
            _uow.Commit();
        }
    }
}
