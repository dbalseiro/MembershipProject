using System;
using System.Web.Mvc;
using MembershipWeb.Models;
using MembershipWeb.Helpers;
using MembershipProject.Actions;
using System.Collections.Generic;

namespace MembershipWeb.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {        
        HomeHelper helper;
        public HomeController()
        {
            helper = new HomeHelper();
        }

        public ActionResult Index()
        {
            try
            {
                var menu = helper.getMenu();
                TempData["Menu"] = menu;
                return View(menu);
            }
            catch (Exception e) {
                ModelState.AddModelError("_FORM", e.Message);
                return View(new Menu());
            }
        }

        public ActionResult Result(int id)
        {
            try
            {
                var menu = (Menu)TempData["menu"];            
                var action = helper.getItemAction(id, menu);
                var paramList = action.paramList();

                if (paramList != null && paramList.Length > 0)
                {
                    TempData["action"] = action;
                    return RedirectToAction("Parameters");
                }
                return ResultAction(action, new List<string>().ToArray());
            }
            catch (Exception e)
            {
                ModelState.AddModelError("_FORM", e.Message);
                return View(new Result());
            }
        }

        public ActionResult Parameters()
        {
            try
            {
                IAction action = (IAction)TempData["action"];
                var model = helper.getParameters(action);
                TempData["action"] = action;
                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("_FORM", e.Message);
                return View(new Parameters());            
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Parameters(string[] itemValue)
        {
            try
            {
                var action = (IAction)TempData["action"];
                return ResultAction(action, itemValue);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("_FORM", e.Message);
                return View(new Parameters());
            }
        }

        private ActionResult ResultAction(IAction action, string[] values)
        {
            var model = new Result() { title = action.nombre() };
            action.initialize(values);
            action.doAction();
            model.result = helper.getText();
            return View("Result", model);
        }
    }
}
