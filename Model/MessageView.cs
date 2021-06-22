using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservico_Crud.Model
{
    public class MessageView : IMessageView
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public MessageView SetMessage(bool success, string message)
        {
            this.Success = success;
            this.Message = message;

            return this;
        }
    }
}
