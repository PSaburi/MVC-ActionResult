using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCActionResult.Controllers
{
    public class HomeController : Controller
    {
        #region Content Returning Results

        public ContentResult ContentResult()
        {
            var message = Server.HtmlEncode("Returns a string literal.");
            return Content(message, "text/plain", Encoding.UTF8);
        }

        public EmptyResult EmptyResult()
        {
            return new EmptyResult();
        }

        /// <summary>
        /// Returns the contents of a file
        /// You can use a FileResult to return PDF files,
        /// spreadsheets, text files and other content the user wants to download.
        /// </summary>
        /// <returns></returns>
        public FileResult FileContentResult()
        {
            return File(Server.MapPath("~/Content/site.css"), "text/css");
        }

        /// <summary>
        /// Returns a script to execute
        /// </summary>
        /// <returns></returns>
        public JavaScriptResult JavaScriptResult()
        {
            return JavaScript("alert('Hey there!')");
        }

        /// <summary>
        /// Returns data in JSON format
        /// </summary>
        /// <returns></returns>
        public JsonResult JsonResult()
        {
            //If JsonRequestBehaviour is not mentioned, then the server will throw below error
            // "This request has been blocked because sensitive information could be disclosed to
            // third party web sites when this is used in a GET request. To allow GET requests, set
            // JsonRequestBehaviour to AllowGet"

            return Json(new { Name = "Saburi", Location = "India" }, JsonRequestBehavior.AllowGet);
        }

        public ViewResult ViewResult()
        {
            return View();
        }

        public PartialViewResult PartialViewResult()
        {
            return PartialView("_PartialView");
        }

        #endregion Content Returning Results

        #region Redirection Results

        /// <summary>
        /// Redirects the client to a new URL
        /// </summary>
        /// <returns></returns>
        public RedirectResult RedirectResult()
        {
            return Redirect("http://microsoft.com");
        }

        public RedirectResult PermanentRedirectResult()
        {
            return RedirectPermanent("http://microsoft.com");
        }

        /// <summary>
        /// Redirect to another route
        /// </summary>
        /// <returns></returns>
        public RedirectToRouteResult RedirectToRouteResult()
        {
            return RedirectToRoute("Default", new { Controller = "Home", Action = "Contact", Id = UrlParameter.Optional });
        }

        /// <summary>
        /// Redirect to another action or another controller's action
        /// </summary>
        /// <returns></returns>
        public RedirectToRouteResult RedirectToActionResult()
        {
            //This overload is helpful when redirecting to an action of same controller
            return RedirectToAction("Contact", "Home", new { id = UrlParameter.Optional });
        }

        #endregion Redirection Results

        #region Status Result

        public HttpStatusCodeResult HttpStatusCodeResult()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Sorry! You don't have access");
        }

        public HttpStatusCodeResult HttpUnauthorizedResult()
        {
            return new HttpUnauthorizedResult("Sorry! You dont have access.");
        }

        public HttpNotFoundResult HttpNotFoundResult()
        {
            return new HttpNotFoundResult("Sorry! Something you are looking for is not found.");
        }

        #endregion Status Result

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}