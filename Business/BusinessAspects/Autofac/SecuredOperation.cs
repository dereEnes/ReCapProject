using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;//metot üstüne yazılan roller
        private IHttpContextAccessor _httpContextAccessor;
        //IHttpContextAccessor herkes için thread oluşumu
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//gelen tek string deki rolleri ayrırarak eklemek
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //Service tool un amacı bizim yazdığımız Ioc nin dışında kalan bu aspect için Ioc sağlamak
            //çünkü wep api buraya ulaşamıyor
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
