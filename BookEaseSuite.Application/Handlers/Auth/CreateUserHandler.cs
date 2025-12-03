using BookEaseSuite.Application.Commands.Auth;
using BookEaseSuite.Application.Constants;
using BookEaseSuite.Application.Dtos.Auth.Responses;
using BookEaseSuite.Application.Interfaces;
using BookEaseSuite.Application.Wrappers;
using BookEaseSuite.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookEaseSuite.Application.Handlers.Auth
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApplicationResult<RegisterResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IUserRepository userRepository,IPasswordHasher passwordHasher,ILogger<CreateUserHandler> logger)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }
        public async Task<ApplicationResult<RegisterResponseDto>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (command?.RegisterRequestDto == null)
            {
                _logger.LogWarning("CreateUserCommand received with null RegisterRequestDto");
                return ApplicationResult<RegisterResponseDto>.Fail("Invalid request", new List<Error> { new Error { FieldName = "Request", Message = "RegisterRequestDto cannot be null." } }, StatusCodes.BadRequest);
            }

            _logger.LogInformation("Handling CreateUserCommand for Email={Email}", command.RegisterRequestDto.Email);
            var email = command.RegisterRequestDto.Email.Trim().ToLower();
            var userName = command.RegisterRequestDto.UserName.Trim().ToLower();

            var exists = await _userRepository.FindAsync(u => u.Email.Equals(email));
            if(exists is not null)
            {
                _logger.LogInformation("User creation failed - email already in use: Email={Email}", command.RegisterRequestDto.Email);
                return ApplicationResult<RegisterResponseDto>.Fail("Email already in use", new List<Error> { new Error { FieldName = "Email", Message = "A user with this email already exists." } }, StatusCodes.Conflict);
            }

            exists = await _userRepository.FindAsync(u => u.UserName.Equals(userName));
            if (exists is not null)
            {
                _logger.LogInformation("User creation failed - username already in use: UserName={UserName}", command.RegisterRequestDto.UserName);
                return ApplicationResult<RegisterResponseDto>.Fail("UserName already in use", new List<Error> { new Error { FieldName = "UserName", Message = "A user with this username already exists." } }, StatusCodes.Conflict);
            }

            var passwordHash = _passwordHasher.HashPassword(command.RegisterRequestDto.Password);
            var user = command.RegisterRequestDto.Adapt<User>();

            user.Email = email;
            user.UserName = userName;
            user.PasswordHash = passwordHash;
            user.CreatedAt = DateTime.UtcNow;
            user.LastUpdate = DateTime.UtcNow;

            _logger.LogDebug("Adding new user to repository: Email={Email}", user.Email);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            _logger.LogDebug("Saved new user: UserId={UserId} Email={Email}", user.Id, user.Email);

            var userDto = user.Adapt<RegisterResponseDto>();
            _logger.LogInformation("User created successfully: UserId={UserId} Email={Email}", user.Id, user.Email);
            return ApplicationResult<RegisterResponseDto>.Success(userDto, "User created successfully", StatusCodes.Created);
        }
    }

}
