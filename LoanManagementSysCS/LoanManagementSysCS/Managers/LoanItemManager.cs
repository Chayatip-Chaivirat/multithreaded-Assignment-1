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
            if (loanItems == null || loanItems.Count <= 0)
                return new string[] {"Active loans: 0", " "};

            string[] infoString = new string[loanItems.Count + 3];
            infoString[0] = $"Active loans: {loanItems.Count}";
            infoString[1] = " ";
            int j = 2;

            for (int i = 0; i < loanItems.Count; i++)
            {
                infoString[j++] = loanItems[i].ToString();
            }

            infoString[infoString.Length - 1] = " ";
            return infoString;
        }
    }
}