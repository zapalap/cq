using AutoMapper;
using AutoMapper.QueryableExtensions;
using cq.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Queries
{
    public class ListReviewsHandler : IRequestHandler<ListReviewsQuery, IEnumerable<ReviewDto>>
    {
        private IConfigurationProvider MapperConfig;
        private CqEntities Db;

        public ListReviewsHandler(IConfigurationProvider mapperConfig, CqEntities db)
        {
            MapperConfig = mapperConfig;
            Db = db;
        }

        public IEnumerable<ReviewDto> Handle(ListReviewsQuery message)
        {
            var dtos = Db
                .Reviews
                .ProjectTo<ReviewDto>(MapperConfig)
                .ToList();

            return dtos;
        }
    }
}