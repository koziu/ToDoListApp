namespace ToDoListApp.Infrastructure.Extensions
{
  public static class StringExtensions
  {
    public static bool Empty(this string value)
    {
      return string.IsNullOrWhiteSpace(value);
    }
  }
}