<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_2002990241.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     -               <a href="todoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> ADD To Do List</a> 
     <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                 <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="ToDoGridView" AutoGenerateColumns="false" DataKeyNames="toDoID" OnRowDeleting="ToDoGridView_RowDeleting">
        <Columns>

            <asp:BoundField DataField="ToDoName" HeaderText="To Do Name" Visible="true" /> 
            <asp:BoundField DataField="ToDoNotes" HeaderText="To Do Notes" Visible="true" /> 
           <asp:TemplateField HeaderText="Check Box" >
        <ItemTemplate>
            <asp:CheckBox Datafield="Completed" runat="server" />
        </ItemTemplate>
        </asp:TemplateField>
         <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i>Edit" 
                            NavigateUrl="~/ToDoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="ToDoID" DataNavigateUrlFormatString="ToDoDetails.aspx?ToDoID={0}" />
           
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
        </Columns>
                </asp:GridView>
            </div>
        </div>
    
</div>
</asp:Content>
