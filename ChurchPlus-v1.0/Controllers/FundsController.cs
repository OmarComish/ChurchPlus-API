using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ChurchPlus_v1._0.Utils;
using ChurchPlus_v1._0.Middleware;
using System;
using ChurchPlus_v1._0.Models;
using DocumentFormat.OpenXml.Bibliography;

namespace ChurchPlus_v1._0.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FundsController: Controller
    {
       private readonly IUtils _utils;
       private readonly IFundsManager _fundsmgr;
       public FundsController(IUtils utils, IFundsManager fundsmgr)
       {
          _utils = utils;
          _fundsmgr = fundsmgr;
       }
       [HttpPost]
       public async Task<IActionResult> AddOffering([FromBody] Offering offering)
       {
          string[] res = {"error", "Cannot save empty record for offering"};
          if(offering != null)
          {
            offering.CollectedBy = 1; //use session to identify creator of this record
             res = await  Task.Run(()=>_fundsmgr.AddOffering(offering));
          }
          return Ok(res);
       }
       [HttpPost]
       public async Task<IActionResult> UpdateOffering([FromBody] Offering offering)
       {
          string[] res = {"error", "Cannot update empty record for offering"};
          if(offering != null)
          {
            offering.ModifiedBy = 1; //use session to identify creator of this record
             res = await  Task.Run(()=>_fundsmgr.UpdateOffering(offering));
          }
          return Ok(res);
       }
       [HttpDelete, HttpPost]
       public async Task<IActionResult> DeleteOffering(int id)
       {
           string[] res = {"error", "Invalid offering Id. Failed to delete"};
           if(id != 0)
           {
              int deleteby = 1;
              res = await Task.Run(()=>_fundsmgr.RemoveOffering(id, deleteby));
           }
           return Ok(res);
       }
       [HttpPost]
       public async Task<IActionResult> AddExpense([FromBody]Expense expense)
       {
          string[] res = {"error", "Cannot save empty record for expense"};
          if(expense != null)
          {
             expense.CreatedBy = 1; //use session to identify creator of this record
             res = await  Task.Run(()=>_fundsmgr.AddExpense(expense));
          }
          return Ok(res);
       }
              [HttpPost]
       public async Task<IActionResult> UpdateExpense([FromBody]Expense expense)
       {
          string[] res = {"error", "Cannot save empty record for expense"};
          if(expense != null)
          {
             expense.ModifiedBy = 1; //use session to identify creator of this record
             res = await  Task.Run(()=>_fundsmgr.UpdateExpense(expense));
          }
          return Ok(res);
       }
      [HttpDelete]
       public async Task<IActionResult> DeleteExpense(int id)
       {
           string[] res = {"error", "Invalid expense Id. Failed to delete"};
           if(id != 0)
           {
              int deleteby = 1;
              res = await Task.Run(()=>_fundsmgr.RemoveExpense(id, deleteby));
           }
           return Ok(res);
       }
       [HttpPost]
       public async Task<IActionResult> AddPledge([FromBody]Pledge pledge)
       {
          string[] res = {"error", "Cannot save empty record for pledge"};
          if(pledge != null)
          {
             pledge.CreatedBy = 1; //use session to identify creator of this record
             res = await  Task.Run(()=>_fundsmgr.AddPledge(pledge));
          }
          return Ok(res);
       }
       [HttpPost]
       public async Task<IActionResult> UpdatePledge([FromBody]Pledge pledge)
       {
          string[] res = {"error", "Cannot save empty record for pledge"};
          if(pledge != null)
          {
             pledge.CreatedBy = 1; //use session to identify creator of this record
             res = await  Task.Run(()=>_fundsmgr.UpdatePledge(pledge));
          }
          return Ok(res);
       }
      [HttpDelete]
       public async Task<IActionResult> DeletePledge(int id)
       {
           string[] res = {"error", "Invalid pledge Id. Failed to delete"};
           if(id != 0)
           {
              int deleteby = 1;
              res = await Task.Run(()=>_fundsmgr.RemovePledge(id, deleteby));
           }
           return Ok(res);
       }
       [HttpPost]
       public async Task<IActionResult> ApprovePledges(int[]pledgeid)
       {
           var res = new List<ResponseObject>();
           res.Add(new ResponseObject{Status = "error", Message ="No pledges selected. Failed to approve"});
           if(pledgeid != null)
           {
              int approvedby = 1;
              res = await Task.Run(()=> _fundsmgr.ApprovePledge(pledgeid, approvedby));
           }
           return Ok(res);
       }
       [HttpPost]
       public async Task<IActionResult> ApproveExpenses(int[] expenseid)
       {
           var res = new List<ResponseObject>();
           res.Add(new ResponseObject{Status = "error", Message ="No expenses selected. Failed to approve"});
           if(expenseid != null)
           {
              int approvedby = 1;
              res = await Task.Run(()=> _fundsmgr.ApproveExpense(expenseid, approvedby));
           }
           return Ok(res);
       }
       [HttpPost]
       public async Task<IActionResult> ApproveOffering(int[] offeringid)
       {
           var res = new List<ResponseObject>();
           res.Add(new ResponseObject{Status = "error", Message ="No offering selected. Failed to approve"});
           if(offeringid != null)
           {
              int approvedby = 1;
              res = await Task.Run(()=> _fundsmgr.ApproveExpense(offeringid, approvedby));
           }
           return Ok(res);
       }
    }
}