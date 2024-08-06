using System;
using System.ComponentModel;
using System.Globalization;

namespace MagicGradients.Converters
{
    public class OffsetTypeConverter : TypeConverter
    { 
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string);
        
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            => destinationType == typeof(string);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return ReadDimension(value?.ToString());

            //return Offset.Parse(value?.ToString(), OffsetType.Proportional);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is Offset offset)
                return offset.ToStringWithUnit();

            throw new NotSupportedException();
        }

        private Offset ReadDimension(string strValue)
        {
            if (string.Compare(strValue, "*", StringComparison.OrdinalIgnoreCase) == 0)
                return Offset.Proportional(1);

            if (strValue.EndsWith("*", StringComparison.Ordinal) && double.TryParse(strValue.Substring(0, strValue.Length - 1), NumberStyles.Number, CultureInfo.InvariantCulture, out var length))
                return Offset.Proportional(length);

            if (double.TryParse(strValue, NumberStyles.Number, CultureInfo.InvariantCulture, out length))
                return Offset.Absolute(length);

            return Offset.Empty;
        }
    }
}
