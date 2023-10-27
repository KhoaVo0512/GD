using AutoMapper;
using GD.Model.Models;
using GD.Service;
using GD.Web.App_Start;
using GD.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GD.Web.Controllers
{
    [NoDirectAccess]
    public class ContentController : Controller
    {
        
        public ContentController()
        {
            
        }

        [NoDirectAccess]
        public ActionResult Index()
        {
            return View();
        }


        [NoDirectAccess]
        public ActionResult GetFileLesson(string url)
        {
            try
            {
                string[] imageExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
                string[] videoExtensions = { ".avi", ".flv", ".wmv", ".mov", ".mp4", ".mpeg", ".divx", ".3gp" };

                string type = "";

                if (Array.IndexOf(imageExtensions, Path.GetExtension(url).ToLower()) != -1)
                {
                    type = "image" + Path.GetExtension(url).ToLower().Replace('.', '/');
                }
                if (Array.IndexOf(videoExtensions, Path.GetExtension(url).ToLower()) != -1)
                {
                    type = "video" + Path.GetExtension(url).ToLower().Replace('.', '/');
                }

                var rootPath = Server.MapPath("~/Content/Upload/Lesson/" + url);

                bool exists = System.IO.File.Exists(rootPath);

                if (!exists)
                {
                    var filedefaultPath = Server.MapPath("~/Content/document-blank.png");
                    return File(filedefaultPath, "image/png");
                }
                else
                {
                    
                    //byte[] filedata = System.IO.File.ReadAllBytes(rootPath);
                    //string contentType = MimeMapping.GetMimeMapping(rootPath);
                    //return File(filedata, contentType);

                    
                    
                    byte[] bytes = System.IO.File.ReadAllBytes(rootPath);
                    return File(bytes, "application/octet-stream");
                }
            }
            catch (Exception)
            {
                var filedefaultPath = Server.MapPath("~/Content/document-blank.png");
                return File(filedefaultPath, "image/png");
            }
            
        }

        /*
        [NoDirectAccess]
        public ActionResult GetFileLesson(string url)
        {
            try
            {
                string[] imageExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
                string[] videoExtensions = { ".avi", ".flv", ".wmv", ".mov", ".mp4", ".mpeg", ".divx", ".3gp" };

                string type = "";

                if (Array.IndexOf(imageExtensions, Path.GetExtension(url).ToLower()) != -1)
                {
                    type = "image" + Path.GetExtension(url).ToLower().Replace('.', '/');
                }
                if (Array.IndexOf(videoExtensions, Path.GetExtension(url).ToLower()) != -1)
                {
                    type = "video" + Path.GetExtension(url).ToLower().Replace('.', '/');
                }

                var rootPath = Server.MapPath("~/Content/Upload/Library/" + url);

                bool exists = System.IO.File.Exists(rootPath);

                if (!exists)
                {
                    var filedefaultPath = Server.MapPath("~/Content/document-blank.png");
                    return File(filedefaultPath, "image/png");
                }
                else
                {

                    //byte[] filedata = System.IO.File.ReadAllBytes(rootPath);
                    //string contentType = MimeMapping.GetMimeMapping(rootPath);
                    //return File(filedata, contentType);

                    var memoryStream = new MemoryStream(System.IO.File.ReadAllBytes(rootPath));
                    return new FileStreamResult(memoryStream, MimeMapping.GetMimeMapping(System.IO.Path.GetFileName(rootPath)));
                }
            }
            catch (Exception)
            {
                var filedefaultPath = Server.MapPath("~/Content/document-blank.png");
                return File(filedefaultPath, "image/png");
            }

        }
        */

    }
}