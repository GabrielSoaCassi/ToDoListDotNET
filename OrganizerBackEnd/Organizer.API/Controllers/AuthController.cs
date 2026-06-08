using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Organizer.API.Models;
using Organizer.Domain.Interfaces;

namespace Organizer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthenticate _authenticate;
    private readonly IConfiguration _configuration;


    public AuthController(IAuthenticate authenticate, IConfiguration configuration)
    {
        _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
        _configuration = configuration;
    }

    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
    {
        var result = await _authenticate.AuthenticateAsync(userInfo.Email, userInfo.Password);
        if (result)
            return GenerateToken(userInfo);
        ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
        return BadRequest(ModelState);
    }

    [HttpPost("CreateUser")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
    {   
        var result = await _authenticate.RegisterAsync(userInfo.Email, userInfo.Password);

        if (result)
            //return GenerateToken(userInfo);
            return Ok($"User {userInfo.Email} was created successfully");

        ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
        return BadRequest(ModelState);
    }


    private UserToken GenerateToken(LoginModel userInfo)
    {
        //Declarações do usuário
        var claims = new[]
        {
            new Claim("email", userInfo.Email),
            new Claim("meuValor", "Valor que eu quero"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        //Gerar Chave Privada para assinar o token
        var privateKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        //gerar Assinatura Digital do token
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        // definir o tempo de expiração do token

        var expiration = DateTime.UtcNow.AddMinutes(10);

        //gerar o token
        var token = new JwtSecurityToken(
            //emisson
            _configuration["Jwt:Issuer"],
            //audiencia
            _configuration["Jwt:Audience"],
            //claims
            claims,
            //data de expiracao
            expires: expiration,
            //assinatura digital
            signingCredentials: credentials
        );

        return new UserToken
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}