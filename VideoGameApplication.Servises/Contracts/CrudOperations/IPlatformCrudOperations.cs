﻿using VideoGameApplication.Servises.ViewModels.PlatformViewModels;

namespace VideoGameApplication.Servises.Contracts.CrudOperations
{
    public interface IPlatformCrudOperations
    {
        PlatformViewModel CreatePlatform(PlatformAddModel addModel);
        string DeletePlatform(string id);
        List<PlatformViewModel> GetAll();
        PlatformViewModel GetById(string id);
        PlatformViewModel UpdetePlatform(PlatformUpdateModel updateModel);
    }
}