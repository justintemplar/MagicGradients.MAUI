using System;
using System.ComponentModel;
using System.Globalization;

namespace MagicGradients.Converters
{
    public class DimensionsTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string);

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            => destinationType == typeof(string);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var valueStr = value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(valueStr))
                return Dimensions.Zero;

            var dim = valueStr.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (dim.Length == 1)
            {
                return new Dimensions(ReadDimension(dim[0]));
            }

            if (dim.Length == 2)
            {
                return new Dimensions(ReadDimension(dim[0]), ReadDimension(dim[1]));
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Dimensions)}");
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is Dimensions dim)
                return $"{dim.Width.ToStringWithUnit()} {dim.Height.ToStringWithUnit()}";

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
