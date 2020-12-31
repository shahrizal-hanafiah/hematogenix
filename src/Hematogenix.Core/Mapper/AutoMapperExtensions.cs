using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Hematogenix.Core.Mapper
{
    public static class AutoMapExtensions
    {
        public static TDestination MapTo<TDestination>(this object source)
        {
            return MapTo<TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return MapTo(source, destination);
        }
    }
}
