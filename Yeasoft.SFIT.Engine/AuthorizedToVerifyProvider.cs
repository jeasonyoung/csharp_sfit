using System;
using System.Collections.Generic;
using System.Text;

using iPower;
using iPower.IRMP.SysMgr;
namespace Yaesoft.SFIT.Engine
{
    /// <summary>
    /// 验证授权服务。
    /// </summary>
    public class AuthorizedToVerifyProvider : IAuthorizedToVerify
    {
        #region IAuthorizedToVerify 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemID"></param>
        /// <param name="authPassword"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool AppAuthorization(GUIDEx systemID, string authPassword, out string err)
        {
            err = null;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="systemID"></param>
        /// <param name="clientIP"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UserAuthorizationVerification(GUIDEx employeeID, GUIDEx systemID, string clientIP, out string err)
        {
            err = null;
            return true;
        }

        #endregion
    }
}