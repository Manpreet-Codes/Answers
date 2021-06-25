using Answers.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answers.Extensions
{
    public static class Extensions
    {
        public static bool CompareProductList(this List<Product> list1, List<Product> list2)
        {
            bool IsEqual = true;

            if ((list1 == null && list2 != null) || (list2 == null && list1 != null))
                return false;

            foreach (Product item in list1)
            {
                Product Object1 = item;
                Product Object2 = list2.ElementAt(list1.IndexOf(item));
                               
                if ((Object1 == null && Object2 != null) || (Object2 == null && Object1 != null) ||
                    !Object1.name.Equals(Object2.name))
                {
                    IsEqual = false;
                    break;
                }
            }

            return IsEqual;
        }

        public static bool CompareKeyValue<T, K>(this List<KeyValuePair<T, K>> kv1, List<KeyValuePair<T, K>> kv2)
        {
            bool IsEqual = true;

            foreach (var item in kv1)
            {
                KeyValuePair<T, K> Object1 = item;
                KeyValuePair<T, K> Object2 = kv2.ElementAt(kv2.IndexOf(item));

                if (!Object1.Key.Equals(Object2.Key) || !Object1.Value.Equals(Object2.Value))
                {
                    IsEqual = false;
                    break;
                }

            }

            return IsEqual;
        }
    }
}
