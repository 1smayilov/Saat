﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Colors.UpdateColor
{
    public class UpdateColorCommandRequest : IRequest<UpdateColorCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
