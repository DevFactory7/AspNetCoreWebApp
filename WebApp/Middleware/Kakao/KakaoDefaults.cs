// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Authentication.Kakao
{
    /// <summary>
    /// Default values for Kakao authentication
    /// </summary>
    public static class KakaoDefaults
    {
        public const string AuthenticationScheme = "Kakao";

        public static readonly string DisplayName = "Kakao";

        public static readonly string AuthorizationEndpoint = "https://kauth.kakao.com/oauth/authorize";

        public static readonly string TokenEndpoint = "https://kauth.kakao.com/oauth/token";

        public static readonly string UserInformationEndpoint = "https://kapi.kakao.com/v1/user/me";
    }
}
