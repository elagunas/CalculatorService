using CalculatorService.Application.Journal.Interfaces;
using CalculatorService.Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Persistence.Repositories
{
    public class JournalOperationRepository : IJournalOperationRepository
    {
        private static ConcurrentDictionary<string, List<JournalOperation>> JournalDictionary = new ConcurrentDictionary<string, List<JournalOperation>>();

        public async Task<IEnumerable<JournalOperation>> Get(string journalId)
        {
            var result = default(List<JournalOperation>);

            await Task.Run(() =>
            {
                JournalDictionary.TryGetValue(journalId, out result);
            });

            return result;
        }

        public async Task<bool> AddOrUpdate(string journalId, JournalOperation journalOperation)
        {
            var result = true;

            await Task.Run(() =>
            {
                JournalDictionary.AddOrUpdate(journalId,
                (newValue) => { return new List<JournalOperation>() { journalOperation }; },
                (currentKey, currentValue) => { currentValue.Add(journalOperation); return currentValue; });

            });

            return result;
        }
    }
}
