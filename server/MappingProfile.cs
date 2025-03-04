﻿using AutoMapper;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AddLessonDto, Lesson>().ForMember(dest => dest.Words, opt => opt.MapFrom(src => src.WordsDto));
            CreateMap<Lesson, GetLessonDto>().ForMember(dest => dest.WordsDto, opt => opt.MapFrom(src => src.Words));
            
            CreateMap<AddWordDto, Word>();
            CreateMap<Word, AddWordDto>();
        }
    }
}
