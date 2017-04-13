
namespace Avalon.Service
{
    using Avalon.Data;

    public static class DatabaseService
    {
        public static void InitializeDatabase()
        {
            AvalonContext contex = new AvalonContext();
            contex.Database.Initialize(true);
        }
    }
}
