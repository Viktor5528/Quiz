using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
