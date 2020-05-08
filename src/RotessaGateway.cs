// <copyright file="RotessaGateway.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Rotessa.Types;

    using ServiceStack;
    using ServiceStack.Text;

    /// <summary>
    /// Defines a gateway for the https://rotessa.com/ API.
    /// </summary>
    public class RotessaGateway : IRestGateway
    {
        /// <summary>
        /// Base URL for the production API.
        /// </summary>
        private const string ProdApiBaseUrl = "https://api.rotessa.com/v1";

        /// <summary>
        /// Base URL for the sandbox API.
        /// </summary>
        private const string SandboxApiBaseUrl = "https://sandbox-api.rotessa.com/v1";

        /// <summary>
        /// Selected base URL.
        /// </summary>
        private readonly string baseUrl;

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        public TimeSpan Timeout { get; set; }

        private readonly string apiKey;

        private readonly string userAgent;

        /// <summary>
        /// Initializes a new instance of the <see cref="RotessaGateway"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The API key.
        /// </param>
        /// <param name="sandboxMode">
        /// Indicates whether the gateway should connect to the sandbox API instance
        /// or the production API instance.
        /// </param>
        public RotessaGateway(string apiKey, bool sandboxMode)
        {
            this.baseUrl = sandboxMode ? SandboxApiBaseUrl : ProdApiBaseUrl;
            this.apiKey = apiKey;
            this.Timeout = TimeSpan.FromSeconds(60);
            this.userAgent = @"rubricem rotessa v1";
            JsConfig.InitStatics();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected virtual void InitRequest(HttpWebRequest req, string method)
        {
            req.Accept = MimeTypes.Json;
            req.Headers.Add("Authorization", "Bearer " + this.apiKey);

            if (method == HttpMethods.Post || method == HttpMethods.Put)
            {
                req.ContentType = MimeTypes.Json;
            }

            PclExport.Instance.Config(
                req,
                userAgent: this.userAgent,
                timeout: this.Timeout,
                preAuthenticate: true);
        }

        protected virtual void HandleRotessaException(WebException ex)
        {
            var errorBody = ex.GetResponseBody();
            var errorStatus = ex.GetStatus() ?? HttpStatusCode.BadRequest;

            if (!ex.IsAny400())
            {
                return;
            }

            var result = errorBody.FromJson<RotessaErrors>();
            throw new RotessaException(result)
            {
                StatusCode = errorStatus
            };
        }

        protected virtual string Send(string relativeUrl, string method, string body)
        {
            try
            {
                var url = this.baseUrl.CombineWith(relativeUrl);

                var response = url.SendStringToUrl(
                    method,
                    body,
                    requestFilter: req =>
                        {
                            this.InitRequest(req, method);
                        });

                return response;
            }
            catch (WebException ex)
            {
                this.HandleRotessaException(ex);

                throw;
            }
        }

        protected virtual async Task<string> SendAsync(string relativeUrl, string method, string body)
        {
            try
            {
                var url = this.baseUrl.CombineWith(relativeUrl);

                var response = await url.SendStringToUrlAsync(
                                   method,
                                   body,
                                   requestFilter: req =>
                                       {
                                           this.InitRequest(req, method);
                                       }).ConfigureAwait(false);

                return response;
            }
            catch (Exception ex)
            {
                if (ex.UnwrapIfSingleException() is WebException webEx)
                {
                    this.HandleRotessaException(webEx);
                }

                throw;
            }
        }

        public T Send<T>(IReturn<T> request, string method, bool sendRequestBody = true)
        {
            using (new ConfigScope())
            {
                var relativeUrl = request.ToUrl(method);
                var body = sendRequestBody ? JsonSerializer.SerializeToString(request) : null;

                var json = this.Send(relativeUrl, method, body);

                var response = json.FromJson<T>();
                return response;
            }
        }

        public async Task<T> SendAsync<T>(IReturn<T> request, string method, bool sendRequestBody = true)
        {
            string relativeUrl;
            string body;

            using (new ConfigScope())
            {
                relativeUrl = request.ToUrl(method);
                body = sendRequestBody ? JsonSerializer.SerializeToString(request) : null;
            }

            var json = await this.SendAsync(relativeUrl, method, body);

            using (new ConfigScope())
            {
                var response = json.FromJson<T>();
                return response;
            }
        }

        private static string GetMethod<T>(IReturn<T> request)
        {
            var method = request is IPost ?
                  HttpMethods.Post
                : request is IPut ?
                  HttpMethods.Put
                : request is IDelete ?
                  HttpMethods.Delete
                : HttpMethods.Get;
            return method;
        }

        public T Send<T>(IReturn<T> request)
        {
            var method = GetMethod(request);
            return this.Send(request, method, method == HttpMethods.Post || method == HttpMethods.Put || method == HttpMethods.Patch);
        }

        public Task<T> SendAsync<T>(IReturn<T> request)
        {
            var method = GetMethod(request);
            return this.SendAsync(request, method, method == HttpMethods.Post || method == HttpMethods.Put || method == HttpMethods.Patch);
        }

        public T Get<T>(IReturn<T> request)
        {
            return this.Send(request, HttpMethods.Get, false);
        }

        public Task<T> GetAsync<T>(IReturn<T> request)
        {
            return this.SendAsync(request, HttpMethods.Get, false);
        }

        public T Post<T>(IReturn<T> request)
        {
            return this.Send(request, HttpMethods.Post);
        }

        public Task<T> PostAsync<T>(IReturn<T> request)
        {
            return this.SendAsync(request, HttpMethods.Post);
        }

        public T Patch<T>(IReturn<T> request)
        {
            return this.Send(request, HttpMethods.Patch);
        }

        public Task<T> PatchAsync<T>(IReturn<T> request)
        {
            return this.SendAsync(request, HttpMethods.Patch);
        }

        public T Put<T>(IReturn<T> request)
        {
            return this.Send(request, HttpMethods.Put);
        }

        public Task<T> PutAsync<T>(IReturn<T> request)
        {
            return this.SendAsync(request, HttpMethods.Put);
        }

        public T Delete<T>(IReturn<T> request)
        {
            return this.Send(request, HttpMethods.Delete, false);
        }

        public Task<T> DeleteAsync<T>(IReturn<T> request)
        {
            return this.SendAsync(request, HttpMethods.Delete, false);
        }
    }
}
