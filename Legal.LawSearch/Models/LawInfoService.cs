using Legal.LawSearch.Entity;
using Legal.LawSearch.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Legal.LawSearch.Service//LawKing.Service
{
    public class LawInfoService
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
