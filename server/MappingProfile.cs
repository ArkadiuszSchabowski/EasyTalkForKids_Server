using AutoMapper;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WordDto, Word>();
            CreateMap<Word, WordDto>();
            CreateMap<LessonDto, Lesson>();
            CreateMap<Lesson, LessonDto>();
        }
    }
}
