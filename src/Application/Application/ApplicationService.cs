using Application.IService;
using Application.Model;
using AutoMapper;
using Core.IService;
using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{

    [Export(typeof(IApplication))]
    public class ApplicationService : IApplication
    {
        [Import]
        protected IUsersService UsersService { set; get; }
        public ReturnList SearchProduct(string smiles)
        {
            return new ReturnList();
        }

        public int InSert(ApplicationUsers entity)
        {
            Users dbEntity= Mapper.Map<ApplicationUsers, Users>(entity);
            UsersService.InsertUser(dbEntity);
            return 0;
        }
    }
}
