using Legal.LawSearch.Entity;
using Legal.LawSearch.Models;
using Legal.LawSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Legal.LawSearch.Service
{
    public class LawContentService
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