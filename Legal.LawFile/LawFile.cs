using Legal.Entity;
using Legal.LawFile.Service;
using Legal.LawFile.ViewModel;
using System;
using System.Collections.Generic;

namespace Legal.LawFile
{
    public class LawFile
    {
        /// <summary>
        /// 搜尋附檔
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>       
        public List<LawFileVM> GetLawFiles(LawSearchCondition condition, LawFileService service)
        {
            if (condition == null) { return null; }

            if (condition.StartDate.HasValue && condition.EndDate.HasValue)
            {
                if (((DateTime)condition.EndDate - (DateTime)condition.StartDate).TotalDays > 366)
                {
                    return null;
                }
            }

            List<LawFileVM> lawFiles = service.GetLawFiles(condition);
            var totalRecords = lawFiles.Count == 0 ? 0 : lawFiles[0].TotalRecords;

            return lawFiles;
        }
    }
}
