using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Contract
{
    public static class RabbitMqConstants
    {

        public const string RabbitMqUri =
            "amqp://guest:guest@localhost:5672/";

        public const string JsonMimeType =
            "application/json";

        public const string RegisterSpeciallExchange =
            "specialapp.specialcreate.exchange";

        public const string RegisterSpeciallQueue =
            "specialapp.specialcreate.exchange";
    }
}
