using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using WebUtility.Security;

namespace WebUtility
{
    /// <summary>
    /// 前端Mvc控制器基类
    /// </summary>
    [Authorize]
    public abstract class WebControllerBase : Controller
    {
        /// <summary>
        /// 对应api的Url
        /// </summary>
        public string ApiUrl
        {
            get;
            protected set;
        }

        /// <summary>
        /// 用户权限列表
        /// </summary>
        public UserAuthModel[] UserAuthList
        {
            get
            {
                return AuthorizedUser.Current.UserAuthList;
            }
        }

        /// <summary>
        /// 登录用户票据
        /// </summary>
        public string UserLoginTicket
        {
            get
            {
                return AuthorizedUser.Current.UserLoginTicket;
            }
        }

        /// <summary>
        /// Action执行时写入Cookie信息
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //验证是否是登录用户
            var identity = filterContext.HttpContext.User.Identity;
            if (identity.IsAuthenticated)
            {
                //有效登录用户，写入用户票据信息到Cookie
                filterContext.HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName].Value = UserLoginTicket;
            }
        }
    }
}
