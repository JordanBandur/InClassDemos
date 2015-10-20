using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Addintional Namespace
using eRestaurantSystem.BLL;
using eRestaurantSystem.DAL.Entities;
using EatIn.UI;
#endregion

public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HireDate.Text = DateTime.Today.ToShortDateString();
        }
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }
    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        //to properly interface with our MessageUserControl we will delegate the execution
        //of this click event under the MessageUserControl
        if (WaiterList.SelectedIndex == 0)
        {
            //issue our own error message
            MessageUserControl.ShowInfo("Please select a waiter to process");
        }
        else
        {
            //execute the necessary standard lookup code under the control of the MessageUserControl
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
        }

    }

    public void GetWaiterInfo()
    {
        //a standard lookup process
        AdminController SystemManager = new AdminController();
        var waiter = SystemManager.GetWaiterByID(int.Parse(WaiterList.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Address.Text = waiter.Address;
        Phone.Text = waiter.Phone;
        HireDate.Text = waiter.HireDate.ToShortDateString();
        //null field check
        if (waiter.ReleaseDate.HasValue)
        {
            ReleaseDate.Text = waiter.ReleaseDate.ToString();
        }
        else
        {
            ReleaseDate.Text = "";
        }
    }
    protected void WaiterInsert_Click(object sender, EventArgs e)
    {
        //inline version of using MessageUserControl
        MessageUserControl.TryRun(() =>
            //remainder of the code is what would have gone in the external method of 
            //(processRequest(MethodName)
            {
                Waiter item = new Waiter();
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Address = Address.Text;
                item.Phone = Phone.Text;
                item.HireDate = DateTime.Parse(HireDate.Text);
                //nullable field
                if(string.IsNullOrEmpty(ReleaseDate.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(ReleaseDate.Text);
                }

                AdminController SystemManager = new AdminController();
                WaiterID.Text = SystemManager.Waiters_Add(item).ToString();
                MessageUserControl.ShowInfo("Waiter added");
            }
            );
    }
    protected void WaiterUpdate_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(WaiterID.Text))
        {
            MessageUserControl.ShowInfo("Please select a waiter before updating");
        }
        else
        {
            //standard update process
            MessageUserControl.TryRun(() =>
            //remainder of the code is what would have gone in the external method of 
            //(processRequest(MethodName)
            {
                Waiter item = new Waiter();
                //for an update you must supply the pk value
                item.WaiterID = int.Parse(WaiterID.Text);
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Address = Address.Text;
                item.Phone = Phone.Text;
                item.HireDate = DateTime.Parse(HireDate.Text);
                //nullable field
                if (string.IsNullOrEmpty(ReleaseDate.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(ReleaseDate.Text);
                }

                AdminController SystemManager = new AdminController();
                SystemManager.Waiters_Update(item);
                MessageUserControl.ShowInfo("Waiter updated");
            }
            );

        }
    }
}