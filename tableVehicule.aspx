<%@ Page Title="" Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="tableVehicule.aspx.cs" Inherits="AT7_AT8_projet.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <br />
        <h1>Gestion véhicule </h1><br />
         <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlIdVehicule" CssClass="form-control bg-white " Width="400px" OnSelectedIndexChanged="ddlIdVehicule_SelectedIndexChanged"
                AppendDataBoundItems="true">
                <asp:ListItem Text="Tous" Value="Tous"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:GridView ID="gv_Vehicule" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Immatricule" OnRowCancelingEdit="gv_Vehicule_RowCancelingEdit" CssClass="table  table-striped table-hover"
                OnRowDeleting="gv_Vehicule_RowDeleting" OnRowUpdating="gv_Vehicule_RowUpdating" OnRowEditing="gv_Vehicule_RowEditing" >
                <Columns>
                    <asp:TemplateField HeaderText="Immatricule">
                      
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxImmatricule" runat="server" Text='<%# Eval("Immatricule") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Immatricule") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marque">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxMarque" runat="server" Text='<%# Eval("Marque") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Marque") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type Véhicule">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxType_Vehicule" runat="server" Text='<%# Eval("Type_Vehicule") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Type_Vehicule") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Mise Service">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxDt_Mise_Service" runat="server" Text='<%# Eval("Dt_Mise_Service") %>' TextMode="DateTime"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Dt_Mise_Service") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
       

    </div>
</asp:Content>
