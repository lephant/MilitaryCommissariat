namespace MilitaryCommissariat.Converters
{
    public interface IConverter<out TTarget, in TSource>
    {
        TTarget Convert(TSource source);
    }
}