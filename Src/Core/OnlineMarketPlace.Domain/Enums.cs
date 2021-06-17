using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Domain
{
    public enum Role
    {
        Admin,
        Provider,
        Client
    }

    public enum DataType
    {
        String,
        Integer,
        Float,
        Boolean
    }
}
