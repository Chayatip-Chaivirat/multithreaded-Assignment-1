using System;
using System.Collections.Generic;

namespace LoanManagementSys.Managers
{
    internal class LoanItemManager
    {
        private List<LoanItem> loanItems = new List<LoanItem>();

        public void Add(LoanItem loanItem)
        {
            loanItems.Add(loanItem);
        }

        public void Remove(int index)
        {
            if (CheckIndex(index))
                loanItems.RemoveAt(index);
        }

        public LoanItem Get(int index)
        {
            if (CheckIndex(index))
                return loanItems[index];

            return null;
        }

        public int Count
        {
            get { return loanItems.Count; }
        }

        private bool CheckIndex(int index)
        {
            return index >= 0 && index < loanItems.Count;
        }

        public bool NoLoans()
        {
            return loanItems.Count == 0;
        }

        public string[] GetLoanInfoStrings()
        {
            if (loanItems.Count == 0)
                return new string[] { "No active loans" };

            string[] arr = new string[loanItems.Count];

            for (int i = 0; i < loanItems.Count; i++)
                arr[i] = loanItems[i].ToString();

            return arr;
        }
    }
}