using Eshop.Database;
using Eshop.Entities;

namespace Eshop.Helpers
{
    public class UserInfoExtractorHelper
    {
        public static UserInfo GetUserInfo(DatabaseContext dbContext, HttpContext httpContext)
        {
            int? uid = httpContext.Session.GetInt32("UID");
            
            if (uid is null)
                return new(false, null,null,null);


            Account acc = dbContext.Accounts.Single(a=>a.Id == uid);

            int rid  = acc.AccountTypeId;
            string mail = acc.Mail;
            string fName = acc.Name +" "+ acc.Lastname;

            return new UserInfo(true, rid, fName, mail);
        }
    }
}
