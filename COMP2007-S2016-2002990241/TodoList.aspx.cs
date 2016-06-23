using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_2002990241.Models;
using System.Web.ModelBinding;
/**
 * Project Name:  COMP2007_S2016_2002990241
 * Name: Gurpanth Singh
 * Student Number: 200299024
 * */
namespace COMP2007_S2016_2002990241
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Populate the List
            if (!IsPostBack)
            {
                //get the list data
                this.GetList();
                
            }
        }
       
        protected void GetList()
        {
            using (TodoConnection db = new TodoConnection())
            {
                var todo = (from allItems in db.Todos
                            select allItems);

               
                //Bind the result
                ToDoGridView.DataSource = todo.ToList();
                ToDoGridView.DataBind();
                
            }
        }

        protected void ToDoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;
            //get the select list id using the grids
            int toDoID = Convert.ToInt32(ToDoGridView.DataKeys[selectedRow].Values["toDoID"]);
            //Removing  the data
            using (TodoConnection db = new TodoConnection())
            {
                Todo deletedList = (from todoRecords in db.Todos
                                    where todoRecords.TodoID == toDoID
                                    select todoRecords).FirstOrDefault();

                //delete the selected todolist from the database
                db.Todos.Remove(deletedList);

                db.SaveChanges();
                //Refresh the grid
                this.GetList();
            }
        }
    }
}