using System.Threading.Tasks;

namespace WinPhone.App.Interfaces
{
    internal interface IOfflineMode
    {
        Task SaveState();
    }
}
