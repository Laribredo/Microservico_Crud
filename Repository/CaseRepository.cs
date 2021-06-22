using Microservico_Crud.DBContexts;
using Microservico_Crud.Domain;
using Microservico_Crud.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservico_Crud.Repository
{
    public class CaseRepository : ICaseRepository
    {
        private readonly CaseContext _dbContext;
        public IMessageView _message { get; set; }

        public CaseRepository(CaseContext dbContext, IMessageView message)
        {
            _message = message;
            _dbContext = dbContext;
        }



        public MessageView DeleteCase(int caseId)
        {
            try
            {
                var product = _dbContext.Cases.Find(caseId);
                _dbContext.Cases.Remove(product);
                Save();
                return _message.SetMessage(true, "The case was deleted.");

            }
            catch (Exception e)
            {
                return _message.SetMessage(false, e.Message);
            }

        }

        public Case GetCaseByID(int caseId)
        {
            return _dbContext.Cases.Find(caseId);
        }

        public Case GetCaseByNumber(string caseNumber)
        {
            return _dbContext.Cases.Where(s => s.CaseNumber.Equals(caseNumber)).FirstOrDefault();
        }

        public IEnumerable<Case> GetCases()
        {
            return _dbContext.Cases.ToList();
        }

        public MessageView InsertCase(Case cases)
        {
            try
            {
                if (GetCaseByNumber(cases.CaseNumber) == null)
                {
                    _dbContext.Add(cases);
                    Save();
                    return _message.SetMessage(true,"");
                }
                else
                {
                    return _message.SetMessage(false, "We already have a case with this number.");
                }
            }catch(Exception e)
            {
                return _message.SetMessage(false, e.Message);
            }

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public MessageView UpdateCase(Case cases)
        {
            try
            {
                _dbContext.Entry(cases).State = EntityState.Modified;
                Save();
                return _message.SetMessage(true, "");
            }
            catch (Exception e)
            {
                return _message.SetMessage(false, e.Message);
            }


        }
    }
}
