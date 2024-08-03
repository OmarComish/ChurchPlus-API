using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchPlus_v1._0.Models;

namespace ChurchPlus_v1._0.Middleware
{
    public interface IFundsManager
    {
        string[] AddPledge(Pledge pledge);
        string[] RemovePledge(int id);
        string[] UpdatePledge(Pledge plege);
        string[] AddExpense(Expense expense);
        string[] RemoveExpense(int id);
        string[] UpdateExpense(Expense expense);
        string[] AddOffering(Offering offering);
        string[] RemoveOffering(int id);
        string[] UpdateOffering(Offering offering);
    }
    public interface IProfileManager
    {
        string[] AddProfile(VMUserProfile profile, int creator);
        string[] UpdateProfile(VMUserProfile profile, int updateby);
        string[] RemoveProfile(VMUserProfile profile, int deleteby);
        List<UserProfileDetail> ListProfileDetails();
        UserProfileDetail FindUser(int id);
        
    }
}
