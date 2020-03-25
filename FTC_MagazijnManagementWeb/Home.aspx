﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MagazijnManagement.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FTC_MagazijnManagementWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home - Magazijn Management</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body1" runat="server">
    <!-- Masthead-->
    <header class="masthead">
        <div class="container h-100">
            <div class="row h-100 align-items-center justify-content-center text-center">
                <div class="col-lg-8 align-self-end">
                    <h1 class="text-uppercase text-white font-weight-bold">FTC P-Generation</h1>
                    <hr class="divider my-4" />
                </div>
                <div class="col-lg-9 align-self-baseline">
                    <p class="text-white-75 font-weight-light mb-5">Heeft u een nieuwe laptop, desktop, tablet, ... nodig maar wilt u liever minder betalen?
                        <br />
                        Bij P-Generation bent u aan het juiste adres!</p>
                    <a class="btn btn-primary btn-xl js-scroll-trigger" href="#about">Meer details</a>
                </div>
            </div>
        </div>
    </header>
    <!-- About section-->
    <section class="page-section bg-primary" id="about">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-9 text-center">
                    <h2 class="text-white mt-0">Over ons</h2>
                    <hr class="divider light my-4" />
                    <p class="text-white-75 font-weight-light mb-5">FTC P-Generation handelt in tweedehandstoestellen sinds 2003, vooral in laptops en desktops. Zij zijn vrijwel de enige in de Belgische groothandel en zijn recent ook meer gaan focussen op particulieren. Hun grootste verkoopcijfers gaan naar scholen maar een groot aantal particulieren komen naar FTC voor de goede prijs-kwaliteitverhouding en garantie op een groot bereik aan producten.</p>
                    <a class="btn btn-light btn-xl js-scroll-trigger" href="https://pgeneration.be/shop/">Onze webshop</a>
                </div>
            </div>
        </div>
    </section>
    <!-- Services section-->
    <section class="page-section" id="services">
        <div class="container">
            <h2 class="text-center mt-0">Onze diensten</h2>
            <hr class="divider my-4" />
            <div class="row">
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="mt-5">
                        <i class="fas fa-4x fa-expand-arrows-alt text-primary mb-4"></i>
                        <h3 class="h4 mb-2">Direct leverbaar</h3>
                        <p class="text-muted mb-0">Via bPost aan huis, op kantoor of in een postpunt geleverd</p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="mt-5">
                        <i class="fas fa-4x fa-truck text-primary mb-4"></i>
                        <h3 class="h4 mb-2">Gratis levering</h3>
                        <p class="text-muted mb-0">Vanaf 5 stuks</p>
                        <p class="text-muted mb-0">(vraag uw offerte)</p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="mt-5">
                        <i class="fas fa-4x fa-warehouse text-primary mb-4"></i>
                        <h3 class="h4 mb-2">Afhaling mogelijk</h3>
                        <p class="text-muted mb-0">Na 13u werkdag na bestelling</p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="mt-5">
                        <i class="fas fa-4x fa-award text-primary mb-4"></i>
                        <h3 class="h4 mb-2">Ruime garantie</h3>
                        <p class="text-muted mb-0">6 maanden op herstellingen</p>
                        <p class="text-muted mb-0">1 jaar op computers en laptops</p>
                        <p class="text-muted mb-0">2 jaar op iPhones en iPads</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Contact section-->
    <section class="page-section bg-dark text-white" id="contact">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 text-center">
                    <h2 class="mt-0">Contacteer ons</h2>
                    <hr class="divider my-4" />
                    <p class="text-white-75 mb-5">Wilt u een aankoop doen of meer informatie verkrijgen, aarzel niet om ons te contacteren!</p>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 ml-auto text-center mb-5 mb-lg-0">
                    <i class="fas fa-phone fa-3x mb-3"></i>
                    <div>03/645.49.40</div>
                </div>
                <div class="col-lg-4 ml-auto text-center mb-5 mb-lg-0">
                    <i class="fas fa-globe fa-3x mb-3"></i>
                    <p class="mb-5">Ga naar onze<a class="d-block" href="https://pgeneration.be/">officiële website</a></p>
                </div>
                <div class="col-lg-4 mr-auto text-center">
                    <i class="fas fa-envelope fa-3x mb-3"></i>
                    <!-- Make sure to change the email address in BOTH the anchor text and the link target below!-->
                    <p class="mb-5">
                        Offertes & Bestellingen:<a class="d-block" href="mailto:verkoop@ftc.be">verkoop@ftc.be</a>
                        Technische dienst:<a class="d-block" href="mailto:depot@ftc.be">depot@ftc.be</a>
                    </p>
                </div>
            </div>
        </div>
    </section>
    <div class="text-center bg-primary">
        <img src="assets\img\profilepic.jpg" alt="Avatar" style="border-radius: 50%; width: 200px; margin-top: -200px; margin-bottom: -200px; border: 5px solid white; box-shadow: 0px 0px 50px black">
    </div>
    <!-- Creator section-->
    <section class="page-section bg-primary" id="creator">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 text-center">
                    <h2 class="text-white mt-0">Over mij</h2>
                    <hr class="divider light my-4" />
                    <p class="text-white-75 font-weight-light mb-5">Ik ben Dries Magnus en ik ben 18 jaar. Ik studeer dit jaar af in de richting Informaticabeheer aan de Secundaire Handelsschool Sint-Lodewijk.<br/>Voor mijn eindwerk moest ik een web-applicatie maken die de gebruiker toelaat om een magazijn te beheren die apparaten en leveringen bevat.<br/><br/>Om toegang te krijgen tot deze applicatie, druk op het knop hieronder.</p>
                    <a class="btn btn-light btn-xl js-scroll-trigger" href="#">Log in</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
