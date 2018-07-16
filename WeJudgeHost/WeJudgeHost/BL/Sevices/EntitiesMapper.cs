using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeJudgeHost.BL.Dal.Entities;
using WeJudgeHost.BL.Models;

namespace WeJudgeHost.BL.Sevices
{
    public  class EntitiesMapper: Profile
    {
        public EntitiesMapper()
        {
            Map();
        }

        internal  void Map()
        {
            CreateMap<User, UserModel>();
        }
    }
}
