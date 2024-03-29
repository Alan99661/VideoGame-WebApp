﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;
using VideoGameApplication.Servises.ViewModels.GameViewModels;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;
using VideoGameApplication.Servises.ViewModels.PlatformViewModels;
using VideoGameApplication.Servises.ViewModels.ReviewViewModels;
using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;
using VideoGameApplication.Servises.ViewModels.SelectModels;

namespace VideoGameApplication.Servises.MapConfig
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<Game, GameViewModel>().ReverseMap();
            CreateMap<Game, GameAddModel>().ReverseMap();
            CreateMap<Game, GameUpdateModel>().ReverseMap();
            CreateMap<Game, SelectModel>().ReverseMap();
            CreateMap<Developer, DeveloperViewModel>().ReverseMap();
            CreateMap<Developer, DeveloperAddModel>().ReverseMap();
            CreateMap<Developer, DeveloperUpdateModel>().ReverseMap();
            CreateMap<Developer, SelectModel>().ReverseMap();
            CreateMap<Genre, GenreViewModel>().ReverseMap();
            CreateMap<Genre, GenreUpdateModel>().ReverseMap();
            CreateMap<Genre, GenreAddModel>().ReverseMap();
            CreateMap<Genre, SelectModel>().ReverseMap();
            CreateMap<Platform, PlatformViewModel>().ReverseMap();
            CreateMap<Platform, PlatformAddModel>().ReverseMap();
            CreateMap<Platform, PlatformUpdateModel>().ReverseMap();
            CreateMap<Platform, SelectModel>().ReverseMap();
            CreateMap<Review, ReviewViewModel>().ReverseMap();
            CreateMap<Review, ReviewAddModel>().ReverseMap();
            CreateMap<Review, ReviewUpdateModel>().ReverseMap();
            CreateMap<Screenshot, ScreenshotViewModel>().ReverseMap();
            CreateMap<Screenshot, ScreenshotUpdateModel>().ReverseMap();
            CreateMap<Screenshot, ScreenshotAddModel>().ReverseMap();
        }
    }
}
