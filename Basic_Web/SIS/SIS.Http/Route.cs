﻿using SIS.HTTP;
using System;

namespace SIS.HTTP
{
    public class Route
    {

        public Route(HttpMethodType httpMethod, string path, Func<HttpRequest, HttpResponse> action)
        {
            this.HttpMethod = httpMethod;
            this.Path = path;
            this.Action = action;
        }
        public string Path { get; set; }

        public HttpMethodType HttpMethod { get; set; }

        public Func<HttpRequest,HttpResponse> Action { get; set; }
    }
}
