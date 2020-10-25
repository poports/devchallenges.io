﻿using ChatGroup.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Domain.Entities
{
    public class Channel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
