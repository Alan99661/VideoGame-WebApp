﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Servises.ViewModels.SelectModels;

namespace VideoGameApplication.Servises.OtherOperations
{
    public class GetSelectModels
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public GetSelectModels(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<SelectModel> GetDeveloperSelectModels()
        {
            var res = context.Developers.Select(s =>s).ToList();
            return mapper.Map<List<SelectModel>>(res);
        }
        public List<SelectModel> GetGamesSelectModels()
        {
            var res = context.Games.Select(s => s).ToList();
            return mapper.Map<List<SelectModel>>(res);
        }
        public List<SelectModel> GetPlatformSelectModels()
        {
            var res = context.Games.Select(s => s).ToList();
            return mapper.Map<List<SelectModel>>(res);
        }
    }
}