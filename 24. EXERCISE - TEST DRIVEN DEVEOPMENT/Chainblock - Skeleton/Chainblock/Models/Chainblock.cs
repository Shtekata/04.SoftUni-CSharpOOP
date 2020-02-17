using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> byId;
        private Dictionary<TransactionStatus, HashSet<ITransaction>> byStatus;
        public Chainblock()
        {
            byId = new Dictionary<int, ITransaction>();
            byStatus = new Dictionary<TransactionStatus, HashSet<ITransaction>>();
        }
        public int Count => byId.Count;

        public void Add(ITransaction tx)
        {
            if (Contains(tx))
            {
                throw new InvalidOperationException("Transaction already exist!");
            }

            byId[tx.Id] = tx;

            if (!byStatus.ContainsKey(tx.Status))
            {
                byStatus[tx.Status] = new HashSet<ITransaction>();
            }

            byStatus[tx.Status].Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!byId.ContainsKey(id))
            {
                throw new ArgumentException("There is no transaction with given Id present in the collection!");
            }

            var tr = byId[id];
            byStatus[tr.Status].Remove(tr);

            tr.Status = newStatus;

            if (!byStatus.ContainsKey(newStatus))
            {
                byStatus[newStatus] = new HashSet<ITransaction>();
            }

            byStatus[newStatus].Add(tr);
        }

        public bool Contains(ITransaction tx)
        {
            return byId.Values.Contains(tx);
        }

        public bool Contains(int id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("Invalid Id!");
            }

            return byId.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return byId.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are no transactions with given status presented in the collection!");
            }

            var receivers = byStatus[status]
                .OrderByDescending(x => x.Amount)
                .Select(x => x.To)
                .ToList();

            if (receivers.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with given status presented in the collection!");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are no transactions with given status presented in the collection!");
            }

            var senders = byStatus[status]
                .OrderByDescending(x => x.Amount)
                .Select(x => x.From)
                .ToList();

            if (senders.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with given status presented in the collection!");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!byId.ContainsKey(id))
            {
                throw new InvalidOperationException("Non existant Id privided!");
            }

            return byId[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var result = byId.Values
              .Where(x => x.To == receiver)
              .OrderByDescending(x => x.Amount)
              .ThenBy(x=>x.Id);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var result = byId.Values
                .Where(x => x.From == sender)
                .OrderByDescending(x => x.Amount);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;    
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are no transactions with given status presented in the collection!");
            }

            var wantedTr = byStatus[status];

            if (wantedTr.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with given status presented in the collection!");
            }

            return wantedTr.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!byId.ContainsKey(id))
            {
                throw new InvalidOperationException("You cannot remove non-existing transaction!");
            }

            var tr = byId[id];

            byStatus[tr.Status].Remove(tr);
            byId.Remove(tr.Id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
