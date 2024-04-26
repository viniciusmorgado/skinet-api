namespace Api.Skinet.Errors;

public class ApiResponse
{
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? DefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    public string DefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            #region Informational responses

            100 => "Continue the request, you may.",
            101 => "Switching Protocols, we are.",
            102 => "Processing has begun, hmm?",

            #endregion

            #region Successful responses

            200 => "Found, the resource has been.",
            201 => "Created, the resource has been.",
            202 => "Accepted, the request has been.",
            203 => "Partial information fetched, it was.",
            204 => "No content to send, there is.",
            205 => "Content reset, it has been.",
            206 => "Partial content sent, hmm?",

            #endregion

            #region Redirection messages

            300 => "Multiple choices, there are.",
            301 => "Moved permanently, the resource has been.",
            302 => "Found elsewhere, the resource has been.",
            303 => "See other for the answer, you must.",
            304 => "Not modified, the resource has not been.",
            305 => "Use proxy, you must.",
            306 => "Switch proxy, hmm?",
            307 => "Temporary redirect, this is.",
            308 => "Permanent redirect, this also is.",

            #endregion

            #region Client error responses

            400 => "A bad request, you have made!",
            401 => "Unauthorized, you are not!",
            402 => "Payment required, it is.",
            403 => "Forbidden, this resource is!",
            404 => "Found, the resource was not!",
            405 => "Method not allowed, this is.",
            406 => "Not acceptable, the request is.",
            407 => "Proxy Authentication Required, it is.",
            408 => "Request Timeout, there has been.",
            409 => "Conflict, there is.",
            410 => "Gone, the resource is.",
            411 => "Length Required, it is.",
            412 => "Precondition Failed, it has.",
            413 => "Payload Too Large, it is.",
            414 => "URI Too Long, it is.",
            415 => "Unsupported Media Type, it is.",
            416 => "Requested range unsatisfiable, it is.",
            417 => "Expectation Failed, it has.",
            418 => "I'm a teapot, I am.",
            421 => "Misdirected Request, there is.",
            422 => "Unprocessable Entity, it is.",
            423 => "Locked, the resource is.",
            424 => "Failed Dependency, there is.",
            425 => "Unordered Collection, it is.",
            426 => "Upgrade Required, it is.",
            428 => "Precondition Required, it is.",
            429 => "Too Many Requests, there have been.",
            431 => "Request Header Fields Too Large, they are.",
            451 => "Unavailable For Legal Reasons, it is.",

            #endregion

            #region Server error responses

            500 => "Fear of errors is a path to the darkside!",
            501 => "Not Implemented, it is.",
            502 => "Bad Gateway, there is.",
            503 => "Service Unavailable, it is.",
            504 => "Gateway Timeout, there has been.",
            505 => "HTTP Version Not Supported, it is.",
            506 => "Variant Also Negotiates, it does.",
            507 => "Insufficient Storage, there is.",
            508 => "Loop Detected, there has been.",
            510 => "Not Extended, it is.",
            511 => "Network Authentication Required, it is.",

            #endregion

            _ => null
        };
    }
}
