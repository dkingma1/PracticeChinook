using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Security Namespace
using ChinookSystem.Security;
#endregion

public partial class Admin_Security_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RoleListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
    {
        DataBind();
    }

    protected void RoleListView_ItemDeleted(object sender, ListViewDeletedEventArgs e)
    {
        DataBind();
    }

    protected void RefreshAll(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void UnregisteredUsersGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //Position the gridView to the selectedindex (row) that caused the postback
        UnregisteredUsersGridView.SelectedIndex = e.NewSelectedIndex;

        //Setup a variable that will be the physical pointer to the selected row
        GridViewRow agvrow = UnregisteredUsersGridView.SelectedRow;

        //You can always check a pointer to see if something has been obtained
        if (agvrow != null)
        {
            //Access information contained in a textbox on the gridview row. We are going to use the method .FindCOntrol("controlidname") as controltype. Once you have a pointer to the control, you can access the data content on the control using the controls access method.
            string assignedusername = "";
            TextBox inputControl = agvrow.FindControl("AssignedUserName") as TextBox;
            if (inputControl != null)
            {
                assignedusername = inputControl.Text;
            }
            string assignedemail = (agvrow.FindControl("AssignedEmail") as TextBox).Text;

            //Create the UnregisteredUser instance. Durng creation I will pass to it the needed data to load ht einstance attributes.
            //Accessing bound fields on a gridview row uses .Cells[index].Text Idex represents the column of the grid. Columns are indexed(Starting at 0)
            UnregisteredUserProfile user = new UnregisteredUserProfile()
            {
                UserId = int.Parse(UnregisteredUsersGridView.SelectedDataKey.Value.ToString()),
                UserType = (UnregisteredUserType)Enum.Parse(typeof(UnregisteredUserType), agvrow.Cells[1].Text),
                FirstName = agvrow.Cells[2].Text,
                LastName = agvrow.Cells[3].Text,
                UserName = assignedusername,
                EmailAddress = assignedemail
            };

            //Register the user via the Chinook.UserManager controller
            UserManager sysmgr = new UserManager();
            sysmgr.RegisterUser(user);

            //Assume sucessful creation of a user. Refresh the form.
            DataBind();
        }
    }
}