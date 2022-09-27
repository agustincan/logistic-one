using Identity.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services.EvenHandlers.Queries
{
    public class UserListByIds : IRequest<List<SystemUserDto>>
    {
        public int[] Ids { get; set; } = null!;
    }
}
