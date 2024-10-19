﻿using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Settings;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}