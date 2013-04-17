using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using WebUtility;

namespace WebUtility.Security
{
    /// <summary>
    /// 经过授权的用户对象
    /// </summary>
    public class AuthorizedUser
    {
        /// <summary>
        /// 用户权限列表
        /// </summary>
        public UserAuthModel[] UserAuthList
        {
            get
            {
                return HttpContext.Current.Session["USER_AUTHORITIES"] as UserAuthModel[];
            }
        }

        /// <summary>
        /// 登录用户票据
        /// </summary>
        public string UserLoginTicket
        {
            get
            {
                if (HttpContext.Current.Session["USER_LOGON_TICKET"] != null)
                    return HttpContext.Current.Session["USER_LOGON_TICKET"].ToString();
                else
                {
                    var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (cookie != null)
                    {
                        //Cookie未过期时，读取cookie，重新写Session
                        HttpContext.Current.Session["USER_LOGON_TICKET"] = cookie.Value;
                        return cookie.Value;
                    }
                    else
                    {
                        //Session, Cookie都过期，重新登录
                        return string.Empty;
                    }
                }
            }
        }

        private AuthorizedUser()
        {
        }

        public static AuthorizedUser Current
        {
            get
            {
                //通过用户登录标识，获取用户跟权限有关的对象
                //var user = (new AuthoirzedUserManager()).GetByUserName();
                return new AuthorizedUser();
            }
        }
    }
}