using AutoMapper;
using Messages;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Gateway.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult ReturnWithStatus<Y>(Response<Y> response)
        {
            if (response.ErrorCode == 200)
            {
                if (response.responseData != null)
                {
                    return Ok(response.responseData);
                }
                else
                {
                    return Ok("Request handled");
                }
            }
            else
            {
                return response.ErrorCode != 0 ? StatusCode(response.ErrorCode) : StatusCode(500);
            }
        }
    }
}
