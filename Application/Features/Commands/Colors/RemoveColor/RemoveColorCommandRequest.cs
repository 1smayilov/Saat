﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Colors.RemoveColor
{
    public class RemoveColorCommandRequest : IRequest<RemoveColorCommandResponse>
    {
        public int Id { get; set; }
    }
}
