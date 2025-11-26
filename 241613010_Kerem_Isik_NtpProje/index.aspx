<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_241613010_Kerem_Isik_NtpProje.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Haber resimlerini sınırlandıran sınıf */
        .news-img-fix {
            width: 100%;        /* Genişlik kutuyu doldursun */
            height: 200px;      /* Yükseklik SABİT olsun (İstediğin gibi artırabilirsin) */
            object-fit: cover;  /* Resmi bozmadan/sündürmeden kutuya sığdır */
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- .top-shadow -->
    <div class="top-shadow"></div>

    <!-- .rs-wrapper start -->
    <div class="rs-wrapper">

        <div class="fullwidthbanner-container">

            <div class="fullwidthbanner">
                <ul>
                    <asp:Repeater ID="rptSlider" runat="server">
                        <ItemTemplate>
                            <li data-transition="slotzoom-horizontal" data-slotamount="15">

                                <img src='<%# Eval("ImagePath") %>' alt="background">

                                <div class="caption lfl regular_title" data-x="335" data-y="90" data-speed="700" data-start="2000" data-easing="easeOutBack"><%# Eval("Title") %></div>

                                <div class="caption lfr regular_subtitle" data-x="390" data-y="160" data-speed="700" data-start="2400" data-easing="easeOutBack"><%# Eval("Line1") %></div>
                                <div class="caption lfr regular_subtitle" data-x="390" data-y="202" data-speed="700" data-start="2900" data-easing="easeOutBack"><%# Eval("Line2") %></div>
                                <div class="caption lfr regular_subtitle" data-x="390" data-y="242" data-speed="700" data-start="3200" data-easing="easeOutBack"><%# Eval("Line3") %></div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!-- .rs-wrapper end -->

    <!-- #content-wrapper start -->
    <section id="content-wrapper">

        <!-- .container_12 start -->
        <div class="container_12">
            <!-- .grid_12 start -->
            <article class="grid_12">

                <!-- .entry-note start -->
                <section class="entry-note">
                    <h1>Hoşgeldiniz, <span class='text-color'>KISEC</span>. Siber Güvenlik</h1>
                    <p>
                        Dijital varlıklarınızı en gelişmiş tehditlere karşı koruyan, 7/24 proaktif savunma ve yeni nesil siber güvenlik çözümleri ortağınız.
                    </p>
                </section>
                <!-- entry-note end -->
            </article>
            <!-- .grid_12 end -->

            <!-- .grid_4 start -->


            <!-- .grid_12 carousel-portfolio end -->
            <article class="grid_12 carousel-portfolio">

                <section class="section-title center">
                    <div class="title-container">
                        <section class="title">
                            <h2>Çalışmalarımız</h2>
                            <span>Çalışmalarımız ile ilgili açıklama gelecek</span>
                        </section>
                    </div>
                </section>
                <!-- .section-title .center end -->

                <ul id="foo2" class="carousel-li">
                    <asp:Repeater ID="rptPortfolioPreview" runat="server">
                        <ItemTemplate>
                            <li class="portfolio-style-2">
                                <figure class="portfolio clearfix">
                                    <div class="portfolio-image">
                                        <a href='calismalarimiz_detay.aspx?ID=<%# Eval("PortfolioID") %>'>
                                            <img src='<%# Eval("ThumbnailPath") %>' width="220" alt="portfolio" />
                                        </a>
                                        <div class="portfolio-hover">
                                            <ul>
                                                <li class="portfolio-zoom">
                                                    <a href='<%# Eval("LargeImagePath") %>' data-gal="prettyPhoto[pp_gallery]">zoom</a>
                                                </li>
                                                <li class="portfolio-single">
                                                    <a href='calismalarimiz_detay.aspx?ID=<%# Eval("PortfolioID") %>'>single</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <figcaption>
                                        <a class="title"><%# Eval("Title") %></a>
                                        <span class="subtitle"><%# Eval("Category.CategoryName") %></span>
                                    </figcaption>
                                </figure>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <!-- .carousel-li end -->

                <div class="clearfix"></div>

                <div class="carousel-pagination" id="foo2_pag"></div>

            </article>
            <!-- .grid_12 carousel-portfolio end -->

            <article class="grid_12 latest-blog-posts">

                <section class="section-title center">
                    <div class="title-container">
                        <section class="title">
                            <h2>Güncel Haberler</h2>
                        </section>
                    </div>
                </section>

                <asp:Repeater ID="rptNewsPreview" runat="server">
                    <ItemTemplate>
                        <article class='<%# Container.ItemIndex % 2 == 0 ? "grid_6 alpha" : "grid_6 omega" %>'>
                            <section class="post-info">
                                <img src='<%# Eval("ImagePath") %>' alt="blog-image" class="news-img-fix" />
                            </section>

                            <section class="post-body">
                                <div class="post-meta">
                                    <div class="title-date">
                                        <a href='haber_detay.aspx?ID=<%# Eval("NewsID") %>'>
                                            <h6><%# Eval("Title") %></h6>
                                        </a>
                                        <span class="date"><%# Eval("PublishDate", "{0:MMM dd, yyyy}") %></span>
                                    </div>
                                </div>

                                <p>
                                    <%# Eval("Summary") %>
                                </p>

                                <div class="read-more-btn">
                                    <a href='haber_detay.aspx?ID=<%# Eval("NewsID") %>'>Detaylı</a>
                                    <span class="plus">+</span>
                                </div>
                            </section>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>

                <div class="clearfix"></div>
        </div>
        <!-- .container_12 end -->

    </section>
    <!-- #content-wrapper end -->
    <!-- scripts -->
    <script src="js/jquery-1.8.3.js"></script>
    <!-- jQuery library -->
    <script src="js/jquery.placeholder.min.js"></script>
    <!-- jQuery placeholder fix for old browsers -->
    <script src="js/jquery.carouFredSel-6.0.0-packed.js"></script>
    <!-- CarouFredSel carousel plugin -->
    <script src="js/jquery.touchSwipe-1.2.5.js"></script>
    <!-- support for touch swipe on mobile devices -->
    <script src="js/jquery.prettyPhoto.js"></script>
    <!-- prettyPhoto lightbox -->
    <script src="js/portfolio.js"></script>
    <!-- portfolio custom options -->
    <script type="text/javascript" src="rs-plugin/js/jquery.themepunch.plugins.min.js"></script>
    <script type="text/javascript" src="rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
    <script src="style-switcher/styleSwitcher.js"></script>
    <!-- Style Switcher plugin -->
    <script src="js/include.js"></script>
    <!-- jQuery custom options -->

    <script>
        /* <![CDATA[ */
        // REVOLUTION SLIDER 
        jQuery(document).ready(function () {

            if (jQuery.fn.cssOriginal !== undefined)   // CHECK IF fn.css already extended
                jQuery.fn.css = jQuery.fn.cssOriginal;

            jQuery('.fullwidthbanner').revolution(
                {
                    delay: 5000,
                    startheight: 413,
                    startwidth: 940,
                    hideThumbs: 200,
                    thumbWidth: 100,
                    thumbHeight: 50,
                    thumbAmount: 5,
                    navigationType: "none",
                    navigationArrows: "verticalcentered",
                    navigationStyle: "round",
                    navigationHAlign: "right",
                    navigationVAlign: "top",
                    navigationHOffset: 0,
                    navigationVOffset: 20,
                    soloArrowLeftHalign: "left",
                    soloArrowLeftValign: "center",
                    soloArrowLeftHOffset: 20,
                    soloArrowLeftVOffset: 0,
                    soloArrowRightHalign: "right",
                    soloArrowRightValign: "center",
                    soloArrowRightHOffset: 20,
                    soloArrowRightVOffset: 0,
                    touchenabled: "on",
                    onHoverStop: "on",
                    navOffsetHorizontal: 0,
                    navOffsetVertical: 20,
                    hideCaptionAtLimit: 0,
                    hideAllCaptionAtLilmit: 0,
                    hideSliderAtLimit: 0,
                    stopAtSlide: -1,
                    stopAfterLoops: -1,
                    shadow: 0,
                    fullWidth: "on"

                });
        });

        // PORTFOLIO CAROUSEL
        $("#foo2").carouFredSel({
            auto: false,
            scroll: 1,
            pagination: "#foo2_pag",
            swipe: {
                ontouch: true,
                onMouse: true
            },
            width: 'variable',
            height: 'variable',
            items: {
                width: 'auto',
                visible: 4
            }
        });

        // FOOTER CAROUSEL ARTICLE 
        $("#foo1").carouFredSel({
            auto: true,
            scroll: 1,
            pagination: "#foo1_pag",
            width: 'variable',
            height: 'variable',
            items: {
                width: 'auto',
                visible: 1
            },
            swipe: {
                ontouch: true,
                onMouse: true
            }
        });

        // TESTIMONIALS ALTERNATIVE VERSION
        $('.testimonials-alternative-nav').on('click', 'a', function (e) {
            e.preventDefault();
            var $current = $(this);
            $('.testimonials-alternative-nav a').removeClass();
            $('.testimonials-alternative-content .content').hide();
            $current.addClass('active');
            var contentID = $current.attr('href');
            $('.testimonials-alternative-content').find(contentID).fadeIn();
        });

        /* ]]> */
    </script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-36395643-9', 'pixel-industry.com');
        ga('send', 'pageview');

    </script>
</asp:Content>
