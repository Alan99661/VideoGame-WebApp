﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Servises.Contracts.SmallServices;
using VideoGameApplication.Servises.ViewModels.ReviewViewModels;

namespace VideoGameApplication.Servises.MicroServises
{
    public class ReviewActions : IReviewActions
	{
		private readonly VideoGameDBContext context;
		private readonly IMapper mapper;

        public ReviewActions(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReviewViewModel CertifyReview(string id)
		{
			var review = context.Reviews.FirstOrDefault(s => s.Id == id);
			review.Certified = true;
			context.Reviews.Update(review);
			context.SaveChanges();
			return mapper.Map<ReviewViewModel>(review);
		}
	}
}
