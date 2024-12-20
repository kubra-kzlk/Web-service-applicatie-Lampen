using Microsoft.EntityFrameworkCore;

namespace lampen.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {

    }
}
