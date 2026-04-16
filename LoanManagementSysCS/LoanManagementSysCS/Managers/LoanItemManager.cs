using System;
using System.Collections.Generic;

namespace LoanManagementSys.Managers
{
    internal class LoanItemManager
    {
        private List<LoanItem> loanItems = new List<LoanItem>();
        // Keep track of returned loan items locally so returned items can be
        // removed from the active loanItems list and reported to the GUI.
        private List<LoanItem> returns = new List<LoanItem>();

        public void Add(LoanItem loanItem)
        {
            loanItems.Add(loanItem);
        }

        public void Remove(int index)
        {
            if (CheckIndex(index))
            {
                // Move the loan item to the returns list and remove it from
                // the active loan items so it is no longer shown as loaned.
                returns.Add(loanItems[index]);
                loanItems.RemoveAt(index);
            }
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
            string[] infoString = new string[loanItems.Count];

            for (int i = 0; i < loanItems.Count; i++)
            {
                infoString[i] = loanItems[i].ToString();
            }
            return infoString;
        }

        public string[] GetLoanInfo()
        {
            string[] infoString = new string[loanItems.Count];
            for (int i = 0; i < loanItems.Count; i++)
            {
               string loanInfo = $"Loaned item: {loanItems[i].Product.Name}";
               infoString[i] = loanInfo;
            }
            return infoString;
        }
        public string[] GetReturnInfoStrings()
        {
            string[] infoString = new string[returns.Count];

            for (int i = 0; i < returns.Count; i++)
            {
                infoString[i] = returns[i].ReturnString();
            }

            return infoString;
        }
    }
}