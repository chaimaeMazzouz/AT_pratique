<%@ Page Title=""  Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="tableChauffeur.aspx.cs" Inherits="AT7_AT8_projet.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Gestion Chauffeur </h1>
            <asp:GridView ID="gv_Chauffeur" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID_chauffeur" OnRowCancelingEdit="gv_Chauffeur_RowCancelingEdit" CssClass="table table-responsive table-striped table-hover"
                OnRowDeleting="gv_Chauffeur_RowDeleting" OnRowUpdating="gv_Chauffeur_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID Chauffeur">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("ID_chauffeur") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ID_chauffeur") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nom">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxNom" runat="server" Text='<%# Eval("Nom") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Prénom">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxPrenom" runat="server" Text='<%# Eval("Prenom") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Prenom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Adresse">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxAdresse" runat="server" Text='<%# Eval("Adresse") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Adresse") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date recrutement">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxDateRec" runat="server" Text='<%# Eval("Date_Recrutement") %>' TextMode="DateTime"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Date_Recrutement") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Salaire">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxSalaire" runat="server" Text='<%# Eval("Salaire") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Salaire") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
       

    </div>
</asp:Content>
