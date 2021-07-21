using System;

public class ApiException : Exception {

    public int ErrorCode { get; private set; }

    public ApiException(int errorCode, string message) : base(message) {
        ErrorCode = errorCode;
    }
}
