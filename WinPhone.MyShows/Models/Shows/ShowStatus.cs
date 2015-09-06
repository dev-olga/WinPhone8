namespace WinPhone.MyShows.Models.Shows
{
    using WinPhone.MyShows.Attributes;

    public enum ShowStatus
    {
        [Display("remove")]
        Remove = 0,

        [Display("watching")]
        Watching,

        [Display("later")]
        Later,

        [Display("cancelled")]
        Cancelled
    }
}
