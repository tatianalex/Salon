﻿namespace Services.Enums;

public class BaseResponse<T> : BaseResponse
{
    public BaseResponse(T data)
    {
        Data = data;
    }

    public BaseResponse(Exception ex) : base(ex)
    {
    }

    public BaseResponse(SalonException ex) : base(ex)
    {
    }

    public T Data { get; set; }
}
public class BaseResponse
{
    public BaseResponse()
    {
    }

    public BaseResponse(string errorMessage, string stackTrace = "",
        EnumErrorCode errorCode = EnumErrorCode.Unknown)
    {
        ErrorMessage = errorMessage;
        StackTrace = stackTrace;
        ErrorCode = errorCode;
    }

    public BaseResponse(SalonException ex)
    {
        ErrorMessage = ex.Message;
        StackTrace = ex.StackTrace ?? "";
        ErrorCode = ex.ErrorCode;
    }

    public BaseResponse(Exception ex)
    {
        ErrorMessage = ex.Message;
        StackTrace = ex.StackTrace ?? "";
        ErrorCode = EnumErrorCode.Unknown;
    }
    public string ErrorMessage { get; set; } = null!;
    public string StackTrace { get; set; } = null!;

    public EnumErrorCode ErrorCode { get; set; } = EnumErrorCode.Unknown;

    public bool IsSuccess => string.IsNullOrWhiteSpace(ErrorMessage);

       
}