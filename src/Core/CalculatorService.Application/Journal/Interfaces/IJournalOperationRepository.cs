using CalculatorService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Application.Journal.Interfaces
{
    public interface IJournalOperationRepository
    {
        Task<bool> AddOrUpdate(string journalId, JournalOperation journalOperation);

        Task<IEnumerable<JournalOperation>> Get(string journalId);

    }
}
