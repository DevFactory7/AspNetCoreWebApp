// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Naver;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NaverExtensions
    {
        public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder)
            => builder.AddNaver(NaverDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder, Action<NaverOptions> configureOptions)
            => builder.AddNaver(NaverDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder, string authenticationScheme, Action<NaverOptions> configureOptions)
            => builder.AddNaver(authenticationScheme, NaverDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<NaverOptions> configureOptions)
        {
            return builder.AddOAuth<NaverOptions, NaverHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
