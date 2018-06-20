using System;
using System.Collections.Generic;
using System.Text;
using Legal.LawFile.Service;
using Legal.LawSearch.Conditions;
using Legal.LawSearch.Services;
using Legal.LawSearch.ViewModel;
using Legal.LawSearch.ViewModels;
using Legal.Models;

namespace Legal.LawSearch
{
    public class LawSearch 
    {
        private LawInfoService lawInfoService { get; set; }

        private LawFileService lawFileService { get; set; }

        private LawContentService lawContentService { get; set; }

        public LawSearch(string companyId, int userId)
        {
            lawInfoService = new LawInfoService(companyId, userId);
            lawFileService = new LawFileService(companyId, userId);
            lawContentService = new LawContentService(companyId, userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<LawInfoVM> GetLawInfos(LawSearchCondition condition)
        {
            if (condition == null) { return null; }

            if (condition.StartDate.HasValue && condition.EndDate.HasValue)
            {
                if (((DateTime)condition.EndDate - (DateTime)condition.StartDate).TotalDays > 366)
                {
                    return null;
                }
            }

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

        /// <summary>
        /// 搜尋附檔
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>       
        public List<LawFileVM> GetLawFiles(LawSearchCondition condition)
        {
            if (condition == null) { return null; }

            if (condition.StartDate.HasValue && condition.EndDate.HasValue)
            {
                if (((DateTime)condition.EndDate - (DateTime)condition.StartDate).TotalDays > 366)
                {
                    return null;
                }
            }

            List<LawFileVM> lawFiles = lawFileService.GetLawFiles(condition);
            var totalRecords = lawFiles.Count == 0 ? 0 : lawFiles[0].TotalRecords;

            return lawFiles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<LawContentVM> GetLawContents(LawSearchCondition condition)
        {
            if (condition == null) { return null; }

            if (condition.StartDate.HasValue && condition.EndDate.HasValue)
            {
                if (((DateTime)condition.EndDate - (DateTime)condition.StartDate).TotalDays > 366)
                {
                    return null;
                }
            }

            var lawContents = lawContentService.GetLawContents(condition);
            var totalRecords = lawContents.Count == 0 ? 0 : lawContents[0].TotalRecords;
            return lawContents;
        }
    }
}
