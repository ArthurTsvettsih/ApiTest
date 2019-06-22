using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Mappers
{
    public interface IMapper<X, Y>
    {
        List<X> MapItems(List<X> mapTo, List<Y> items);
    }
}
