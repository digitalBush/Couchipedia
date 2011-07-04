using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Web.Helpers
{
    public class TimerAttribute : ActionFilterAttribute
    {
        public TimerAttribute()
        {
            // Make sure this attribute executes after every other one!
            this.Order = int.MaxValue;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["_timer"] = Stopwatch.StartNew();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller;

            var timer = (Stopwatch)controller.ViewData["_timer"];
            timer.Stop();
            controller.ViewData["_elapsed"] = timer.ElapsedMilliseconds;


        }
    }
}