using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebUtility.Security;

namespace WebUtility
{
    /// <summary>
    /// Controller的基类，用于实现适合业务场景的基础功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [BasicAuthentication]
    public abstract class ApiControllerBase : ApiController
    {

    }
}

