using System;
using System.Collections.Generic;

namespace LoanManagementSys.Managers
{
    internal class LoanItemManager
    {
        private List<LoanItem> loanItems = new List<LoanItem>();
        ProductManager productManager = new ProductManager();

        public void Add(LoanItem loanItem)
        {
            loanItems.Add(loanItem);
        }

        public void Remove(int index)
        {
            if (CheckIndex(index))
            {
                productManager.retuns.Add(loanItems[index]);
                //loanItems.RemoveAt(index);
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

            infoString[infoString.Length - 1] = " ";
            return infoString;
        }
        public string[] GetReturnInfoStrings()
        {
            string[] infoString = new string[productManager.retuns.Count];

            for (int i = 0; i < productManager.retuns.Count; i++)
            {
                infoString[i] = productManager.retuns[i].ReturnString();
            }

            return infoString;
        }
    }
}