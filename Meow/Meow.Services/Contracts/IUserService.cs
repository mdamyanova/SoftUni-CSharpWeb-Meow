﻿namespace Meow.Services.Contracts
{
    using Models;

    public interface IUserService
    {
        UserProfileServiceModel Profile(string id);
    }
}