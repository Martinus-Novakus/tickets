namespace TicketingSample.Helpers;

public static class ViewHelper
{
    public static string ToDisplayDateTime(this DateTime date) => date.ToString("dd.MM.yyyy HH:mm");
    public static string ToIsoDateTime(this DateTime date) => date.ToString("o");
}