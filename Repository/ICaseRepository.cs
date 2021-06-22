using Microservico_Crud.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservico_Crud.Repository
{
    public interface ICaseRepository
    {
        IEnumerable<Case> GetCases();
        Case GetCaseByID(int cases);
        Case GetCaseByNumber(string caseNumber);
        bool InsertCase(Case cases);
        void DeleteCase(int caseId);
        bool UpdateCase(Case cases);
        void Save();
    }
}
