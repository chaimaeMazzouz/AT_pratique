<%@ Page Title="" Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="tablesVoyageBillet.aspx.cs" Inherits="AT7_AT8_projet.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div>
        <br />
        <h1>Gestion Voyage </h1><br />
         <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlIdVehicule" CssClass="form-control bg-white " Width="400px" OnSelectedIndexChanged="ddlIdVehicule_SelectedIndexChanged"
                AppendDataBoundItems="true">
                <asp:ListItem Text="Tous" Value="Tous"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:GridView ID="gv_Voyage" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID_Voyage" OnRowCancelingEdit="gv_Voyage_RowCancelingEdit" CssClass="table table-striped table-hover"
                OnRowDeleting="gv_Voyage_RowDeleting" OnRowUpdating="gv_Voyage_RowUpdating" OnRowEditing="gv_Voyage_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="ID Voyage">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxID_Voyage" runat="server" Text='<%# Eval("ID_Voyage") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label0" runat="server" Text='<%# Eval("ID_Voyage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Voyage">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxDate_Voyage" runat="server" Text='<%# Eval("Date_Voyage") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblDateV" runat="server" Text='<%# Eval("Date_Voyage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ville Départ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxVille_Depart" runat="server" Text='<%# Eval("Ville_Depart") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Ville_Depart") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Ville Arrive">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxVille_Arrive" runat="server" Text='<%# Eval("Ville_Arrive") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Ville_Arrive") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Durée">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxDuree" runat="server" Text='<%# Eval("Duree") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Duree") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Voyageurs">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxNbre_Voyageurs" runat="server" Text='<%# Eval("Nbre_Voyageurs") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Nbre_Voyageurs") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Place libre">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxPlace_libre" runat="server" Text='<%# Eval("Place_libre") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Place_libre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tarif">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxTarif" runat="server" Text='<%# Eval("Tarif") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Tarif") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ID chauffeur">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxID_chauffeur" runat="server" Text='<%# Eval("ID_chauffeur") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("ID_chauffeur") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Immatricule">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxImmatricule" runat="server" Text='<%# Eval("Immatricule") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("Immatricule") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
    </div>
       <div>
        <br />
        <h1>Gestion billet </h1><br />
         <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlBillet" CssClass="form-control bg-white " Width="400px" OnSelectedIndexChanged="ddlBillet_SelectedIndexChanged"
                AppendDataBoundItems="true">
                <asp:ListItem Text="Tous" Value="Tous"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:GridView ID="gv_billet" runat="server" AutoGenerateColumns="False"
                DataKeyNames="N_Billet" OnRowCancelingEdit="gv_billet_RowCancelingEdit" CssClass="table table-striped table-hover"
                OnRowDeleting="gv_billet_RowDeleting" OnRowUpdating="gv_billet_RowUpdating" OnRowEditing="gv_billet_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="Numéro Billet">
                      
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxN_Billet" runat="server" Text='<%# Eval("N_Billet") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labe20" runat="server" Text='<%# Eval("N_Billet") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Delivrance">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxDate_Delivrance" runat="server" Text='<%# Eval("Date_Delivrance") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("Date_Delivrance") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID Voyage">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxID_Voyage" runat="server" Text='<%# Eval("ID_Voyage") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("ID_Voyage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
       

    </div>
</asp:Content>
