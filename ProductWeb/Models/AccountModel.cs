using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUtility;

namespace ProductWeb.Models
{
    public class AccountModel
    {
        /// <summary>
        /// 创建登录用户的票据信息
        /// </summary>
        /// <param name="strUserName"></param>
        internal void CreateLoginUserTicket(string strUserName, string strPassword)
        {
            //构造Form验证的票据信息
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, strUserName, DateTime.Now, DateTime.Now.AddMinutes(240),
                true, string.Format("{0}:{1}", strUserName, strPassword), FormsAuthentication.FormsCookiePath);

            string ticString = FormsAuthentication.Encrypt(ticket);

            //把票据信息写入Cookie和Session
            //SetAuthCookie方法用于标识用户的Identity状态为true
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, ticString));
            FormsAuthentication.SetAuthCookie(strUserName, true);
            HttpContext.Current.Session["USER_LOGON_TICKET"] = ticString;
            
            //重写HttpContext中的用户身份，可以封装自定义角色数据；
            //判断是否合法用户，可以检查：HttpContext.User.Identity.IsAuthenticated的属性值
            string[] roles = ticket.UserData.Split(',');
            IIdentity identity = new FormsIdentity(ticket);
            IPrincipal principal = new GenericPrincipal(identity, roles);
            HttpContext.Current.User = principal;
        }

        /// <summary>
        /// 获取用户权限列表数据
        /// [
        ///  {"Controller": "员工请假", "Actions": "申请, 审核"},
        ///  {"Controller": "产品订单申请", "Actions": "申请, 列表, 详细"}
        /// ]
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        internal void GetUserAuthorities(string userName)
        {
            //从WebApi 访问用户权限数据，然后写入Session
            string jsonAuth = "[{\"controller\": \"humanresource\", \"actions\":\"apply,process,complete\"}, {\"controller\": \"product\", \"actions\": \"list,renew,detail\"}]";
            var userAuthList = ServiceStack.Text.JsonSerializer.DeserializeFromString(jsonAuth, typeof(UserAuthModel[]));
            HttpContext.Current.Session["USER_AUTHORITIES"] = userAuthList;
        }

        /// <summary>
        /// 读取数据库用户表数据，判断用户密码是否匹配
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool ValidateUserLogin(string name, string password)
        {
            //bool isValid = password == passwordInDatabase;
            return true;
        }

        /// <summary>
        /// 用户注销执行的操作
        /// </summary>
        internal void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}