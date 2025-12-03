using BookEaseSuite.Application.Dtos.Auth.Requests;
using BookEaseSuite.Application.Dtos.Auth.Responses;
using BookEaseSuite.Application.Wrappers;
using MediatR;

namespace BookEaseSuite.Application.Commands.Auth
{
    public class CreateUserCommand : IRequest<ApplicationResult<RegisterResponseDto>>
    {
        public RegisterRequestDto RegisterRequestDto { get; set; } = new RegisterRequestDto();

        public CreateUserCommand(RegisterRequestDto registerRequestDto)
        {
            RegisterRequestDto = registerRequestDto;
        }
    }
}
