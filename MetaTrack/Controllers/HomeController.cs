using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MetaTrack.Models;
using HtmlAgilityPack;

namespace MetaTrack.Controllers
{
    public class HomeController : Controller
    {
        TrackContext db;

        public HomeController(TrackContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OutputInfo()
        {
            return View();
        }

        public IActionResult GetInfo()
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            HtmlWeb web = new HtmlWeb();
            htmlDoc = web.Load("https://global.cainiao.com/detail.htm?mailNoList=LT886703297NL");
            var items = htmlDoc.DocumentNode.SelectSingleNode("//ol[@id='waybill_path']");
            var itemsI = items.SelectNodes(".//li");

            //foreach (var item in itemsI)
            //{
            //    var name = item.SelectSingleNode(".//il/p").InnerText;
            //    //var data = item.SelectSingleNode(".//div[@class='title-']/following-sibling::div").SelectNodes(".//p");
            //}
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(Track track)
        {
            if (!db.Tracks.Contains(track))
            {
                track.ActiveDate = DateTime.Now;
                db.Tracks.Add(track);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("GetInfo");
        }
    }
}
