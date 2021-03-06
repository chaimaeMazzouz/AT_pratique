<%@ Page Theme="membreTheme" Title="" Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="membre.aspx.cs" Inherits="AT7_AT8_projet.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bootstrap snippets bootdey">
 
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading ">
                            <img class="rounded-circle  img-thumbnail"  width="100" src="Images/profile.png" alt="Membre">
                            <asp:Label ID="lblHeader"  runat="server" class="font-weight-bold"></asp:Label>
                    </div>
                    <div class="panel-body"> 
                        <div class="table-responsive">
                        <table class="table">
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
                </div>
                </div>
                 <asp:Button ID="BtnDeconnecter" runat="server" Text="Déconnecter"  CssClass="btn btn-primary" OnClick="BtnDeconnecter_Click" ></asp:Button>
                 <asp:Button ID="BtnModifier" runat="server" Text="Modifier"  CssClass="btn btn-success pull-right" OnClick="BtnModifier_Click" ></asp:Button>
                <div class="text-center w-100">
                        <p class="text-muted font-weight-bold">
                            <asp:HyperLink ID="hlTable" runat="server" Text="" NavigateUrl=""></asp:HyperLink></p>
                    </div>
            </div>
        </div>
    </div>

</asp:Content>
