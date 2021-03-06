﻿using System;

namespace Codecov.Url
{
    internal class Url : IUrl
    {
        private readonly Lazy<Uri> _getUrl;

        public Url(IHost host, IRoute route, IQuery query)
        {
            Host = host;
            Route = route;
            Query = query;
            _getUrl = new Lazy<Uri>(() => new Uri($"{Host.GetHost}/{Route.GetRoute}?{Query.GetQuery}"));
        }

        public Uri GetUrl => _getUrl.Value;

        private IHost Host { get; }

        private IQuery Query { get; }

        private IRoute Route { get; }
    }
}