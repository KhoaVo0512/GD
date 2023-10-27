using AutoMapper;
using GD.Model.Models;
using GD.Service;
using GD.Web.App_Start;
using GD.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Office.Interop.PowerPoint;
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
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IMenuService _menuService;
        private IMenuGroupService _menuGroupService;
        private IApplicationGroupService _applicationGroupService;
        private IEmployeeService _employeeService;
        private ICourseService _courseService;
        private IGradeService _gradeService;
        private IGradeGroupService _gradeGroupService;
        private ITopicService _topicService;
        private IFileService _fileService;
        private readonly IMapper _mapper;
        public HomeController(ApplicationSignInManager signInManager, ApplicationUserManager userManager, IMenuService menuService,
            IMenuGroupService menuGroupService, IApplicationGroupService applicationGroupService, IEmployeeService employeeService,
            ICourseService courseService, IGradeGroupService gradeGroupService, IGradeService gradeService, ITopicService topicService,
            IFileService fileService, IMapper mapper
            )
        {
            SignInManager = signInManager;
            UserManager = userManager;
            this._menuService = menuService;
            this._menuGroupService = menuGroupService;
            this._applicationGroupService = applicationGroupService;
            this._employeeService = employeeService;
            this._courseService = courseService;
            this._gradeGroupService = gradeGroupService;
            this._gradeService = gradeService;
            this._topicService = topicService;
            this._fileService = fileService;
            this._mapper = mapper;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

       
        public async Task<ActionResult> Index()
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Cookies["Course"] != null)
                {
                    var topicModel = _topicService.GetByCourse(Int32.Parse(System.Web.HttpContext.Current.Request.Cookies["Course"].Value));
                    if (topicModel.Count() > 0)
                    {
                        var fileModel = _fileService.GetByCourseTopicCategory(Int32.Parse(System.Web.HttpContext.Current.Request.Cookies["Course"].Value), topicModel.ToList()[0].ID, 1);
                        if (fileModel.Count() > 0)
                        {
                            ViewBag.DataLesson = fileModel.OrderByDescending(x => x.CreateDate).ToList();
                        }
                    }
                    ViewBag.TopicFilterData = topicModel.ToList();

                }              
                return View();
            }
            catch (Exception)
            {
                SessionHelper.Information = null;
                SessionHelper.MenuGlobal = null;
                SessionHelper.MenuGroupGlobal = null;
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut();
                if (System.Web.HttpContext.Current.Request.Cookies["Course"] != null)
                {
                    var removeCourse = new HttpCookie("Course")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
                    Response.Cookies.Add(removeCourse);
                }
                return RedirectToAction("SignIn", "Account");
            }
            
        }
       
        public ActionResult LoadLesson(int topic, string search)
        {
            try
            {
                var fileModel = new List<GD.Model.Models.File>();
                if(search != null && search.Length > 0)
                {
                    fileModel = _fileService.GetByCourseTopicCategorySearch(Int32.Parse(System.Web.HttpContext.Current.Request.Cookies["Course"].Value), topic, 1, search).ToList();
                }
                else
                {
                    fileModel = _fileService.GetByCourseTopicCategory(Int32.Parse(System.Web.HttpContext.Current.Request.Cookies["Course"].Value), topic, 1).ToList();
                }
                if (fileModel.Count() > 0)
                {
                    ViewBag.DataLesson = fileModel.OrderByDescending(x => x.CreateDate).ToList();
                }

                

                return PartialView("ContentLessonPartital");

            }
            catch (Exception)
            {
                return PartialView("ContentLessonPartital");
            }
        }

       
        public ActionResult LoadTemplateLesson(int course, string search, bool all)
        {
            try
            {
                var fileModel = new List<GD.Model.Models.File>();
                if (course == 0 || all == true)
                {
                    if (search != null && search.Length > 0)
                    {
                        fileModel = _fileService.GetByCategoryAndSearch(2, search).ToList();
                    }
                    else
                    {
                        fileModel = _fileService.GetAllByCategory(2).ToList();
                    }
                }
                else
                {
                    if (search != null && search.Length > 0)
                    {
                        fileModel = _fileService.GetByCourseCategoryAndSearch(course, 2, search).ToList();
                    }
                    else
                    {
                        fileModel = _fileService.GetByCourseAndCategory(course, 2).ToList();
                    }
                }
                
                if (fileModel.Count() > 0)
                {
                    ViewBag.DataTemplateLesson = fileModel;
                }

                return PartialView("ContentTemplatePartital");

            }
            catch (Exception)
            {
                return PartialView("ContentTemplatePartital");
            }
        }

        public async Task<ActionResult> LoadFile(int category, string name)
        {
            try
            {
                string rootPath = Path.Combine(Server.MapPath("~/Content/Upload/" + FunctionHelper.nameFolder[category] + "/"), name);

                if (category == 2)
                {
                    rootPath = Path.Combine(Server.MapPath("~/Content/Upload/" + FunctionHelper.nameFolder[category] + "/"), name);
                }

                bool checkFileRoot = System.IO.File.Exists(rootPath);
                if(checkFileRoot)
                {
                    string pathDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    bool existsFolderSave = System.IO.Directory.Exists(FunctionHelper.folderSave);
                    if (existsFolderSave)
                    {
                        pathDocument = FunctionHelper.folderSave;
                    }

                    string subPath = pathDocument + "\\GDVIETNAM";
                    bool exists = System.IO.Directory.Exists(subPath);
                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(subPath);
                    }

                    string fname = Path.Combine(subPath, name);

                    bool checkFile = System.IO.File.Exists(fname);
                    if (checkFile)
                    {
                        return Json(new { status = 0, msg = "Đã tồn tại tập tin cùng tên", same = true, path = fname, nameRoot = name, categoryRoot = category }, JsonRequestBehavior.AllowGet);
                        //System.Diagnostics.Process.Start(@"" + fname);
                    }
                    else
                    {
                        using (FileStream sourceStream = System.IO.File.Open(rootPath, FileMode.Open))
                        {
                            using (FileStream destinationStream = System.IO.File.Create(Path.Combine(subPath, name)))
                            {
                                await sourceStream.CopyToAsync(destinationStream);
                            }
                        }

                        System.Diagnostics.Process.Start(@"" + fname);
                        return Json(new { status = 0, msg = "Thao tác thành công", same = false }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { status = -1, msg = "Chưa tìm thấy tập tin này" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch(Exception ex)
            {
                return Json(new { status = -1, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

       
        public async Task<ActionResult> LoadFileAgain(int categoryRoot, string nameRoot, string pathOld, bool next)
        {
            try
            {
                if(next == false)
                {
                    //mo lai
                    bool checkFileRootOld = System.IO.File.Exists(pathOld);
                    if (checkFileRootOld)
                    {
                        System.Diagnostics.Process.Start(@"" + pathOld);
                        return Json(new { status = 0, msg = "Thao tác thành công"}, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { status = 0, msg = "Không tồn tại tập tin này" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    //copy
                    string rootPath = Path.Combine(Server.MapPath("~/Content/Upload/" + FunctionHelper.nameFolder[categoryRoot] + "/"), nameRoot);

                    if (categoryRoot == 2)
                    {
                        rootPath = Path.Combine(Server.MapPath("~/Content/Upload/" + FunctionHelper.nameFolder[categoryRoot] + "/"), nameRoot);
                    }
                    //kiem tra tap tin co ton tai khong
                    bool checkFileRoot = System.IO.File.Exists(rootPath);
                    if (checkFileRoot)
                    {
                        string pathDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        bool existsFolderSave = System.IO.Directory.Exists(FunctionHelper.folderSave);
                        if (existsFolderSave)
                        {
                            pathDocument = FunctionHelper.folderSave;
                        }

                        string subPath = pathDocument + "\\GDVIETNAM";
                        bool exists = System.IO.Directory.Exists(subPath);
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(subPath);
                        }

                        string fname = Path.Combine(subPath, nameRoot);

                        using (FileStream sourceStream = System.IO.File.Open(rootPath, FileMode.Open))
                        {
                            using (FileStream destinationStream = System.IO.File.Create(Path.Combine(subPath, nameRoot)))
                            {
                                await sourceStream.CopyToAsync(destinationStream);
                            }
                        }

                        System.Diagnostics.Process.Start(@"" + fname);
                        return Json(new { status = 0, msg = "Thao tác thành công"}, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { status = -1, msg = "Chưa tìm thấy tập tin này" }, JsonRequestBehavior.AllowGet);
                    }
                }
                

            }
            catch (Exception ex)
            {
                return Json(new { status = -1, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
  
       
        public ActionResult ViewFilePage(string url)
        {
            try
            {
                ViewBag.FileData = "/Content/Upload/Lesson/" + url;
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
       
       
        public ActionResult LoadRichText(string url)
        {
            try
            {
                if(url != null && url.Length > 2)
                {
                    var urlData = "/Content/Upload/Lesson/" + url;
                    var rootPath = Server.MapPath("~/Content/Upload/Lesson/" + url);

                    bool checkFileRoot = System.IO.File.Exists(rootPath);

                    if (checkFileRoot)
                    {
                        ViewBag.DocumentUrl = urlData;

                        return PartialView("ContentRichTextPartital");
                    }
                    else
                    {
                        return PartialView("ContentRichTextPartital");
                    }
                }
                else
                {
                    return PartialView("ContentRichTextPartital");
                }
                
            }
            catch (Exception)
            {
                return PartialView("ContentRichTextPartital");
            }
        }
       
        public ActionResult LoadAndSavePartial()
        {
            return PartialView("LoadAndSavePartial");
        }
       
        public bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        
    }
}