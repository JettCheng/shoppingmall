using System.Runtime.Serialization;

namespace Core.Entities.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value = "待處理")]
        Pending,

        [EnumMember(Value = "已收款")]
        PaymentReceived,

        [EnumMember(Value = "付款失敗")]
        PaymentFailed
    }
}