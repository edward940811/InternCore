using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using Legal.Entity;
using Legal.LawSearch.Entity;
using Legal.LawSearch.Service;
using Legal.LawSearch.ViewModels;

namespace Legal.LawContentSearch
{
    //搜尋法條
    public class LawContentSearch
    {
        public List<LawContentVM> GetLawContents([FromUri]LawSearchCondition condition, LawContentService service)
        {
            if (condition == null) { return null; }

            if (condition.StartDate.HasValue && condition.EndDate.HasValue)
            {
                if (((DateTime)condition.EndDate - (DateTime)condition.StartDate).TotalDays > 366)
                {
                    return null;
                }
            }

            var lawContents = service.GetLawContents(condition);
            var totalRecords = lawContents.Count == 0 ? 0 : lawContents[0].TotalRecords;
            return lawContents;
        }
    }
}
