using AutoMapper;
using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Services
{
    public class TopicService : IAddService<AddTopicDto>, IGetService<GetTopicDto>,
        IRemoveService<RemoveTopicDto>
    {
        private readonly IRepository<Topic> _repository;
        private readonly IMapper _mapper;

        public TopicService(IRepository<Topic> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(AddTopicDto dto)
        {
            var topic = _mapper.Map<Topic>(dto);

            _repository.Add(topic);
        }

        public List<GetTopicDto> Get()
        {
            List<Topic> topics = _repository.Get();

            var dto = _mapper.Map<List<GetTopicDto>>(topics);

            return dto;
        }

        public GetTopicDto Get(int id)
        {
            Topic? topic = _repository.Get(id);

            if (topic == null)
            {
                throw new NotFoundException("Nie znaleziono lekcji o takim numerze Id!");
            }

            var dto = _mapper.Map<GetTopicDto>(topic);

            return dto;
        }

        public void Remove(int id)
        {
            Topic? topic = _repository.Get(id);

            if (topic == null)
            {
                throw new NotFoundException("Nie znaleziono lekcji o takim numerze Id!");
            }

            _repository.Remove(topic);
        }
    }
}