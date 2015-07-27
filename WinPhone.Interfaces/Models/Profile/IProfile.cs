namespace WinPhone.Interfaces.Models.Profile
{
    public interface IProfile
    {
        string Login { get; set; }

        string AvatarUrl { get; set; }

        string Gender { get; set; }

        IStatistic Statistic { get; set; }
    }
}
