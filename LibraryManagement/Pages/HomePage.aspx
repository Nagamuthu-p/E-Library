<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="LibraryManagement.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container">
            <div class=" row d-flex justify-content-between align-items-center " style="height: 500px;">
                <div class=" col-12 col-md-6 d-flex justify-content-center align-items-center" style="flex: 1;">
                    <img src="../Image/svg/home.svg" class="img-fluid" width="500" height="500" />
                </div>
                <div class=" col-12 col-md-6 justify-content-lg-start" style="flex: 1;">
                    <h1 class="text-black fs-3 fw-bold" style="font-size: 3rem;">Library Management System</h1>
                    <p class="fw-light">
                        Web Forms are pages that are requested by your users through their browser. HTML, client-script, server controls, and server code can all be used to create these pages. When users request a page, the framework compiles and executes it on the server, then it generates the HTML markup that the browser may render. In any browser or client device, an ASP .NET Web Forms page displays information to the user.
                    </p>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="container mb-3 ">
            <div class="row">
                
                    <div class="col-12">
                        <center>
                        <h2>Our Products</h2>
                            </center>
                    </div>
                
            </div>

            <div class="row mt-3">
                <div class="col-md-4">
                    <center>
                        <img src="../Fontawesome/svgs/regular/address-book.svg" width="50" height="50" class="card-img" />
                        <h4>Books</h4>
                        <p class="fw-light text-justify ">Web Forms are pages that are requested by your users through their browser. HTML, client-script, server controls, and server code</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img src="../Fontawesome/svgs/regular/address-book.svg" width="50" height="50" class="card-img" />
                        <h4>Books</h4>
                        <p class="fw-light text-justify">Web Forms are pages that are requested by your users through their browser. HTML, client-script, server controls, and server code</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img src="../Fontawesome/svgs/regular/address-book.svg" width="50" height="50" class="card-img" />
                        <h4>Books</h4>
                        <p class="fw-light text-justify ">Web Forms are pages that are requested by your users through their browser. HTML, client-script, server controls, and server code</p>
                    </center>
                </div>
            </div>

        </div>

    </section>


</asp:Content>
