using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys;

/*
  The task of this thread class is to send request to the controller to
  update the list of products that are on loand as wekk as  the list
  available products on the UI using at certain intervals (e.g 2 seconds).

  Note: loanSys is a reference to an object of the LoanSystem which
  is a class which creates the threads and  also updates the MainForm.
  It has the reference to the listboxes for updating.
*/
internal class UpdateGUI
{
    private Random random;
    private bool isRunning = true; //to start and stop the thread
    //private LoanSysManager loanSys;

    //constructor
    public UpdateGUI(/*LoanSysManager loanSys*/)
    {
       // this.loanSys = loanSys;
        random = new Random();
    }

    //Sets isRunning to true/fals; when true, the thread continues processing and
    //if false, it stops
    public bool IsRunning { get; set; } = true;


    //This method is run by the thread assigned to perform the task. It requests
    //updating the list of products and the list of items on loan by the controller.
    public void Run()
    {
        try
        {
            while (isRunning)
            {

                // Update any UI  - UpdateLoanIemList
                
                //loanSys.UpdateAllItems();  
                Thread.Sleep(2000); // Simulate some operation
            }
        }
        catch (Exception ex)
        {
            //loanSys.UpdateEventLogListBox(ex.Message);
        }
    }

}

