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
            CreateMap<LessonDto, Lesson>().ForMember(dest => dest.Words, opt => opt.MapFrom(src => src.WordsDto));
            CreateMap<Lesson, LessonDto>().ForMember(dest => dest.WordsDto, opt => opt.MapFrom(src => src.Words));
        }
    }
}
