using robotistan.Domain.Models;

namespace robotistan.Domain.Services.Communication
{
    public class SepetResponse : BaseResponse<Sepet>
    {
        public SepetResponse(Sepet sepet) : base(sepet) { }

        public SepetResponse(string message) : base(message) { }
    }
}