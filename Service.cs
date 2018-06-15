using System;
namespace Legal.Service
{
    public class LawContentService
    {
        private string _companyId;
        private int _userId;

        public LawContentService()
        {
            if (HttpContext.Current != null)
            {
                _companyId = HttpContext.Current.User.GetClaimByName("CompanyId");
                int.TryParse(HttpContext.Current.User.GetClaimByName("UserId"), out _userId);
            }
        }
    }
}
