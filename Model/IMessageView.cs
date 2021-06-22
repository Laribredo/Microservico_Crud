using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservico_Crud.Model
{
    public interface IMessageView
    {
        public MessageView SetMessage(bool success, string message);
    }
}
