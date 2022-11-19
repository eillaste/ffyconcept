﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IStateService : IBaseEntityService<BLLAppDTO.State,DALAppDTO.State>, IStateRepositoryCustom<BLLAppDTO.State>
    {
        Task<Dictionary<string, Dictionary<string, double>>> GetStatsAsync(Guid userId, DateTime dateTime,
            bool noTracking = true);
    }
}