using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public record OrderDTO(DateTime OrderDate, int Order_Sum ,string User );
}
