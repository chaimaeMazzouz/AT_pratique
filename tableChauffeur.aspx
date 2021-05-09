<%@ Page Title="" Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="tableChauffeur.aspx.cs" Inherits="AT7_AT8_projet.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Gestion Chauffeur<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" DeleteCommand="DELETE FROM [chauffeur] WHERE [ID_chauffeur] = @ID_chauffeur" InsertCommand="INSERT INTO [chauffeur] ([ID_chauffeur], [Nom], [Prenom], [Adresse], [Date_Recrutement], [Salaire]) VALUES (@ID_chauffeur, @Nom, @Prenom, @Adresse, @Date_Recrutement, @Salaire)" SelectCommand="SELECT * FROM [chauffeur]" UpdateCommand="UPDATE [chauffeur] SET [Nom] = @Nom, [Prenom] = @Prenom, [Adresse] = @Adresse, [Date_Recrutement] = @Date_Recrutement, [Salaire] = @Salaire WHERE [ID_chauffeur] = @ID_chauffeur">
            <DeleteParameters>
                <asp:Parameter Name="ID_chauffeur" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID_chauffeur" Type="String" />
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter DbType="Date" Name="Date_Recrutement" />
                <asp:Parameter Name="Salaire" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter DbType="Date" Name="Date_Recrutement" />
                <asp:Parameter Name="Salaire" Type="Decimal" />
                <asp:Parameter Name="ID_chauffeur" Type="String" />
            </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </h1>

    </div>
</asp:Content>
