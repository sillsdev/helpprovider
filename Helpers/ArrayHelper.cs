using System;
using System.Collections.Generic;
using System.Text;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class ArrayHelper
    {
       #region Subarray
        public static Array CreateSubArray( Array array, int Length )
        {
            return CreateSubArray( array, 0, Length );
        }

        public static Array CreateSubArray( Array array, int Offset, int Length )
        {
            Array ret = Array.CreateInstance( array.GetType().GetElementType(), Length );
            for ( int i = Offset; i < Offset + Length; i++ )
                ret.SetValue( array.GetValue( i ), i - Offset );

            return ret;
        }
        #endregion
    }
}
