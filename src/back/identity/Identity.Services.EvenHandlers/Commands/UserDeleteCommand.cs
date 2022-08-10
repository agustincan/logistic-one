using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services.EvenHandlers.Commands
{
    public class UserDeleteCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
