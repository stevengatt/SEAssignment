using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class ConnectionClass
    {
        public TradersMarketplaceEntities entities;

        public ConnectionClass()
        {
            entities = new TradersMarketplaceEntities();
        }
    }
}
