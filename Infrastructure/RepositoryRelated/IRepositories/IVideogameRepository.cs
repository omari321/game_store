﻿using Infrastructure.Entities.Videogame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IVideogameRepository:IRepositoryBase<VideogameEntity>
    {
    }
}
