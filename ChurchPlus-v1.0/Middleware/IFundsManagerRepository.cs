using System;
using System.Collections.Generic;
using System.Linq;
using ChurchPlus_v1._0.Models;
using ChurchPlus_v1._0.DAL;
using ChurchPlus_v1._0.Utils;
using System.Net.Mime;
using DocumentFormat.OpenXml.Office2019.Drawing.Model3D;
using DocumentFormat.OpenXml.Bibliography;

namespace ChurchPlus_v1._0.Middleware
{
    public class IFundsManagerRepository: IFundsManager
    {
        private readonly IUtils _utils;
        public IFundsManagerRepository(IUtils utils)
        {
            _utils = utils; 
        }
        public string[] AddPledge(Pledge pledge)
        {
            using(var context = new DataContext())
            {
                string[] response = {"error", "Failed to add pledge"};
                if(!context.Pledge.Where(p => p.PledgeBy ==pledge.PledgeBy && p.PledgeId== pledge.PledgeId).Any())
                {
                    pledge.Status = _utils.GetRecordStatusId("Active");
                    pledge.DateCreated = DateTime.Now;
                    context.Pledge.Add(pledge);
                    context.SaveChanges();
                    response[0]="success";
                    response[1]="Pledge from " + pledge.PledgeBy + " added successfully";
                }
                else 
                {
                    response[1]= "Duplicate pledge found. Please carefully enter the details and save";
                }
                return response;
            }
            
        }
        public string[] RemovePledge(int id, int removeby)
        {
            using(var context = new DataContext())
            {
                string[] response = {"error", "Failed to delete pledge"};
                var pledge = context.Pledge.Where(p => p.Id==id).FirstOrDefault();
                if(pledge != null)
                {
                    pledge.ModifiedBy = removeby;
                    pledge.DateModified = DateTime.Now;
                    pledge.Status = _utils.GetRecordStatusId("Discarded"); 
                    context.Entry(pledge).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    response[0]="success";
                    response[1]="Pledge deleted successfully!";
                }
                 return response;
            }
            
           
        }
        public string[] UpdatePledge(Pledge pledge)
        {
            using(var context = new DataContext())
            {
               string[] response = {"error", "Failed to update pledge"};
               var record = context.Pledge.Where(p => p.Id==pledge.Id).FirstOrDefault();
               if(record!= null)
               {
                 record.DatePledged = pledge.DatePledged;
                 record.DateFulfilled = pledge.DateFulfilled;
                 record.ActualAmountFulfilled = pledge.ActualAmountFulfilled;
                 record.AmountPledged = pledge.AmountPledged;
                 record.PledgeId = pledge.PledgeId;
                 record.PledgeBy = pledge.PledgeBy;
                 record.DateModified = pledge.DateModified;
                 record.ModifiedBy = pledge.ModifiedBy;
               }
               return response;
            }

        }
        public string[] AddExpense(Expense expense)
        {
            using(var context = new DataContext())
            {
               string[] response = {"error", "Failed to add expense"};
               expense.DateCreated = DateTime.Now;
               expense.Status = _utils.GetRecordStatusId("Pending");
               context.Expense.Add(expense);
               context.SaveChanges();
               response[0]="success";
               response[1]="Expense added successfully!";
               return response;
            }

        }
        public string[] UpdateExpense(Expense expense)
        {
            using(var context = new DataContext())
            {
               string[] response = {"error", "Failed to update expense"};
               var record = context.Expense.Where(e=>e.Id== expense.Id).FirstOrDefault();
               if(record != null)
               {
                  record.Amount = expense.Amount;
                  record.DateIncurred = expense.DateIncurred;
                  record.Purpose = expense.Purpose;
                  record.ReceiptNumber = expense.ReceiptNumber;
                  record.DateModified = DateTime.Now;
                  record.ModifiedBy = expense.ModifiedBy;

                  context.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                  context.SaveChanges();
                  response[0]="success";
                  response[1]="Expense update successful!";
               }
               return response;
            }
        }
        public string[] RemoveExpense(int id, int deleteby)
        {
            using(var context = new DataContext())
            {
               string[] response = {"error", "Failed to delete expense"};
               var expense = context.Expense.Where(e=>e.Id == id).FirstOrDefault();
               if(expense != null)
               {
                 expense.DateModified = DateTime.Now;
                 expense.ModifiedBy = deleteby;
                 expense.Status = _utils.GetRecordStatusId("Discarded");

                 context.Entry(expense).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 context.SaveChanges();
                 response[0]="success";
                 response[1]="Expense deleted successfully!";
               }
               return response;
            }
        }
        public string[] AddOffering(Offering offering)
        {
            using(var context = new DataContext())
            {
               string[] response = {"error", "Failed to add offering"};
               if(!context.Offerings.Where(o=>o.OfferingGroupId==offering.OfferingGroupId 
               && o.ServiceSession==offering.ServiceSession && o.Amount==offering.Amount 
               && o.CollectionDate==offering.CollectionDate).Any())
               {
                 offering.DateCreated = DateTime.Now;
                 offering.Status = _utils.GetRecordStatusId("Pending"); 
                 context.Offerings.Add(offering);
                 context.SaveChanges();
                 response[0]="success";
                 response[1]="Offering added successfully!";
               }
               return response;
            } 
            
        }
        public string[] UpdateOffering(Offering offering)
        {
            using(var context = new DataContext())
            {
               string[] response = {"error", "Failed to update offering"};
               var record = context.Offerings.Where(o => o.Id==offering.Id).FirstOrDefault();
               if(record!=null)
               {
                 record.Amount = offering.Amount;
                 record.OfferingGroupId = offering.OfferingGroupId;
                 record.Status = _utils.GetRecordStatusId("Pending");
                 record.DateModified = DateTime.Now;
                 record.ModifiedBy = offering.ModifiedBy;

                 context.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 context.SaveChanges();
                 response[0]="success";
                 response[1]="Offering update successful!";
               }
               return response;
            }
            
        }
        public string[] RemoveOffering(int id, int removeby)
        {
            using(var context = new DataContext())
            {
                string[] response = {"error", "Failed to delete offering"};
                var record = context.Offerings.Where(o=>o.Id==id).FirstOrDefault();
                if(record !=null)
                {
                     record.Status = _utils.GetRecordStatusId("Discarded");
                     record.DateModified = DateTime.Now;
                     record.ModifiedBy=removeby;
                     context.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                     context.SaveChanges();
                }
                return response;
            }
        }
        public List<ResponseObject> ApprovePledge(int[] pledgeid, int approvedby)
        {
            using(var context = new DataContext())
            {
                var responseobj = new List<ResponseObject>();
                string[] response = {"error", "Failed to approve pledge"};
                var pledge = new Pledge();
                for(int i=0; i < pledgeid.Length; i ++)
                {
                    pledge= context.Pledge.Where(p=>p.Id==pledgeid[i]).FirstOrDefault();
                    if(pledge!= null)
                    {
                        pledge.ApprovedBy=approvedby;
                        pledge.DateApproved=DateTime.Now;
                        context.Entry(pledge).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                        response[0]="sucess";
                        response[1]= "Approve successful!";
                    }
                    responseobj.Add(new ResponseObject{ Id = pledgeid[i], Status = response[0], Message = response[1]});
                 }

                return responseobj;
            }
        }
        public List<ResponseObject> ApproveExpense(int[] expenseid, int approvedby)
        {
            using(var context = new DataContext())
            {
                var responseobj = new List<ResponseObject>();
                string[] response = {"error", "Failed to approve expense"};
                var expense = new Expense();
                for(int k = 0; k < expenseid.Length; k ++){
                    expense= context.Expense.Where(p=>p.Id==expenseid[k]).FirstOrDefault();
                    if(expense!= null)
                    {
                        expense.ModifiedBy=approvedby;
                        expense.DateModified=DateTime.Now;
                        context.Entry(expense).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                        response[0]="sucess";
                        response[1]= "Approve successful!";
                    }
                    responseobj.Add(new ResponseObject{ Id = expenseid[k], Status = response[0], Message = response[1]});
                }

                return responseobj;
            }
        }
        public List<ResponseObject>  ApproveOffering(int[] offeringid, int approvedby)
        {
            using(var context = new DataContext())
            {
                var responseobj = new List<ResponseObject>();
                string[] response = {"error", "Failed to approve offering"};
                var offering = new Offering();
                for(int j = 0; j < offeringid.Length; j ++)
                {
                    offering= context.Offerings.Where(o=>o.Id==offeringid[j]).FirstOrDefault();
                    if(offering!= null)
                    {
                        offering.ModifiedBy=approvedby;
                        offering.DateModified=DateTime.Now;
                        context.Entry(offering).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                        response[0]="sucess";
                        response[1]= "Approve successful!";
                    }
                }

                return responseobj;
            }
        }
    }
}