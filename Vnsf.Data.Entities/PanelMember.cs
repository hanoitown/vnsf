﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class PanelMember : Researcher
    {
        public virtual PanelMemberRole PanelMemberRole { get; set; }
    }
}
