using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using LoggexWebAPI.Repositories;
using LoggexWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Vonage.Request;
using Vonage;

namespace LoggexWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IGestorRepository _gestorRepository { get; set; }
        private IMotoristaRepository _motoristaRepository { get; set; }


        public LoginController()
        {
            _gestorRepository = new GestorRepository();
            _motoristaRepository = new MotoristaRepository();

        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// dominio/api/Login
        [HttpPost]
        [Route("Gerente")]
        public IActionResult Login(CredGerenteViewModel login)
        {
            try
            {
                Gestor gestorBuscado = _gestorRepository.login(login);

                if (gestorBuscado == null)
                {
                    return BadRequest("E-mail ou senha inválidos!");
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, gestorBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, gestorBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, "1"),
                    new Claim("role", "1")


                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("loggex-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "Loggex.webAPI",
                        audience: "Loggex.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [HttpPost]
        [Route("Motorista")]
        public IActionResult Login(CredMotoristaViewModel login)
        {
            try
            {

                Random randNum = new Random();
                int codigo = 123456;

                Motorista motoristaBuscado = _motoristaRepository.login(login);

                if (motoristaBuscado == null)
                {
                    return BadRequest("Telefone inválido!");
                }

                //var credentials = Credentials.FromApiKeyAndSecret(
                //    "085b22d5",
                //    "7ZmfbaVgw5SzArlP"
                //);

                //var VonageClient = new VonageClient(credentials);

                //var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                //{
                //    To = "55" + login.Telefone,
                //    From = "Vonage APIs",
                //    Text = "O codigo para acessar o Loggex e " + codigo
                //});

                var minhasClaims = new[]    
                {
                    new Claim(JwtRegisteredClaimNames.Jti, motoristaBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, "2"),
                    new Claim("Telefone", motoristaBuscado.NumCelular.ToString()),
                    new Claim("CodigoLogin", codigo.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("loggex-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "Loggex.webAPI",
                        audience: "Loggex.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

    }
}
