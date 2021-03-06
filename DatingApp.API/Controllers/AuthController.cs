using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using DatingApp.API.Models;
using DatingApp.API.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IAuthRepository _repo;

        private readonly IConfiguration _cofig;

        public IMapper _mapper { get; set; }

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {

            _cofig = config;
            _repo = repo;
            _mapper = mapper;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username is already taken.");
            // return BadRequest("Username is already taken.");


            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            
            var userToReturn = _mapper.Map<UserForDetailDto>(createdUser);

            return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.Id}, userToReturn);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();
            // generate token
            // https://jwt.io/
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_cofig.GetSection("AppSettings:Token").Value);
            // 3.32
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)

                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                )

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var user = _mapper.Map<UserForListDto>(userFromRepo);

            return Ok(new { tokenString, user });
        }
    }
}