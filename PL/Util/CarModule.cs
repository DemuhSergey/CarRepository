using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace PL.Util
{
    class CarModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarService>().To<CarService>();
        }
    }
}
