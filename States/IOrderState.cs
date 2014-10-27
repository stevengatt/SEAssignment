using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace States
{
    public interface IOrderState
    {
        string NewOrderPlaced();
        string Register();
        string Dispatch();
        string Approve();
    }
}
