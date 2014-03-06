using System;
using System.Linq;

namespace AJ.DMES.PackageWorkstation.UI.Wpf.Helpers
{
    public static class QuerableExtensions {
        public static void Load<T>(this IQueryable<T> q) { }
    }
}
