﻿using AutoMapper;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>();

            CreateMap<AddLessonDto, Lesson>();
            CreateMap<Lesson, GetLessonDto>().ForMember(dest => dest.WordsDto, opt => opt.MapFrom(src => src.Words));
            
            CreateMap<AddWordDto, Word>();
            CreateMap<Word, GetWordDto>();
        }
    }
}
