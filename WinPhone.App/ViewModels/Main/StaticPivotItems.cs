namespace WinPhone.App.ViewModels.Main
{
    internal class StaticPivotItems
    {
        public static PivotItems MyShows 
        { 
            get
            {
                return PivotItems.MyShows;
            } 
        }

        public static PivotItems MyProfile
        {
            get
            {
                return PivotItems.MyProfile;
            }
        }

        public static PivotItems Suggestions
        {
            get
            {
                return PivotItems.Suggestions;
            }
        }
    }
}
