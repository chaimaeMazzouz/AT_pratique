<%@ Page Title="" Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="gestionMembres.aspx.cs" Inherits="AT7_AT8_projet.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <h2>Gestion des membres</h2>
         <div class="table-responsive" >
                        <table class="table" >
                              
                                 <tr>
                                    <td><strong>Pseudo :</strong></td>
                                    <td>
                                        
                                        <asp:TextBox ID="TextBoxPseudo" runat="server" class="form-control" type="text" ReadOnly="True"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td><strong>Prénom :</strong></td>
                                    <td>
                                        <asp:TextBox  ID="Prenom"  runat="server" class="form-control" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td><strong>Nom :</strong></td>
                                    <td>
                                        <asp:TextBox  ID="Nom"  runat="server" class="form-control" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td><strong>Email :</strong></td>
                                    <td>
                                        <asp:TextBox  ID="Email"  runat="server" class="form-control" type="email"/>
                                    </td>
                                </tr>
                             <tr>
                                    <td><strong>Matricule:</strong></td>
                                    <td>
                                        <asp:TextBox  ID="matricule"  runat="server" class="form-control" type="text"/>
                                    </td>
                                </tr>
                             <tr>
                                    <td><strong>Service :</strong></td>
                                    <td>
                                         <asp:DropDownList ID="DdlService" runat="server" CssClass="form-control bg-white border-md">
                                            <asp:ListItem>Service</asp:ListItem>
                                            <asp:ListItem>Ressources Humaines</asp:ListItem>
                                            <asp:ListItem>Logistique</asp:ListItem>
                                            <asp:ListItem>Marketing</asp:ListItem>
                                         </asp:DropDownList>
                                    </td>
                                </tr>
                               
                        </table>
                    </div>
               <div >
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateSelectButton="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                </asp:GridView>
              </div>
                 <asp:Button ID="BtnModifier" runat="server" Text="Modifier"  CssClass="btn btn-success mr-4" OnClick="BtnModifier_Click"  ></asp:Button>
       <asp:Button ID="BtnSupprimer" runat="server" Text="Supprimer"  CssClass="btn btn-primary " OnClick="BtnSupprimer_Click" ></asp:Button>
     
    &nbsp;</div>
</asp:Content>
