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
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DisplayNameAttribute)_Attribs.ElementAt(0)).DisplayName;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
