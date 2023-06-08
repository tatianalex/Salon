
using Services.Enums;

namespace Services;

public class SalonException:Exception
{ 
    public EnumErrorCode ErrorCode { get; set; }
    
    public SalonException(string? message = null, EnumErrorCode errorCode = EnumErrorCode.Unknown) : base(message ?? errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

    public SalonException(EnumErrorCode errorCode) : base(errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

   

}