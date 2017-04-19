namespace Avalon.Data
{
    using System.Data.Entity;
    using System.IO;

    public class AvalonContextInitializer : DropCreateDatabaseIfModelChanges<AvalonContext>
    {
        protected override void Seed(AvalonContext context)
        {
            context.Database.ExecuteSqlCommand(File.ReadAllText("../../Data/AvalonDataInsert.sql"));
        }
    }
}
