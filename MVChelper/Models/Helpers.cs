using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVChelper.Controllers;
namespace MVChelper.Models
{
    public static class Helpers
    {
        public static MvcHtmlString EventListOurCity(this HtmlHelper html,string[] items )
        {
            //<ul><ul/>
            TagBuilder ul = new TagBuilder("ul");
            ul.MergeAttribute("ID", "eventlist");
            ul.MergeAttribute("data-gen", DateTime.Now.ToString());
            ul.AddCssClass("myClass");
           
            //Random rnd = new Random();
            //for (int i = 0; i < rnd.Next(1,20); i++)
            //{

                foreach (var item in HomeController.comments)
                {
                    TagBuilder li = new TagBuilder("li");
                    li.SetInnerText("Event in " + item + " (" + DateTime.Now.Date + ")");
                    ul.InnerHtml += li.ToString();
                }
               
           // }
            return new MvcHtmlString(ul.ToString());
        }
    }
}