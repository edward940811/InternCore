using Legal.Entity;
using Legal.LawFile.ViewModel;
using Legal.LawFile.Models;
using System.Collections.Generic;
using System.Linq;

namespace Legal.LawFile.Service
{
    public class LawFileService
    {
        private string _companyId;
        private int _userId;

        //搜尋法規建構子
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
