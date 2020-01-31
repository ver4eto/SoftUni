﻿namespace SIS.HTTP
{
    public enum HttpResponseCode
    {
       OK = 200,
       MovedPermanentely = 301,
       TemporaryRedirect = 307,
       Unauthorized = 401,
       Forbidden = 403,
       NotFound = 404,
       InternalServerError = 500,
       NotImplemented = 501,

    }
}