using robotistan.Domain.Models;

namespace robotistan.Domain.Services.Communication
{
    public class SiparisResponse : BaseResponse<Siparis>
    {
        public SiparisResponse(Siparis siparis) : base(siparis) { }

        public SiparisResponse(string message) : base(message) { }
    }
}