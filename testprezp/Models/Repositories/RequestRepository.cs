using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testprezp.Models.Repositories
{
    public class RequestRepository : IRequest
    {
        private readonly AuthenticationContext appdbcontext;
        public RequestRepository(AuthenticationContext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }
        public async Task<Request> Addreq(Request request)
        {
            var result = await appdbcontext.Requests.AddAsync(request);
            await appdbcontext.SaveChangesAsync();
            return result.Entity;
        }



        public async Task<IEnumerable<Request>> GetAllRequests()
        {
            return await appdbcontext.Requests.Include(x => x.sender).Include(i => i.receiver).ToListAsync();
        }

        public async Task<Request> Getrequest(int rId)
        {
            return await appdbcontext.Requests.FirstOrDefaultAsync(e => e.rId == rId);
        }

       



          public async Task<Request> GetRequestByReceiver(ApplicationUserModel receiver)
            {
                return await appdbcontext.Requests.FirstOrDefaultAsync(e => e.receiver == receiver);
           }
        


        public async Task<Request> GetRequestBySender(ApplicationUserModel sender)
        {
            return await appdbcontext.Requests.FirstOrDefaultAsync(e => e.sender == sender);
        }

       
    }
}
