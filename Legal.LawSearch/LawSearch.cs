using LawKing.Entity;
using LawKing.Entity.ViewModels;
using LawKing.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

namespace Legal.LawSearch
{
    public class LawSearch 
    {
        public List<LawInfoVM> GetLawInfos([FromUri]LawSearchCondition condition, LawInfoService lawInfoService)
        {
            if (condition == null) { return null; }

            if (condition.StartDate.HasValue && condition.EndDate.HasValue)
            {
                if (((DateTime)condition.EndDate - (DateTime)condition.StartDate).TotalDays > 366)
                {
                    return null;
                }
            }
            //confirm: 應該改為用一個sql去撈任何的資料
            List<LawInfoVM> lawInfos = null;
            var containCustLaw = string.IsNullOrEmpty(condition.BType) || condition.BType == "自訂";
            lawInfos = lawInfoService.GetLawInfos(condition, true);

            var totalRecords = lawInfos.Count == 0 ? 0 : lawInfos[0].TotalRecords;

            var result = new PagingModel<List<LawInfoVM>>()
            {
                PageIndex = condition.PageIndex,
                Data = lawInfos,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling((float)totalRecords / (float)condition.PageSize)
            };

            return lawInfos;
        }
    }
}
