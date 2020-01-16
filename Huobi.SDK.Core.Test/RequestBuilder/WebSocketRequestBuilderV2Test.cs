﻿using System;
using Huobi.SDK.Core.Model;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class WebSocketRequestBuilderV2Test
    {
        [Fact]
        public void Build_NullParam_Success()
        {
            var builder = new WebSocketV2RequestBuilder("access", "secrect", "api.huobi.pro", "/ws/v1");

            string auth = builder.Build();

            var authReq = JsonConvert.DeserializeObject<WebSocketAuthenticationRequestV2>(auth);

            Assert.Equal("req", authReq.action);
            Assert.Equal("auth", authReq.ch);
            Assert.Equal("api", authReq.@params.authType);
            Assert.Equal("access", authReq.@params.accessKey);
            Assert.Equal("HmacSHA256", authReq.@params.signatureMethod);
            Assert.Equal("2.1", authReq.@params.signatureVersion);
        }

        [Fact]
        public void Build_Time_Success()
        {
            var builder = new WebSocketV2RequestBuilder("access", "secrect", "api.huobi.pro", "/ws/v1");

            DateTime utcTime = new DateTime(2019, 11, 21, 10, 0, 0);
            string auth = builder.Build(utcTime);

            var authReq = JsonConvert.DeserializeObject<WebSocketAuthenticationRequestV2>(auth);

            Assert.Equal("req", authReq.action);
            Assert.Equal("auth", authReq.ch);
            Assert.Equal("api", authReq.@params.authType);
            Assert.Equal("access", authReq.@params.accessKey);
            Assert.Equal("HmacSHA256", authReq.@params.signatureMethod);
            Assert.Equal("2.1", authReq.@params.signatureVersion);
            Assert.Equal(utcTime.ToString("s"), authReq.@params.timestamp);
            Assert.Equal("M8KuuGA+D1pFYplRAI19qKucZNVoHPWh/VdZ6+drdrg=", authReq.@params.signature);
        }
    }
}