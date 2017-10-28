// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Authentication.Naver;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add Naver authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class NaverAppBuilderExtensions
    {
        /// <summary>
        /// UseNaverAuthentication is obsolete. Configure Naver authentication with AddAuthentication().AddNaver in ConfigureServices. See https://go.microsoft.com/fwlink/?linkid=845470 for more details.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the handler to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        [Obsolete("UseNaverAuthentication is obsolete. Configure Naver authentication with AddAuthentication().AddNaver in ConfigureServices. See https://go.microsoft.com/fwlink/?linkid=845470 for more details.", error: true)]
        public static IApplicationBuilder UseNaverAuthentication(this IApplicationBuilder app)
        {
            throw new NotSupportedException("This method is no longer supported, see https://go.microsoft.com/fwlink/?linkid=845470");
        }

        /// <summary>
        /// UseNaverAuthentication is obsolete. Configure Naver authentication with AddAuthentication().AddNaver in ConfigureServices. See https://go.microsoft.com/fwlink/?linkid=845470 for more details.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the handler to.</param>
        /// <param name="options">A <see cref="NaverOptions"/> that specifies options for the handler.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        [Obsolete("UseNaverAuthentication is obsolete. Configure Naver authentication with AddAuthentication().AddNaver in ConfigureServices. See https://go.microsoft.com/fwlink/?linkid=845470 for more details.", error: true)]
        public static IApplicationBuilder UseNaverAuthentication(this IApplicationBuilder app, NaverOptions options)
        {
            throw new NotSupportedException("This method is no longer supported, see https://go.microsoft.com/fwlink/?linkid=845470");
        }
    }
}
