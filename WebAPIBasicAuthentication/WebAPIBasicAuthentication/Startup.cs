﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApiBasicAuthentication.Startup))]

namespace WebApiBasicAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        
        }
    }
}
