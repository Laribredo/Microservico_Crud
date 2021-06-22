using Microservico_Crud.DBContexts;
using Microservico_Crud.Domain;
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

        public CaseRepository(CaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCase(int caseId)
        {
            var product = _dbContext.Cases.Find(caseId);
            _dbContext.Cases.Remove(product);
            Save();
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

        public bool InsertCase(Case cases)
        {
            if (GetCaseByNumber(cases.CaseNumber) == null)
            {
                _dbContext.Add(cases);
                Save();
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public bool UpdateCase(Case cases)
        {
            try
            {
                _dbContext.Entry(cases).State = EntityState.Modified;
                Save();
                return true;
            }catch(Exception)
            {
                return false;
            }


        }
    }
}
