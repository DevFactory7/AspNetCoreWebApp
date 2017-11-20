# AspNetCoreWebApp ExternalLogins
Naver, Kakao ExternalLogins

WebApp / Core / Middleware / Naver
WebApp / Core / Middleware / Kakao

Startup.cs Settings

services.AddAuthentication()

                .AddNaver(naverOptions =>

                {

                    naverOptions.ClientId = Configuration["Naver:ClientId"];                            //appsettings.json Naver:ClientId

                    naverOptions.ClientSecret = Configuration["Naver:ClientSecret"];                    //appsettings.json Naver:ClientSecret

                })

                .AddKakao(kakaoOptions =>

                {

                    kakaoOptions.ClientId = Configuration["Kakao:ClientId"];                            //appsettings.json Kakao:ClientId

                    kakaoOptions.ClientSecret = Configuration["Kakao:ClientSecret"];                    //appsettings.json Kakao:ClientSecret

                });

appsettings.json

"Naver": {

    "ClientId": "Your Naver ClientId",

    "ClientSecret": "Your Naver ClientSecret"

  },

  "Kakao": {

    "ClientId": "Your Kakao ClientId",

    "ClientSecret": "Your Kakao ClientSecret"

  }