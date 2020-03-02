using robotistan.Domain.Models;

namespace robotistan.Domain.Services.Communication
{
    public class SliderResponse : BaseResponse<Slider>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="slider">Saved slider.</param>
        /// <returns>Response.</returns>
        public SliderResponse(Slider slider) : base(slider)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SliderResponse(string message) : base(message)
        { }
    }
}