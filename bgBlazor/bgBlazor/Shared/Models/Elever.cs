using System;
using System.Collections.Generic;

namespace bgBlazor.Shared.Models
{
    public partial class Elever
    {
        public int Id { get; set; }
        public string Fornavn { get; set; } = null!;
        public string Efternavn { get; set; } = null!;
        public string KursusType { get; set; } = null!;
    }
}
