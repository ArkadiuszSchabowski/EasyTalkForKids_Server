﻿using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;
using EasyTalkForKids_Server.Interfaces;

namespace EasyTalkForKids.Services
{
    public class WordService : IWord
    {
        private readonly IRepository<Word> _repository;
        private readonly IMapper _mapper;

        public WordService(IRepository<Word> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(AddWordDto dto)
        {
            var word = _mapper.Map<Word>(dto);

            _repository.Add(word);
        }
    }
}
