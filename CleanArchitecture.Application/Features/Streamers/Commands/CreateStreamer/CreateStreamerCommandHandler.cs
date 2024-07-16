using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;


namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamEntity = _mapper.Map<Streamer>(request);
            var newstreamer = await _streamerRepository.AddAsync(streamEntity);
            _logger.LogInformation($"Streamer {newstreamer.Id} fue creado exitosamente");
            await SendEmail(newstreamer);
            return newstreamer.Id;
        }
        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email()
            {
                To = "alsanchezm@dap.com.mx",
                Body = "La Compania de streamer se creo correctamente",
                Subject = "Mensaje de alerta"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviado el correo: {ex.Message.ToLower()}");
            }
        }
    }
}
