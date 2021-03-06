﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Service.Contract.Service_Contracts
{
    public interface IInformationService
    {
        void CreateGrant(Grant grant);
        List<Grant> GetAvailableGrants();
        Grant GetGrantDetailById(Guid id);
        void PutGrantById(Guid id, Grant grant);
        void AddOpportunityToGrand(Guid grantId, Opportunity opp);

        List<Opportunity> GetAvailableOpportunities();
        List<Opportunity> GetOpportunitiesByGrantId(Guid grantId);
        Opportunity GetOpportunityById(Guid id);
        void CreateOpportunity(Opportunity opportunity);
        void PutOpportunityById(Guid id, Opportunity opportunity);

        #region Announcement
        Post GetAnnouncementsById(Guid id);
        void CreateAnnoucement(Post a);
        void PutAnnoucement(Guid id, Post announcement);
        List<Post> GetAnnouncementsByGrandId(Guid? grandId);
        List<Organization> GetAllOrganizations();
        List<Post> GetAvailableAnnouncements();

        #endregion

        List<Classification> GetClassifications();
        Classification GetClassificationById(Guid classificationId);
        void AddCategoryToClassifcation(Guid classificationId, Category categoryToAdd);

        
    }
}
