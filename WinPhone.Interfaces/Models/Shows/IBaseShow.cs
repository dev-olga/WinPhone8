namespace WinPhone.Interfaces.Models.Shows
{
    public interface IBaseShow
    {
        string Title { get; set; }

        string RuTitle { get; set; }

        string Image { get; set; }

        double Rating { get; set; }
        
    }
}
