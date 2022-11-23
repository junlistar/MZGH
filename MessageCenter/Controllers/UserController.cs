using Microsoft.AspNetCore.Mvc;

namespace MessageCenter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //todo:用户消息通知

        //private readonly IUserService _userService;

        //public UserController(IUserService userService)
        //{
        //    this._userService = userService;
        //}
        //[HttpPost]
        //public async Task<string> Register(UserInfo userInfo)
        //{
        //    if (await _userService.Exits(userInfo.UserName))
        //    {
        //        return "用户名已存在";
        //    }

        //    if (await _userService.ExitsByNickName(userInfo.NickName))
        //    {
        //        return "昵称已存在";
        //    }

        //    var user = await _userService.CreateUserInfo(userInfo);
        //    return $"注册成功,您的id是{user.Id}";
        //}
         
    }
}
