using System.Reflection;

namespace MyKnowledgeManager.Web.Utilities
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DataAnnotations.DisplayAttribute)_Attribs.ElementAt(0)).Name;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
