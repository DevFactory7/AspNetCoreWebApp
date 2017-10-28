// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.Naver
{
    /// <summary>
    /// Configuration options for <see cref="NaverHandler"/>.
    /// </summary>
    public class NaverOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="NaverOptions"/>.
        /// </summary>
        public NaverOptions()
        {
            CallbackPath = new PathString("/signin-naver");
            AuthorizationEndpoint = NaverDefaults.AuthorizationEndpoint;
            TokenEndpoint = NaverDefaults.TokenEndpoint;
            UserInformationEndpoint = NaverDefaults.UserInformationEndpoint;
            //Scope.Add("r_basicprofile");
            //Scope.Add("r_emailaddress");
            //Scope.Add("email");

            ClaimActions.MapJsonSubKey(ClaimTypes.NameIdentifier, "response", "id");
            ClaimActions.MapJsonSubKey(ClaimTypes.Name, "response", "nickname");
            ClaimActions.MapJsonSubKey(ClaimTypes.Email, "response", "email");

            //ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            //ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");
            //ClaimActions.MapJsonSubKey(ClaimTypes.GivenName, "name", "givenName");
            //ClaimActions.MapJsonSubKey(ClaimTypes.Surname, "name", "familyName");
            //ClaimActions.MapJsonKey("urn:Naver:profile", "url");
            //ClaimActions.MapCustomJson(ClaimTypes.Email, NaverHelper.GetEmail);
        }

        /// <summary>
        /// access_type. Set to 'offline' to request a refresh token.
        /// </summary>
        public string AccessType { get; set; }
    }
}