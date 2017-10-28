// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.Kakao
{
    /// <summary>
    /// Configuration options for <see cref="KakaoHandler"/>.
    /// </summary>
    public class KakaoOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="KakaoOptions"/>.
        /// </summary>
        public KakaoOptions()
        {
            CallbackPath = new PathString("/signin-kakao");
            AuthorizationEndpoint = KakaoDefaults.AuthorizationEndpoint;
            TokenEndpoint = KakaoDefaults.TokenEndpoint;
            UserInformationEndpoint = KakaoDefaults.UserInformationEndpoint;
            Scope.Add("r_basicprofile");
            Scope.Add("r_emailaddress");
            Scope.Add("email");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "kaccount_email");
            ClaimActions.MapJsonSubKey(ClaimTypes.Name, "properties", "nickname");
            ClaimActions.MapJsonSubKey("urn:kakao:thumbnail", "properties", "url");
            //ClaimActions.MapJsonSubKey(ClaimTypes.Name, "properties", "nickname");
            //ClaimActions.MapJsonSubKey(ClaimTypes.GivenName, "name", "givenName");
            //ClaimActions.MapJsonSubKey(ClaimTypes.Surname, "name", "familyName");
            //ClaimActions.MapJsonSubKey("urn:kakao:thumenail", "properties", "url");
            //ClaimActions.MapCustomJson(ClaimTypes.Email, KakaoHelper.GetEmail);
        }

        /// <summary>
        /// access_type. Set to 'offline' to request a refresh token.
        /// </summary>
        public string AccessType { get; set; }
    }
}