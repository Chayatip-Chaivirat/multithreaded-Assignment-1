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
            loanThread = null;
            returnThread = null;
            adminThread = null;
            updateGUIThread = null;
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
                            productManager.Remove(productIndex, productManager.retuns);
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
                    productManager.allProductAdded.Add(productManager.Get(productManager.Count - 1)); // Add the newly added product to the allProductAdded list
                }

                Thread.Sleep(random.Next(6000, 16000));
            }
        }
        public void UpdateEventLogListBox(Exception ex)
        {
            ex.Message.ToString();
        }

        public void UpdateGUI()
        {
            Random random = new Random();
            while (isRunning)
            {
                Console.WriteLine("Updating GUI.");

                lock (dataLock)
                {
                    string[] addedProducts = productManager.GetAddedProductInfoStrings();
                    string[] loans = loanItemManager.GetLoanInfoStrings();
                    string[] returnedProducts = loanItemManager.GetReturnInfoStrings();

                    List<string> eventLog = new List<string>();

                    for (int i = 0; i < loans.Length; i++) // Add loan info to event log
                    {
                       eventLog.Add(loans[i]);
                        for (int j = 0; j < returnedProducts.Length; j++) // Add return info to event log
                        {
                            eventLog.Add(returnedProducts[j]);
                            for (int k = 0; k < addedProducts.Length; k++) // Add added new products info to event log
                            {
                                eventLog.Add(addedProducts[k]);
                            }
                        }
                    }

                    for (int i = 0; i < eventLog.Count; i++) // Update the loans list box with the event log info
                    {
                        form.UpdateLoans(eventLog[i], i);
                    }

                    string[] products = productManager.GetProductInfoStrings();
                    string[] loanedItems = loanItemManager.GetLoanInfo();
                    List<string> productLog = new List<string>();

                    for (int i = 0; i < products.Length; i++)
                    {
                        productLog.Add(products[i]);
                    }
                    for (int j = 0; j < loanedItems.Length; j++)
                    {
                        productLog.Add(loanedItems[j]);
                    }

                    for (int i = 0; i < productLog.Count; i++) // Update the products list box with the product log info
                    {
                        form.UpdateProducts(productLog[i], i);
                    }
                    
                }

                Thread.Sleep(random.Next(1000, 2000));
            }
        }
    }
}
