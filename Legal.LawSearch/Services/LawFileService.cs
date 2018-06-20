using System.Collections.Generic;
using System.Linq;
using Legal.LawSearch.Conditions;
using Legal.LawSearch.Repository;
using Legal.LawSearch.ViewModel;

namespace Legal.LawFile.Service
{
    internal class LawFileService
    {
        private string _companyId;
        private int _userId;

        public LawFileService(string CompanyId, int UserId)
        {
            _companyId = CompanyId;
            _userId = UserId;
        }
        public List<LawFileVM> GetLawFiles(LawSearchCondition condition)
        {
            return new LawFileRepository().GetLawFiles(condition, _companyId).ToList();
        }
    }
}
