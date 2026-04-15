using LoanManagementSys.Managers;
using System.Threading.Tasks;
namespace LoanManagementSys;

public partial class MainForm : Form
{
    private LoanSystemManager loanSystem;

    public MainForm()
    {
        InitializeComponent();
        loanSystem = new LoanSystemManager(this);
    }

    public void BtnOK_Click(object sender, EventArgs e)
    {
        loanSystem.Start();

        //This code is only an example of how 
        //you can update the list boxes or other 
        //components on the GUI. Use the  code 
        //in UpdateProducts in the class where you create your 
        //tasks and threads to update the listboxes on the 
        //MainForm.
        //string[] items = { "Product 1", "Product 2", "Product 3" };

        //for (int i = 0; i < items.Length; i++)
        //{
        //    UpdateProducts(items[i], i);
        //}
        
    }
    public void UpdateProducts(string item, int i)
    {
        if (lstItems.InvokeRequired)
        {
            lstItems.Invoke(new Action<string, int>(UpdateProducts), item, i);
        }
        else
        {
            if (i == 0)
                lstItems.Items.Clear();

            lstItems.Items.Add(item);
        }
    }

    public void UpdateLoans(string item, int i)
    {
        if (lstOutput.InvokeRequired)
        {
            lstOutput.Invoke(new Action<string, int>(UpdateLoans), item, i);

        }
        else
        {
            if (i == 0)
                lstOutput.Items.Clear();
            lstOutput.Items.Add(item);
        }
    }


    public void BtnStop_Click(object sender, EventArgs e)
    {
        loanSystem.Stop();
   }


    public void UpdateProductListBox(string item, int i)
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

    public void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        //loanThread = null;
        // returnThread = null;
        loanSystem.Stop();
        Application.Exit();
    }
}