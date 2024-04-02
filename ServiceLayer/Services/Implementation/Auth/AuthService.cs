//using Google.Apis.Auth;
//using Google.Apis.Oauth2.v2;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using DataLayer.DbObject;
using DataLayer.Enums;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RepoLayer.Interface;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.Services.Implementation.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepoWrapper repos;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private JwtSecurityTokenHandler jwtHandler;

        public AuthService(IRepoWrapper repos, IConfiguration configuration, IMapper mapper)
        {
            this.repos = repos;
            this.configuration = configuration;
            jwtHandler = new JwtSecurityTokenHandler();
            this.mapper = mapper;
        }

        public async Task<LoginInfoDto> LoginAsync(LoginModel loginModel)
        {
            Account account = await repos.Accounts.GetByUsernameOrEmailAndPasswordAsync(loginModel.UsernameOrEmail, loginModel.Password);
            if (account == null)
            {
                return null;
            }
            if(account.IsBanned == true)
            {
                throw new Exception("Tài khoản đã bị vô hiệu");
            }
            LoginInfoDto loginInfoDto = mapper.Map<LoginInfoDto>(account);
            loginInfoDto.Token = await GenerateJwtAsync(account, loginModel.RememberMe);
            return loginInfoDto;
        }

        public async Task<LoginInfoDto> LoginWithGoogleIdToken(string googleIdToken, bool rememberMe)
        {
            //JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

            if (!jwtHandler.CanReadToken(googleIdToken))
            {
                throw new Exception("Invalidated googleIdToken");
            }


            var payload = GoogleJsonWebSignature.ValidateAsync(googleIdToken, new GoogleJsonWebSignature.ValidationSettings()).Result;
            //return repos.Accounts.GetByUsernameAsync(payload.Email);
            Account account = await repos.Accounts.GetByEmailAsync(payload.Email);
            if (account == null)
            {
                return null;
            }
            LoginInfoDto loginInfoDto = mapper.Map<LoginInfoDto>(account);
            loginInfoDto.Token = await GenerateJwtAsync(account, rememberMe);
            return loginInfoDto;
        }

        public async Task<LoginInfoDto> LoginWithGoogleAccessToken(string googleAccessToken, bool rememberMe)
        {
            var userInfoUrl = "https://www.googleapis.com/oauth2/v1/userinfo";
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", googleAccessToken);
            var response = hc.GetAsync(userInfoUrl).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw (new Exception(JsonConvert.SerializeObject(response, Formatting.Indented)));
                
            }
            var userInfoString = response.Content.ReadAsStringAsync().Result;
            GoogleUser userInfo = JsonConvert.DeserializeObject<GoogleUser>(userInfoString);
            Account account = await repos.Accounts.GetByEmailAsync(userInfo.Email);
            if (account == null)
            {
                return null;
            }
            LoginInfoDto loginInfoDto = mapper.Map<LoginInfoDto>(account);
            loginInfoDto.Token = await GenerateJwtAsync(account, rememberMe);
            return loginInfoDto;
        }

        public async Task<string> GenerateJwtAsync(Account logined, bool rememberMe)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, logined.Id.ToString()),
                new Claim(ClaimTypes.Name, logined.Username),
                new Claim(ClaimTypes.Email, logined.Email),
                new Claim(ClaimTypes.Role, logined.Role.Name),
                //new Claim("Email", logined.Email),
                //new Claim("Role", logined.Role.Name)
            };
            var issuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(configuration["Authentication:JwtToken:TokenKey"]));
            var credential = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                configuration["Authentication:JwtToken:Issuer"],
                configuration["Authentication:JwtToken:Audience"],
                claims,
                expires: rememberMe ? DateTime.Now.AddDays(30) : DateTime.Now.AddDays(1),
                signingCredentials: credential
            );
            return jwtHandler.WriteToken(jwtSecurityToken);
        }

        public async Task Register(Account register, RoleNameEnum role)
        {
            register.RoleId = (int)role;
            await repos.Accounts.CreateAsync(register);
        }
    }
}
