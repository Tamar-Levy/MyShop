using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public record OrderDTO(DateTime OrderDate, int OrderSum, string? UserEmail);
    public record PostOrderDTO(DateTime OrderDate, int OrderSum,int UserId ,List<int> OrderItemsOrderItemId);

}
