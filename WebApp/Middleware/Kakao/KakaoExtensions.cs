// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Kakao;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class KakaoExtensions
    {
        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder)
            => builder.AddKakao(KakaoDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, Action<KakaoOptions> configureOptions)
            => builder.AddKakao(KakaoDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, string authenticationScheme, Action<KakaoOptions> configureOptions)
            => builder.AddKakao(authenticationScheme, KakaoDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<KakaoOptions> configureOptions)
        {
            return builder.AddOAuth<KakaoOptions, KakaoHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
