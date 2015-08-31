namespace WinPhone.MyShows.Models.Shows
{
    using WinPhone.MyShows.Attributes;

    public enum ShowStatus
    {
        [Display("watching")]
        Watching = 1,

        [Display("later")]
        Later,

        [Display("cancelled")]
        Cancelled,

        [Display("remove")]
        Remove 
    }
}
