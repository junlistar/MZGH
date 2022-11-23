using System.Threading.Tasks;

namespace MessageCenter.Hubs
{
    /// <summary>
    /// 客户端需要监听的方法
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// 用户登录时发送
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Task LoginResult(bool result, long? uid);
        /// <summary>
        /// 好友上线通知
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Task BuddysOnline(OnlineToUserMessage onlineToUserMessage);
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <returns></returns>
        public Task ReceiveMessage(string msg, DateTime sendTime);
        /// <summary>
        /// 接收好友列表
        /// </summary>
        /// <returns></returns>
        public Task ReceiveBuddyList(List<object> map);
        /// <summary>
        /// 接收添加好友结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public Task ReceiveAddBuddyResult(string result);
    }
}
