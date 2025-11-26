<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hakkimizda.aspx.cs" Inherits="_241613010_Kerem_Isik_NtpProje.hakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Ekip üyelerini kapsayan kutu */
        .team-wrapper {
            display: flex;
            flex-wrap: wrap; /* Sığmayanları alt satıra at */
            margin: 0 -15px; /* Kenar boşluklarını dengele */
            justify-content: center; /* Ortala */
        }

        /* Her bir ekip üyesi kutusu */
        .team-member-box {
            width: 25%; /* 4 tane yan yana sığsın diye %25 */
            padding: 0 10px;
            box-sizing: border-box;
            margin-bottom: 40px;
        }

            /* Resim Ayarları */
            .team-member-box .team-info img {
                width: 100%;
                height: 300px; /* Resimlerin boyunu sabitledik */
                object-fit: cover; /* Resmi bozmadan kutuya sığdır */
                display: block;
                border-radius: 4px 4px 0 0;
                box-shadow: 0 4px 6px rgba(0,0,0,0.1);
            }

            /* İsim ve Pozisyon Alanı */
            .team-member-box .title-position {
                background: #f9f9f9;
                text-align: center;
                border-bottom: 3px solid #ea5426; /* Turuncu çizgi */
                border-radius: 0 0 4px 4px;
                box-shadow: 0 2px 5px rgba(0,0,0,0.05);
            }

            .team-member-box .title h6 {
                font-size: 16px;
                font-weight: bold;
                color: #333;
                margin: 0 0 0 0;
                text-transform: uppercase;
            }

            .team-member-box .position span {
                font-size: 13px;
                color: #ea5426; /* Turuncu renk */
                font-weight: 600;
            }

            /* Biyografi Metni */
            .team-member-box .team-cv p {
                font-size: 13px;
                line-height: 1.6;
                color: #666;
                margin-top: 15px;
                text-align: justify; /* Metni iki yana yasla */
            }

        /* --- RESPONSIVE (MOBİL) AYARLARI --- */

        /* Tabletler için (2 yan yana) */
        @media (max-width: 960px) {
            .team-member-box {
                width: 50%;
            }
        }

        /* Telefonlar için (1 tane - alt alta) */
        @media (max-width: 600px) {
            .team-member-box {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="top-shadow"></div>

    <section class="page-title-container">
        <div class="container_12">
            <div class="page-title grid_12">
                <div class="title">
                    <h1>Hakkımızda</h1>
                </div>
                <ul class="breadcrumbs">
                    <li><a class="home" href="index.aspx">Home</a></li>
                    <li>/</li>
                    <li><span class="active">Hakkımızda</span></li>
                </ul>
            </div>
        </div>
    </section>
    <section id="content-wrapper">
        <div class="container_12">

            <article class="grid_6">
                <section class="section-title left">
                    <h3>
                        <asp:Literal ID="litTitle" runat="server"></asp:Literal></h3>
                </section>

                <span class="text-dark text-big">
                    <asp:Literal ID="litSubtitle" runat="server"></asp:Literal>
                </span>

                <br />
                <br />

                <asp:Image ID="imgAbout" runat="server" Width="100%" Visible="false" style="margin-bottom: 15px; border-radius: 5px;" />

                <p>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </p>
            </article>
            <div class="clearfix"></div>

            <article class="grid_12">
                <section class="section-title center" style="margin-top: 60px; margin-bottom: 30px;">
                    <div class="title-container">
                        <section class="title">
                            <h2>Ekibimiz</h2>
                            <span>KİSEC'in uzman güvenlik kadrosuyla tanışın.</span>
                        </section>
                    </div>
                </section>

                <div class="team-wrapper">

                    <asp:Repeater ID="rptTeam" runat="server">
                        <itemtemplate>
                            <div class="team-member-box">
                                <section class="team-info">
                                    <img src='<%# Eval("ImagePath") %>' alt="team member" />

                                    <div class="title-position">
                                        <div class="title">
                                            <h6><%# Eval("FullName") %></h6>
                                        </div>
                                        <div class="position">
                                            <span><%# Eval("Position") %></span>
                                        </div>
                                    </div>
                                </section>

                                <section class="team-cv">
                                    <p>
                                        <%# Eval("Biography") %>
                                    </p>
                                </section>
                            </div>
                        </itemtemplate>
                    </asp:Repeater>

                </div>
            </article>
        </div>
    </section>
    <script src="js/jquery-1.8.3.js"></script>
    <script src="js/jquery.placeholder.min.js"></script>
    <script src="js/jquery.carouFredSel-6.0.0-packed.js"></script>
    <script src="js/jquery.nivo.slider.js"></script>
    <script src="js/jquery.touchSwipe-1.2.5.js"></script>
    <script src="style-switcher/styleSwitcher.js"></script>
    <script src="js/include.js"></script>

    <script>
        /* <![CDATA[ */
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
        /* ]]> */
    </script>
</asp:Content>
