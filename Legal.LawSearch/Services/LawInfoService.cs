using System.Collections.Generic;
using System.Linq;
using Legal.LawSearch.Conditions;
using Legal.LawSearch.Repository;
using Legal.LawSearch.ViewModels;

namespace Legal.LawSearch.Services
{
    internal class LawInfoService
    {
        private string _companyId;
        private int _userId;
        public LawInfoService()
        {
        }
        public LawInfoService(string CompanyId, int UserId)
        {
            _companyId = CompanyId;
            _userId = UserId;
        }

        public List<LawInfoVM> GetLawInfos(LawSearchCondition condition, bool containCustLaw = false)
        {
            return new LawInfoRepository().GetLawInfos(condition, _companyId, _userId, containCustLaw).ToList();
        }
    }
}
