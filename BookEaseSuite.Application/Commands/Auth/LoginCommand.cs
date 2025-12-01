using BookEaseSuite.Application.Dtos.Auth.Requests;
using BookEaseSuite.Application.Dtos.Auth.Responses;
using BookEaseSuite.Application.Wrappers;
using MediatR;

namespace BookEaseSuite.Application.Commands.Auth
{
    public class LoginCommand : IRequest<ApplicationResult<LoginResponseDto>>
    {
        public LoginRequestDto LoginRequestDto { get; set; } = new LoginRequestDto();
        public LoginCommand(LoginRequestDto loginRequestDto)
        {
            LoginRequestDto = loginRequestDto;
        }
    }
}
