namespace IBM.Books.Messaging.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using IBM.Books.Messaging.API.Services;
    using IBM.Books.Messaging.API.Infrastructure.Configuration;
    using Microsoft.Extensions.Options;
    using IBM.Books.Messaging.API.ViewModels;
    using IBM.Books.Messaging.API.Infrastructure.Enumerations;

    [Route("api/v1/[controller]")]
    public class MessageController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly MessagingSettings _settings;
        private readonly IMessageService _messageService;

        public MessageController(IEmailSender emailSender,
             IOptionsSnapshot<MessagingSettings> settings,
             IMessageService messageService)
        {
            this._emailSender = emailSender;
            this._settings = settings.Value;
            this._messageService = messageService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> ListByReceiver([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> ListBySender([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Send([FromBody]MessageViewModel value)
        {
            APIActionResponseViewModel model;
            int? messageId;

            try
            {
                model = new APIActionResponseViewModel();

                // Create message in db
                messageId = await this._messageService.CreateAsync(new BusinessModel.MessageModel
                {
                    BookItemId = value.BookItemId,
                    Content = value.Content,
                    ReceiverId = value.ReceiverId,
                    SenderId = value.SenderId,
                    Status = (MessageStatusEnum)value.Status
                });

                // Send mail
                if (!string.IsNullOrWhiteSpace(value.ReceiverMailAddress))
                {
                    await _emailSender.SendEmailAsync(value.ReceiverMailAddress, "Books@IBM : Vous avez un nouveau message", value.Content);
                }

                //
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                model = new APIActionResponseViewModel("Error", ex.Message);
                return new JsonResult(model);
            }
            finally
            {
                model = null;
                messageId = null;
            }
        }

        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> Test()
        //{
        //    await _emailSender.SendEmailAsync("adrientorris@gmail.com", "test", "test contenu");
        //    return Ok();
        //}
    }
}
