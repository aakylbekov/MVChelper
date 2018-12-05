using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVChelper.Controllers
{
    public class TypeNames
    {
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string CommnentText { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<TypeNames> types = new List<TypeNames>();
            types.Add(new TypeNames { TypeId = 1, TypeName = "Base"});
            types.Add(new TypeNames { TypeId = 2, TypeName = "Other"});
    //List<SelectListItem> selects = new List<SelectListItem>();
    //selects.Add(new SelectListItem() { Text = "Base", Value = "01" });

    SelectList data = new SelectList(types, "TypeId","TypeName", 2);
            //ViewBag.CommentType = types.Select(s=>new SelectListItem { Text = s, Value = "01"});
            ViewBag.CommentType = data;
            return View(new TypeNames() {CommnentText });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        static public List<string> comments = new List<string>();
        [HttpPost]
        public ActionResult AddComment(string commentText) //1
        {
            if (Request.Form["action"].ToString().Equals("send"))
                comments.Add(commentText);
            //2
            var rf_commentText = Request.Form["commentText"];
            //comments.Add("");
            return RedirectToAction("Index");
        }
    }
}