using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletApi.Dtos
{
    public class NewUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; } 
    }
}