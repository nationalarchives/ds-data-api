﻿using System.Collections.Generic;
using TNA.DataDefinitionObjects;

namespace RepositoryContracts.SarInfo
{
    public interface IClosureCriterionsContext
    {
        List<ClosureCriterions> GetAll();
    }
}
