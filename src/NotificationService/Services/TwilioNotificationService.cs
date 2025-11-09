using NotificationService.Dtos;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NotificationService.Services
{
    public class TwilioNotificationService : INotificationService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<TwilioNotificationService> _logger;
        private readonly string _fromNumber;
        private readonly string _accountSid;
        private readonly string _authToken;

        public TwilioNotificationService(IConfiguration config, ILogger<TwilioNotificationService> logger)
        {
            _config = config;
            _logger = logger;
            _accountSid = _config["Twilio:AccountSid"] ?? throw new ArgumentNullException("Twilio:AccountSid");
            _authToken = _config["Twilio:AuthToken"] ?? throw new ArgumentNullException("Twilio:AuthToken");
            _fromNumber = _config["Twilio:From"] ?? throw new ArgumentNullException("Twilio:From");

            TwilioClient.Init(_accountSid, _authToken);
        }
        public Task SendNotificationAsync(NotificationCreateDto dto)
        {
            throw new NotImplementedException("Email method should be implemented elsewhere or reuse existing email service.");
        }

        public async Task SendSmsAsync(SmsCreateDto dto)
        {
            try
            {
                var message = await MessageResource.CreateAsync(
                    to: new PhoneNumber(dto.PhoneNumber),
                    from: new PhoneNumber(_fromNumber),
                    body: dto.Message
                );

                _logger.LogInformation("SMS sent. Sid: {Sid}, To: {To}", message.Sid, dto.PhoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send SMS to {Phone}", dto.PhoneNumber);
                throw;
            }
        }
    }
}
