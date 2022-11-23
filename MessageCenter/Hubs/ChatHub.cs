using Data.IRepository;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace MessageCenter.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        /// <summary>
        /// key用户id，value连接id
        /// </summary>
        private static Dictionary<string, string> map = new Dictionary<string, string>();
        private readonly IUserLoginRepository _userService;
        public ChatHub(IUserLoginRepository userService)
        {
            this._userService = userService;
        }
        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (map.Count > 0)
            {
                //连接关闭时从map中删除
                var remove = map.FirstOrDefault(n => n.Value == Context.ConnectionId);
                map.Remove(remove.Key);
            }
            return base.OnDisconnectedAsync(exception);
        }
        /// <summary>
        /// 新连接
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            //此时可以得到连接id，但无法知道是哪个用户
            await base.OnConnectedAsync();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task Login(string userName, string pwd)
        {
            //校验账户密码是否正确
            //var userInfo =  _userService.GetLoginUser(userName, pwd).FirstOrDefault();
            //if (userInfo == null)
            //{
            //    //登录结果通知
            //    await Clients.Clients(Context.ConnectionId).LoginResult(false, 0);
            //    return;
            //}
            ////正确，将用户id作为key，连接id作为value存入map中
            //map.Add(userInfo.Id.ToString(), Context.ConnectionId);
            ////通知客户端登录成功
            //await Clients.Clients(Context.ConnectionId).LoginResult(true, userInfo.user_mi);
            ////通知用户的在线的好友
            //OnlineToUserMessage onlineToUserMessage = new OnlineToUserMessage
            //{
            //    NickName = userInfo.NickName,
            //    ConnectionId = Context.ConnectionId,
            //};
            ////要通知的好友列表
            //var youBuddy = await _userService.GetBuddyId(userInfo.Id);
            //var sendList = new List<string>();
            //foreach (var item in youBuddy)
            //{
            //    //好友的id是否在map中，不在代表没上线
            //    var key = item.Id.ToString();
            //    if (map.ContainsKey(key))
            //    {
            //        sendList.Add(map[key]);
            //    }
            //}

            //if (sendList.Any())
            //{
            //    //通知好友
            //    await Clients.Clients(sendList).BuddysOnline(onlineToUserMessage);
            //}
        }
         
    }
}
