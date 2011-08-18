  using System;
  using System.Diagnostics;
  using System.Web.Mvc;
  using System.Web.Routing;
namespace Beepoy.Web.Filters
{
        public class AuthorizeFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                //String Url = "/Home/Login";
                 var Url = new UrlHelper( filterContext.RequestContext);

                if (filterContext.HttpContext.Session["User"] == null)
                {
                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.HttpContext.Response.StatusCode = 401;                        
                        base.OnActionExecuting(filterContext);
                    }
                    else
                    {              
                        filterContext.Result = new RedirectResult( 
                                       Url.Action("Login", "Home", 
                                              new RouteValueDictionary(
                                                  new { ReturnPage = filterContext.HttpContext.Request.Url.ToString() })));     
                    }
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                }               
            }

            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                Log("OnActionExecuted", filterContext.RouteData);
            }

            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                Log("OnResultExecuting", filterContext.RouteData);
            }

            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                Log("OnResultExecuted", filterContext.RouteData);
            }


            private void Log(string methodName, RouteData routeData)
            {
                var controllerName = routeData.Values["controller"];
                var actionName = routeData.Values["action"];
                var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
                Debug.WriteLine(message, "Action Filter Log");
            }

        }
    }
