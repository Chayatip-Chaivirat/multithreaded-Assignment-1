namespace LoanManagementSys;

public partial class MainForm : Form
{
    //private LoanSysManager loanSystem;

    public MainForm()
    {
        InitializeComponent();
        //loanSystem = new LoanSysManager(lstOutput, lstItems);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        //loanSystem.Start();

        //This code is only an example of how 
        //you can update the list boxes or other 
        //components on the GUI. Use the  code 
        //in UpdateProducts in the class where you create your 
        //tasks and threads to update the listboxes on the 
        //MainForm.
        string[] items = { "Product 1", "Product 2", "Product 3" };

        for (int i = 0; i < items.Length; i++)
        {
            UpdateProducts(items[i], i);
        }
        
    }
    private void UpdateProducts(string item, int i)
    {
        if (lstItems.InvokeRequired)
        {
            lstItems.Invoke(new Action<string, int>(UpdateProducts), item);
        }
        else
        {
            if (i == 0)
                lstItems.Items.Clear();

            lstItems.Items.Add(item);
        }
    }


    private void btnStop_Click(object sender, EventArgs e)
    {
        //loanSystem.Stop();
   }


    private void UpdateProductListBox(string item, int i)
    {
        // Check if we need to call Invoke to marshal the call to the UI thread
        if (lstItems.InvokeRequired)
        {
            lstItems.Invoke(new Action<string, int>(UpdateProductListBox), item, i);
        }
        else
        {
            if (i == 0)
                lstItems.Items.Clear();

            lstItems.Items.Add(item);
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // loanThread = null;
        // returnThread = null;
        //loanSystem.Stop();
        Application.Exit();
    }
}