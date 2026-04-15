using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Managers
{
    public class LoanSystemManager
    {
        //==========================
        // Managers and Classes
        //===========================
        ProductManager productManager = new ProductManager();
        MemberManager memberManager = new MemberManager();
        LoanItemManager loanItemManager = new LoanItemManager();
        MainForm form;

        //==========
        // Threads
        //==========
        Thread loanThread;
        Thread returnThread;
        Thread adminThread;
        Thread updateGUIThread;

        //==========
        // Lock
        //==========
        readonly object dataLock = new object();

        //==========
        // Bool
        //==========
        bool isRunning = false;

        //==========================
        // Start and Stop methods
        //==========================

        public LoanSystemManager(MainForm form)
        {
            this.form = form;
        }

        public void Start()
        {
            //prevent starting multiple times
            if (isRunning)
            { return; }

            //Add test data
            memberManager.AddTestMembers();
            productManager.AddTestProducts();

            // Bool
            isRunning = true;

            // Initialize threads
            loanThread = new Thread(LoanTask);
            returnThread = new Thread(ReturnTask);
            adminThread = new Thread(AdminTask);
            UpdateGUI updateGUI = new UpdateGUI(this);
            updateGUIThread = new Thread(UpdateGUI);

            // Start threads
            loanThread.Start();
            returnThread.Start();
            adminThread.Start();
            updateGUIThread.Start();
        }

        public void Stop()
        {
            isRunning = false;
        }

        //==========
        // Tasks
        //==========
        public void LoanTask()
        {
            Random random = new Random();

            while (isRunning)
            {
                lock (dataLock)
                {
                    if (productManager.Count > 0 && memberManager.Count > 0)
                    {
                        int productIndex = random.Next(productManager.Count);
                        int memberIndex = random.Next(memberManager.Count);

                        Product product = productManager.Get(productIndex);
                        Member member = memberManager.Get(memberIndex);

                        if (product != null && member != null)
                        {
                            productManager.Remove(productIndex);
                            loanItemManager.Add(new LoanItem(product, member));
                        }
                    }
                }
                Thread.Sleep(random.Next(2000, 6000));
            }
        }

        public void ReturnTask()
        {
            Random random = new Random();
            while (isRunning)
            {
                lock (dataLock)
                {
                    if (loanItemManager.Count > 0)
                    {
                        int loanIndex = random.Next(loanItemManager.Count);
                        LoanItem loanItem = loanItemManager.Get(loanIndex);

                        if (loanItem != null)
                        {
                            productManager.Add(loanItem.Product);
                            loanItemManager.Remove(loanIndex);
                        }
                    }
                }
                Thread.Sleep(random.Next(3000, 15000));
            }
        }

        public void AdminTask()
        {
            Random random = new Random();

            while (isRunning)
            {
                Console.WriteLine("Admin task in progress.");
                lock (dataLock)
                {
                    productManager.AddNewTestProduct();
                }

                Thread.Sleep(random.Next(6000, 16000));
            }
        }

        public void UpdateGUI()
        {
            Random random = new Random();
            while (isRunning)
            {
                Console.WriteLine("Updating GUI.");

                lock (dataLock)
                {
                    string[] products = productManager.GetProductInfoStrings();
                    for (int i = 0; i < products.Length; i++)
                    {
                        form.UpdateProducts(products[i], i);
                    }

                    string[] loans = loanItemManager.GetLoanInfoStrings();
                    for (int i = 0; i < loans.Length; i++)
                    {
                        form.UpdateLoans(loans[i], i);
                    }
                }

                Thread.Sleep(random.Next(1000, 2000));
            }
        }
    }
}
