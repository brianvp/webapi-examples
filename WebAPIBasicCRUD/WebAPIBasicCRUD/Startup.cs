using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebAPIBasicCRUD.Startup))]

namespace WebAPIBasicCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        
        }
    }
}
