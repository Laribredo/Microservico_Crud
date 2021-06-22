using Microservico_Crud.Domain;
using Microservico_Crud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservico_Crud.Repository
{
    public interface ICaseRepository
    {
        IMessageView _message { get; set; }

        IEnumerable<Case> GetCases();
        Case GetCaseByID(int cases);
        Case GetCaseByNumber(string caseNumber);
        MessageView InsertCase(Case cases);
        MessageView DeleteCase(int caseId);
        MessageView UpdateCase(Case cases);
        void Save();
    }
}
