﻿<%@ Page Theme="indexTheme" Title="" Language="C#" MasterPageFile="~/CompagnieVoyage.Master" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="AT7_AT8_projet.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Registeration Form -->
    <div class="container">
       
                  <div class="row  mt-4 justify-content-md-center">
                    <!-- First Name -->
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-user text-muted"></i>
                            </span>
                        </div>
                        <input id="firstName" type="text" name="firstname" placeholder="Prénom" class="form-control bg-white border-left-0 border-md">
                    </div>

                    <!-- Last Name -->
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-user text-muted"></i>
                            </span>
                        </div>
                        <input id="lastName" type="text" name="lastname" placeholder="Nom" class="form-control bg-white border-left-0 border-md">
                    </div>
                   </div>
                    <!-- Email Address -->
                  <div class="row  mt-4 justify-content-md-center">
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-envelope text-muted"></i>
                            </span>
                        </div>
                        <input id="email" type="email" name="email" placeholder="Email Address" class="form-control bg-white border-left-0 border-md">
                    </div>
                       <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-car text-muted"></i>
                            </span>
                        </div>
                        <input id="matricule" type="text" name="matricule" placeholder="Matricule" class="form-control bg-white border-left-0 border-md">
                    </div>
                  </div>
                 <!-- Password Confirmation -->
           <div class="row  mt-4 justify-content-md-center">
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-black-tie text-muted"></i>
                            </span>
                        </div>
                        <asp:DropDownList ID="DdlService" runat="server" CssClass="form-control bg-white border-left-0 border-md">
                           <asp:ListItem>Service</asp:ListItem>
                           <asp:ListItem>Ressources Humaines</asp:ListItem>
                          <asp:ListItem>Logistique</asp:ListItem>
                          <asp:ListItem>Marketing</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-user text-muted"></i>
                            </span>
                        </div>
                        <asp:DropDownList ID="DdlCategorie" runat="server" CssClass="form-control bg-white border-left-0 border-md">
                           <asp:ListItem>Catégorie</asp:ListItem>
                           <asp:ListItem>Membre</asp:ListItem>
                          <asp:ListItem>Administrateur</asp:ListItem>
                          <asp:ListItem>Super Administrateur</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </div>
                 
                    <!-- Password -->
                  <div class="row  mt-4 justify-content-md-center">
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-lock text-muted"></i>
                            </span>
                        </div>
                        <input id="password" type="password" name="password" placeholder="Password" class="form-control bg-white border-left-0 border-md">
                    </div>

                    <!-- Password Confirmation -->
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-lock text-muted"></i>
                            </span>
                        </div>
                        <input id="passwordConfirmation" type="text" name="passwordConfirmation" placeholder="Confirm Password" class="form-control bg-white border-left-0 border-md">
                    </div>
                 </div>
         <!-- Pseudo -->
                  <div class="row  mt-4 justify-content-md-left">
                    <div class="input-group col-lg-6 mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text bg-white px-4 border-md border-right-0">
                                <i class="fa fa-key text-muted"></i>
                            </span>
                        </div>
                        <input id="pseudo" type="Text" name="pseudo" placeholder="Pseudo" class="form-control bg-white border-left-0 border-md">
                    </div>
                      </div>
                    <!-- Submit Button -->
                   <div class="row  mt-4 justify-content-md-center">
                    <div class="form-group col-lg-12 mx-auto mb-0">
                        <a href="#" class="btn btn-primary btn-block py-2">
                            <span class="font-weight-bold">Create your account</span>
                        </a>
                    </div>
                </div>

                 
                    <!-- Already Registered -->
                    <div class="text-center w-100">
                        <p class="text-muted font-weight-bold">Déjà enregistré? <a href="index.aspx" class="text-primary ml-2">s'authentifier</a></p>
                    </div>

                </div>
 
        
</asp:Content>