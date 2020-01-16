﻿using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Model.Response.Market;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle last 24h candlestick data from WebSocket
    /// </summary>
    public class Last24hCandlestickWebSocketClient : WebSocketClientBase<SubscribeLast24hCandlestickResponse>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public Last24hCandlestickWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
        {
        }

        /// <summary>
        /// Request full candlestick data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Req(string symbol, string clientId = "")
        {
            _WebSocket.Send($"{{\"req\": \"market.{symbol}.detail\",\"id\": \"{clientId}\" }}");
        }


        /// <summary>
        /// Subscribe latest 24h market stats
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string clientId = "")
        {
            _WebSocket.Send($"{{\"sub\": \"market.{symbol}.detail\",\"id\": \"{clientId}\" }}");
        }

        /// <summary>
        /// Unsubscribe latest 24 market stats
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.detail\",\"id\": \"{clientId}\" }}");
        }
    }
}
