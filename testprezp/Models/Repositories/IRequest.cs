using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testprezp.Models.Repositories
{
   public interface IRequest
    {
        Task<IEnumerable<Request>> GetAllRequests();
        Task<Request> Getrequest(int rId);

        Task<Request> GetRequestBySender(ApplicationUserModel sender);
        Task<Request> GetRequestByReceiver(ApplicationUserModel receiver);
        Task<Request> Addreq(Request request);
    }
}
