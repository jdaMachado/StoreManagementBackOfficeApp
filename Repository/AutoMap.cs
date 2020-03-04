using AutoMapper;
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AutoMap
    {
        public IMapper _mapper;

        internal T2 Mapping<T1, T2>(T1 user)
        {
            return _mapper.Map<T1, T2>(user);
        }

    }
}
