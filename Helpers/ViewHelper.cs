namespace TicketingSample.Helpers;

public static class ViewHelper
{
    ///<summary>
    ///Formatovanie datumu na slovensky format
    ///</summary>
    public static string ToDisplayDateTime(this DateTime date) => date.ToString("dd.MM.yyyy HH:mm");
}