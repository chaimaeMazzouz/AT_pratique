<%@ Page Theme="indexTheme" Title=""  Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AT7_AT8_projet.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">

                <!-- Image -->
                <div class="row  mt-4 justify-content-md-center">
                         <img src="Images/profile.png" alt="Admin" class="rounded-circle" width="150">
                        
               </div>
        
                    <!-- Pseudo -->
                <div class="row  mt-4 justify-content-md-center">
                    <div class="input-group col col-lg-6 mb-4 ">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-user text-muted"></i>
                            </span>
                        </div>
                        <asp:TextBox  ID="Pseudo"  runat="server"  type="text" name="Pseudo" placeholder="Pseudo" class="form-control bg-white border-left-0 border-md"/>
                    </div>
               </div>
        
                    <!-- Password -->
                <div class="row  mt-4 justify-content-md-center">
                    <div class="input-group col col-lg-6 mb-4 ">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-lock text-muted"></i>
                            </span>
                        </div>
                        <asp:TextBox ID="password"  runat="server" type="password" name="password" placeholder="Mot de passe" class="form-control bg-white border-left-0 border-md"/>
                    </div>
                   </div>
                 
                    <!-- Submit Button -->
        <div class="row mt-4 justify-content-md-center">
                    <div class="form-group col col-lg-6 mb-4">
                        <asp:Button ID="BtnAuthentifier" runat="server" Text="S'authentifier"  CssClass="btn btn-primary btn-block py-2 font-weight-bold" OnClick="BtnAuthentifier_Click">
                       
                        </asp:Button>
                    </div>
            </div>

                    <!--Registered -->
                    <div class="text-center w-100">
                        <p class="text-muted font-weight-bold">Créer un compte <a href="inscription.aspx" class="text-primary ml-2">s'inscrire</a></p>
                    </div>

                </div>
       
    
</asp:Content>
