﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Megumin
{
    /// <summary>
    /// 阈
    /// </summary>
    public struct Threshold<T> where T:IComparable<T>
    {
        /// <summary>
        /// 下界
        /// </summary>
        public T Lower { get; }
        /// <summary>
        /// 上界
        /// </summary>
        public T Upper { get; }

        
        

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="l">下界</param>
        /// <param name="u">上界</param>
        public Threshold(T lower, T upper)
        {
            if (lower.CompareTo(upper) > 0)
            {
                Lower = upper;
                Upper = lower;
            }
            else
            {
                Lower = lower;
                Upper = upper;
            }
        }

        /// <summary>
        /// 是不是在界限内
        /// </summary>
        public bool Contain(T v)
        {
            return v.CompareTo(Lower) >= 0 && v.CompareTo(Upper) <= 0;
        }

        /// <summary>
        /// 是否小于下界
        /// </summary>
        public static bool operator < (in T target,in Threshold<T> threshold)
        {
            return target.CompareTo(threshold.Lower) < 0;
        }

        /// <summary>
        /// 是否大于上界
        /// </summary>
        public static bool operator > (in T target,in Threshold<T> threshold)
        {
            return target.CompareTo(threshold.Upper) > 0;
        }
    }
}
