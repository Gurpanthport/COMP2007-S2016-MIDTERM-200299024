using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_2002990241.Models;
using System.Web.ModelBinding;

namespace COMP2007_S2016_2002990241
{
	public partial class ToDoDetails : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetList();
            }
        }

        protected void GetList()
        {
            // populate the form with existing todo data from the db
            int ToDoID = Convert.ToInt32(Request.QueryString["todoID"]);
            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a todo instance with the todoID from the URL parameter
                Todo updatedList = (from List in db.Todos
                                    where List.TodoID == ToDoID
                                    select List).FirstOrDefault();

                // map the todo properties to the form controls
                if (updatedList != null)
                {
                    
                    todoName.Text = updatedList.TodoName;
                    todoNotes.Text = updatedList.TodoNotes;
                    todoCheck.Checked = updatedList.Completed.HasValue;
                }

            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Default page
            Response.Redirect("~/Default.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (TodoConnection db = new TodoConnection())
            {
                Todo newList = new Todo();

                int ToDoID = 0;
                if (Request.QueryString.Count > 0)
                {
                    ToDoID = Convert.ToInt32(Request.QueryString["toDoID"]);
                    //Get the current game form the EF
                    newList = (from todo in db.Todos
                               where todo.TodoID == ToDoID
                               select todo).FirstOrDefault();
                }

                newList.TodoName = todoName.Text;
                newList.TodoNotes = todoNotes.Text;
                int value;
                if (todoCheck.Checked)
                {
                    newList.Completed = todoCheck.Checked;

                }
                else
                {
                    newList.Completed = null;
                }




                //Use linq to add or insert
                if (ToDoID == 0)
                {
                    db.Todos.Add(newList);
                }


                db.SaveChanges();

                Response.Redirect("~/ToDoList.aspx");
            }
        }
    }
}