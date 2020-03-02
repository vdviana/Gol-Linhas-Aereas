using System;
using System.Collections.Generic;

namespace Gol.Domain.Entities
{
    public class Travel : BaseEntity
    {
        public string Nome { get; set; }
        public string DataPartida { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
}


