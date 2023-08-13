using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadFile.BAL;
using UploadFile.BAL.Models;

namespace UploadFile.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult UploadFileAuto()
        {
            try
            {
                var fileNameToUpload = @"D:\.NetCore\.NetCore\.NetCore\06-MasterBlogger-ArticleCategoryImplementation\01-Sectionintro.mp4";

                // File should exist first!
                if (System.IO.File.Exists(fileNameToUpload))
                {
                    using (var stream = System.IO.File.OpenRead(fileNameToUpload))
                    {
                        var model = new ModelFile();
                        model.FileName = "01-Sectionintro.mp4";
                        model.stream = stream;
                        var res = UploadFileService.CLientUploadFile(model);
                    }
                }
                else
                {
                    Console.WriteLine("Provided file name does not exist.");
                }
                ViewBag.IsUploadOrNOT = "Upload File Successfull, Have a Good Day:))";
            }
            catch (Exception ex)
            {
                //serviceClient.Abort();
                //serviceClient.Close();
                Console.WriteLine("Error occurred:" + ex.Message);
                ViewBag.IsUploadOrNOT = "Upload File Fail, Try again!!";
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
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
    }
}