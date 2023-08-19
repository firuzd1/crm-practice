using Crm.Entities;

public static class IntegerExtension
{
    public static bool TryParse(this int genderIndex, out Gender gender)
    {
        switch(genderIndex)
        {
            case 0:
                gender = Gender.Male;
                return true;
            case 1:
                gender = Gender.Female;
                return true;
            default:
                gender = default;
                return false;
        }
    }
    public static bool TryParseForDeliverytype(this int DeliveryTypeIndex, out DeliveryType deliveyType)
    {
        switch(DeliveryTypeIndex)
        {
            case 0:
            deliveyType = DeliveryType.free;
            return true;
            case 1:
            deliveyType = DeliveryType.express;
            return true;
            default:
            deliveyType = default;
            return false;
        }
    }
}