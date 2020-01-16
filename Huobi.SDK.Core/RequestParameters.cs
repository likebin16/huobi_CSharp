﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huobi.SDK.Core
{
    /// <summary>
    /// Manage the HTTP GET request parameters
    /// </summary>
    public class RequestParammeters
    {
        private Dictionary<string, string> _params;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestParammeters">The initial object</param>
        public RequestParammeters(RequestParammeters requestParammeters = null)
        {
            if (requestParammeters != null)
            {
                _params = new Dictionary<string, string>(requestParammeters._params);
            }
            else
            {
                _params = new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Add URL escape property and value pair
        /// </summary>
        /// <param name="property">property</param>
        /// <param name="value">value</param>
        /// <returns>Current object</returns>
        public RequestParammeters AddParam(string property, string value)
        {
            if ((property != null) && (value != null))
            {
                _params.Add(Uri.EscapeDataString(property), Uri.EscapeDataString(value));
            }

            return this;
        }

        /// <summary>
        /// Add and merge another object
        /// </summary>
        /// <param name="requestParammeters">The object that want to add</param>
        /// <returns>Current object</returns>
        public RequestParammeters AddParam(RequestParammeters requestParammeters)
        {
            _params.Concat(requestParammeters._params);

            return this;
        }

        /// <summary>
        /// Concat the propery and value pair
        /// </summary>
        /// <returns>string</returns>
        public string BuildParams()
        {
            if (_params.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            
            foreach (var para in _params.OrderBy(i => i.Key, StringComparer.Ordinal))
            {
                sb.Append('&');
                sb.Append(para.Key).Append('=').Append(para.Value);
            }

            return sb.ToString().Substring(1);
        }
    }
}
