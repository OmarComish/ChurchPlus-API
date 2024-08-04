using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchPlus_v1._0.Models;

namespace ChurchPlus_v1._0.Middleware
{
    public interface IFundsManager
    {
        string[] AddPledge(Pledge pledge);
        string[] RemovePledge(int id, int removeby);
        string[] UpdatePledge(Pledge plege);
        string[] AddExpense(Expense expense);
        string[] RemoveExpense(int id, int removeby);
        string[] UpdateExpense(Expense expense);
        string[] AddOffering(Offering offering);
        string[] RemoveOffering(int id, int removeby);
        string[] UpdateOffering(Offering offering);
        List<ResponseObject> ApproveOffering(int[] offeringid, int approveby);
        List<ResponseObject> ApprovePledge(int[] pledgeid, int approveby);
        List<ResponseObject> ApproveExpense(int[] expenseid, int approveby);
    }
    public interface IProfileManager
    {
        string[] AddProfile(VMUserProfile profile, int creator);
        string[] UpdateProfile(VMUserProfile profile, int updateby);
        string[] RemoveProfile(VMUserProfile profile, int deleteby);
        List<UserProfileDetail> ListProfileDetails();
        UserProfileDetail FindUser(int id);
    }
    public interface ISettings
    {
        List<OfferingGroup> GetOfferingGroups();
    }
}
