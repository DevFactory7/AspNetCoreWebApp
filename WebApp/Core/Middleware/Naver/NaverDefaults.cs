// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Authentication.Naver
{
    /// <summary>
    /// Default values for Naver authentication
    /// </summary>
    public static class NaverDefaults
    {
        public const string AuthenticationScheme = "Naver";

        public static readonly string DisplayName = "Naver";

        public static readonly string AuthorizationEndpoint = "https://nid.naver.com/oauth2.0/authorize";

        public static readonly string TokenEndpoint = "https://nid.naver.com/oauth2.0/token";

        public static readonly string UserInformationEndpoint = "https://openapi.naver.com/v1/nid/me";
    }
}
