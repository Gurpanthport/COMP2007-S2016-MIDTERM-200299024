<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDoDetails.aspx.cs" Inherits="COMP2007_S2016_2002990241.ToDoDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
        <div class="row">
            <div class="col-md-offset-1 col-md-5">
                <h5>To Do Name</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="todoName">To Do Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="todoName" placeholder="To Do Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    
                    <asp:TextBox runat="server" CssClass="form-control" ID="todoNotes" placeholder="To Do Notes" required="true"></asp:TextBox>
                </div> 
                 <div>
             <asp:TemplateField class="form-group">
                 <label class="control-label" for="todoCheck">Completed</label>
                    <ItemTemplate>
                        <asp:CheckBox ID="todoCheck" runat="server" />
                     </ItemTemplate>
            </asp:TemplateField>

                 </div>
                 <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                  <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                
               
            </div>
            
            </div>
            <div>
           
                
               
                </div>
                
</div>
</asp:Content>
