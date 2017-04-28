using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IApplicationService
    {
        ReturnList SearchProduct(string smiles);

        int InSert(ApplicationUsers entity);

    }
}
