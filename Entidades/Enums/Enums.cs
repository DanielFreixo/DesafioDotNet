using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Entidades.Enums
{
    public class Enums
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum StatusToDoEnum
        {
            Pendente = 0,
            EmAndamento,
            Concluido,
        }
    }
}
