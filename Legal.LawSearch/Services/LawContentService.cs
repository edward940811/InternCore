using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legal.LawSearch.Conditions;
using Legal.LawSearch.Repository;
using Legal.LawSearch.ViewModels;


namespace Legal.LawSearch.Services
{
    internal class LawContentService
    {
        private string _companyId;
        private int _userId;

        public LawContentService(string companyID, int userID)
        {
            _companyId = companyID;
            _userId = userID;
        }

        public List<LawContentVM> GetLawContents(LawSearchCondition condition)
        {
            return new LawContentRepository().GetLawContents(condition, _companyId).ToList();
        }
    }
}