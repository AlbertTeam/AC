using Core.IService.User;
using System.ComponentModel.Composition;
using System.IO;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Main
{
    [Export]
    public class MoleculeTransformController : WebController
    {      

        

        public ActionResult GetMol()
        {
            return View();
        }

        public ActionResult GetSmile()
        {
            return View();
        }
        //[Route("{condition}/")]
        public ActionResult GetMolBySmilesOrName(string id)
        {
            WCF.ReactionWay.SearchServiceClient wcf = new WCF.ReactionWay.SearchServiceClient();
            string mol= wcf.GetMolByCasOrName(id, "");
            Message.body = mol;
            if (string.IsNullOrEmpty(mol))
            {
                Message.result.errCode = 1;
                Message.result.msg = Resources.WebResources.ResultMsgError;
            }
            else
            {
                Message.result.errCode = 0;
                Message.result.msg = Resources.WebResources.ResultMsgSuccess;
            }
            return JsonBase(Message);
        }
        public Stream GetPicture()
        {
            return new MemoryStream();
        }
    }
}