using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUtility;
using ProductWeb.Models;

namespace ProductWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Logon/

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LoginUser loginUser, string returnUrl)
        {
            string strUserName = loginUser.UserName;
            string strPassword = loginUser.Password;
            var accountModel = new AccountModel();

            //验证用户是否是系统注册用户
            if (accountModel.ValidateUserLogin(strUserName, strPassword))
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    //创建用户ticket信息
                    accountModel.CreateLoginUserTicket(strUserName, strPassword);

                    //读取用户权限数据
                    accountModel.GetUserAuthorities(strUserName);

                    return new RedirectResult(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                throw new ApplicationException("无效登录用户！");
            }
        }

        /// <summary>
        /// 用户注销，注销之前，清除用户ticket
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Logout()
        {
            var accountModel = new AccountModel();
            accountModel.Logout();

            return RedirectToAction("Login", "Account");
        }
    }
}