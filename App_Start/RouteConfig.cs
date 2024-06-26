﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHangOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRoute(
                    name: "Products",
                    url: "san-pham",
                    defaults: new { controller = "Products", action = "Index", alias = UrlParameter.Optional },
                    namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                    name: "NewsList",
                    url: "tin-tuc",
                    defaults: new { controller = "News", action = "Index", alias = UrlParameter.Optional },
                    namespaces: new[] { "WebBanHangOnline.Controllers" }
            );

            routes.MapRoute(
                    name: "wishlist",
                    url: "danh-sach-xe-quan-tam",
                    defaults: new { controller = "wishlist", action = "index", alias = UrlParameter.Optional },
                    namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                    name: "Login",
                    url: "dang-nhap",
                    defaults: new { controller = "account", action = "login", alias = UrlParameter.Optional },
                    namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                    name: "register",
                    url: "dang-ky",
                    defaults: new { controller = "account", action = "register", alias = UrlParameter.Optional },
                    namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                    name: "profile",
                    url: "profile",
                    defaults: new { controller = "account", action = "profile", alias = UrlParameter.Optional },
                    namespaces: new[] { "WebBanHangOnline.Controllers" }
            );

            routes.MapRoute(
                name: "BaiViet",
                url: "post/{alias}",
                defaults: new { controller = "Article", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Detailnew",
                url: "{alias}-n{id}",
                defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );

            routes.MapRoute(
                    name: "detailProducts",
                    url: "chi-tiet/{alias}-p{id}",
                    defaults: new { controller = "Products", action = "Detail", alias = UrlParameter.Optional },
                    namespaces: new[] { "WebBanHangOnline.Controllers" }
            );

            routes.MapRoute(
                name: "CategoryProduct",
                url: "danh-muc-san-pham/{alias}-{id}",
                defaults: new { controller = "Products", action = "ProductCategory", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Contact",
                url: "lien-lac",
                defaults: new { controller = "Contact", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );

            routes.MapRoute(
                name: "SignUpForTestDrive",
                url: "dang-ky-lai-thu",
                defaults: new { controller = "SignUpForTestDrive", action = "Add", alias = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Service",
                url: "dich-vu",
                defaults: new { controller = "Service", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );

            routes.MapRoute(
                name: "ShoppingCart",
                url: "gio-hang",
                defaults: new { controller = "ShoppingCart", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                name: "CheckOut",
                url: "thanh-toan",
                defaults: new { controller = "ShoppingCart", action = "CheckOut", alias = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebBanHangOnline.Controllers"}
            );
        }
    }
}
