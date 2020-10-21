// Copyright: https://mcguirev10.com/2019/12/15/blazor-authentication-with-openid-connect.html

using System;

namespace ModernArchitectureShop.BlazorUI
{
    public class BlazorServerAuthData
    {
        public string SubjectId = string.Empty;
        public DateTimeOffset Expiration;
        public string AccessToken= string.Empty;
        public string RefreshToken= string.Empty;
    }
}
